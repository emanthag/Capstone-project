// Controllers/AdminController.cs
public class AdminController
{
    public string ViewDashboard(User user)
    {
        if (!AuthorizationService.UserHasRole(user, "admin"))
            throw new UnauthorizedAccessException("Access denied.");

        return "Welcome to the Admin Dashboard.";
    }
}
