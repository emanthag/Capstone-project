// Data/UserRepository.cs
using System.Data;
using System.Data.SqlClient;

public static class UserRepository
{
    private static readonly string ConnectionString = "YOUR_CONNECTION_STRING_HERE";

    public static void InsertUser(string username, string email)
    {
        using (var connection = new SqlConnection(ConnectionString))
        using (var command = new SqlCommand(
            "INSERT INTO Users (Username, Email) VALUES (@Username, @Email)", connection))
        {
            command.Parameters.Add("@Username", SqlDbType.VarChar, 100).Value = username;
            command.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public static User GetUserByUsername(string username)
    {
        using (var connection = new SqlConnection(ConnectionString))
        using (var command = new SqlCommand(
            "SELECT UserID, Username, Email FROM Users WHERE Username = @Username", connection))
        {
            command.Parameters.Add("@Username", SqlDbType.VarChar, 100).Value = username;

            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                if (!reader.Read())
                    return null;

                return new User
                {
                    UserID = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Email = reader.GetString(2)
                };
            }
        }
    }
}

public class User
{
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
}
