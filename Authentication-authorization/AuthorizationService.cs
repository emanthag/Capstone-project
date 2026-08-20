// Services/AuthorizationService.cs
public static class AuthorizationService
{
    public static bool UserHasRole(User user, string requiredRole)
    {
        return user.Role.Equals(requiredRole, StringComparison.OrdinalIgnoreCase);
    }
}
