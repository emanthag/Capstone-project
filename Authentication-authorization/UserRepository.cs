// Data/UserRepository.cs
public static void AssignRole(int userId, string role)
{
    using var connection = new SqlConnection(ConnectionString);
    using var command = new SqlCommand(
        "UPDATE Users SET Role = @Role WHERE UserID = @UserID", connection);

    command.Parameters.AddWithValue("@Role", role);
    command.Parameters.AddWithValue("@UserID", userId);

    connection.Open();
    command.ExecuteNonQuery();
}
