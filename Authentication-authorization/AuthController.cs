// Controllers/AuthController.cs
public class AuthController
{
    public bool Login(string username, string password)
    {
        var sanitizedUsername = InputValidator.SanitizeUsername(username);

        var user = UserRepository.GetUserByUsername(sanitizedUsername);
        if (user == null)
            return false;

        return AuthService.VerifyPassword(password, user.HashedPassword);
    }
}
