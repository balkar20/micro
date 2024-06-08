// See https://aka.ms/new-console-template for more information


using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

Console.WriteLine("Hello, World!");

MySql.Data.MySqlClient.MySqlConnection myConnection;
string myConnectionString;
//set the correct values for your server, user, password and database name
myConnectionString = "server=127.0.0.1;uid=b124733_b124733;pwd=<?A=sv@g~yq2%pBg;database=b124733_db";

try
{
    myConnection = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
    //open a connection
    myConnection.Open();

    // create a MySQL command and set the SQL statement with parameters
    MySqlCommand myCommand = new MySqlCommand();
    myCommand.Connection = myConnection;
    myCommand.CommandText = @"SELECT * FROM Persons";
    //myCommand.Parameters.AddWithValue("@clientId", clientId);

    // execute the command and read the results
    using var myReader = myCommand.ExecuteReader();
    while (myReader.Read())
    {
        var id = myReader.GetInt32("FirstName");
        var name = myReader.GetString("LastName");

        Console.WriteLine(id);
        Console.WriteLine(name);
        // ...
    }
    myConnection.Close();
}
catch (MySql.Data.MySqlClient.MySqlException ex)
{
    Console.WriteLine(ex.Message);
}
