namespace Database
{
    public class Connection
    {
        private static readonly ConnectionContext context = new();

        /// <summary>
        /// Checks, if the script can connect to the database
        /// </summary>
        /// <returns>Returns true on success, otherwise it throws an exception</returns>
        public static bool CanConnect()
        {

            return context.Database.CanConnect();
        }

        /// <summary>
        /// Clears all data inside our user table
        /// </summary>
        public static void FlushUserTable()
        {
            var userList = context.User;
            if (userList == null) return;
            context.RemoveRange(userList);
            context.SaveChanges();
        }
    }
}
