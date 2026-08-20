// Tests/TestAuthorization.cs
using NUnit.Framework;

[TestFixture]
public class TestAuthorization
{
    [Test]
    public void NonAdminShouldBeDenied()
    {
        var user = new User { Role = "user" };

        Assert.Throws<UnauthorizedAccessException>(() =>
        {
            new AdminController().ViewDashboard(user);
        });
    }

    [Test]
    public void AdminShouldAccessDashboard()
    {
        var user = new User { Role = "admin" };

        var result = new AdminController().ViewDashboard(user);

        Assert.AreEqual("Welcome to the Admin Dashboard.", result);
    }
}
