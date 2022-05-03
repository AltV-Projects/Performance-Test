using Newtonsoft.Json;
using SharedData;
using System.Collections.ObjectModel;
using System.Diagnostics;

Console.Title = "Query test with JSON serialization";
Console.Clear();

try
{
    if (!Database.Connection.CanConnect())
    {
        Console.WriteLine("Can not connect to our database");
        return;

    }
    Console.WriteLine("Successfully connected to our databse");

    var dbcontext = new Database.ConnectionContext();

    ConsoleHelper.AskFlushData();
    ConsoleHelper.AskDummyData();

    Console.WriteLine();
    Console.WriteLine("Starting performance test");
    Console.WriteLine("=========================");

    const int runCount = 25;
    long neededTime = 0;

    for (int i = 0; i < runCount; i++)
    {
        ICollection<UserData> userData = new Collection<UserData>();
        var userDBData = dbcontext.User.ToList();

        var timer = new Stopwatch();
        timer.Start();

        foreach (var currentUserData in userDBData)
        {
            UserData tmpUser = new UserData();
            var jsonUser = JsonConvert.DeserializeObject<UserData>(currentUserData.Pos);
            if (jsonUser == null)
            {
                Console.WriteLine("Warning, skipped entry due null value!");
                continue;
            }
            userData.Add(jsonUser);
        }

        timer.Stop();

        Console.WriteLine($"It took {timer.ElapsedMilliseconds}ms to assign {ConsoleHelper.amount} positions.");
        neededTime += timer.ElapsedMilliseconds;
    }

    Console.WriteLine("=========================");
    Console.WriteLine($"Ended performance test with an average time of {neededTime / runCount}ms");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine("There was some unexpected error.");
    Console.WriteLine(ex.ToString());
}

return;