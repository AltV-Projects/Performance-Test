using Database;
using Database.Model;
using Newtonsoft.Json;

namespace SharedData
{
    public static class ConsoleHelper
    {
        private static bool correctKeyPressed;
        public static int amount = 250000;
        private static ConnectionContext dbcontext = new Database.ConnectionContext();
        public static void AskDummyData()
        {
            correctKeyPressed = false;
            while (!correctKeyPressed)
            {
                Console.Write("Add new dummy data? [y/n] ");
                var result = Console.ReadKey();
                Console.WriteLine();
                if (result.KeyChar == 'y' || result.KeyChar == 'n') correctKeyPressed = true;
                if (result.KeyChar == 'n') break;

                Console.Write($"How much runs? [{amount}] ");
                var stringAmount = Console.ReadLine();
                Console.WriteLine();
                amount = (stringAmount == null || stringAmount.Length > 0) ? Convert.ToInt32(stringAmount) : amount;

                Console.WriteLine($"Adding {amount} entries to our database, please wait.");
                Random rand = new Random();
                for (int i = 0; i < amount; i++)
                {
                    UserData data = new UserData();
                    data.PosX = (float)rand.NextDouble() * 100;
                    data.PosY = (float)rand.NextDouble() * 100;
                    data.PosZ = (float)rand.NextDouble() * 100;

                    User userData = new User();
                    userData.PosX = data.PosX;
                    userData.PosY = data.PosY;
                    userData.PosZ = data.PosZ;
                    userData.Pos = JsonConvert.SerializeObject(userData);

                    dbcontext.User.Add(userData);
                }
                dbcontext.SaveChanges();
                Console.WriteLine($"Finished: {amount} entries added.");
            }
        }
        public static void AskFlushData()
        {
            correctKeyPressed = false;
            while (!correctKeyPressed)
            {
                Console.Write("Flush user table? [y/n] ");
                var result = Console.ReadKey();
                Console.WriteLine();
                if (result.KeyChar == 'y' || result.KeyChar == 'n') correctKeyPressed = true;
                if (result.KeyChar == 'y') Database.Connection.FlushUserTable();

            }
        }
    }
}
