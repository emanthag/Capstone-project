// Tests/TestSqlInjectionFix.cs
using NUnit.Framework;

[TestFixture]
public class TestSqlInjectionFix
{
    [Test]
    public void SqlInjectionShouldNotBreakQuery()
    {
        var malicious = "admin'; DROP TABLE Users; --";
        var sanitized = InputValidator.SanitizeUsername(malicious);

        Assert.DoesNotThrow(() =>
        {
            UserRepository.GetUserByUsername(sanitized);
        });
    }
}
