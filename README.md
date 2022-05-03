# Performance Test for C#

tl;dr We had a discusion in our Discord, what's faster: Selecting table rows and assigning the value one by one or use Newtonsoft's JSON (De)serializer. Thats why whis tool exists (its not perfect, but u can use it to test).

## Installation

Clone the repository, then do a restore to install all dependencies:

```dotnet
dotnet restore
```

## Configuration

Edit the `Config.cs` inside `Database` folder with your needs.

Example
```csharp
namespace Database
{
    public class Config
    {
        public string Database = "testdb";
        public string Host = "localhost";
        public string Username = "notroot";
        public string Password = "";
        public int Port = 3306;
    }
}
```

After you set the correct credentials, you need to apply the database schema. To do that you need to run the following command:

```
Update-Database
```

## Build it

You can now build the entire project with:

```dotnet
dotnet publish
```

## License
[MIT](https://choosealicense.com/licenses/mit/)