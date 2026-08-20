// Controllers/UserController.cs
public class UserController
{
    public void Submit(string username, string email)
    {
        var safeUsername = InputValidator.SanitizeUsername(username);
        var safeEmail = InputValidator.SanitizeEmail(email);

        // Pass safe values to database layer
        UserRepository.InsertUser(safeUsername, safeEmail);
    }
}
