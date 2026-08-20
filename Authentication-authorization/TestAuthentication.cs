// Tests/TestAuthentication.cs
using NUnit.Framework;

[TestFixture]
public class TestAuthentication
{
    [Test]
    public void InvalidPasswordShouldFail()
    {
        var hashed = AuthService.HashPassword("CorrectPassword");

        Assert.IsFalse(AuthService.VerifyPassword("WrongPassword", hashed));
    }

    [Test]
    public void ValidPasswordShouldPass()
    {
        var hashed = AuthService.HashPassword("CorrectPassword");

        Assert.IsTrue(AuthService.VerifyPassword("CorrectPassword", hashed));
    }
}
