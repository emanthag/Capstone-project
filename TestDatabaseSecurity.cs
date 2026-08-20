// Tests/TestDatabaseSecurity.cs
using NUnit.Framework;

[TestFixture]
public class TestDatabaseSecurity
{
    [Test]
    public void ParameterizedQueryShouldNotExecuteInjectedSQL()
    {
        var maliciousUsername = "admin'; DROP TABLE Users; --";
        var safeUsername = InputValidator.SanitizeUsername(maliciousUsername);

        // If this throws due to SQL syntax, your query is not properly parameterized
        Assert.DoesNotThrow(() =>
        {
            UserRepository.InsertUser(safeUsername, "test@example.com");
        });
    }
}
