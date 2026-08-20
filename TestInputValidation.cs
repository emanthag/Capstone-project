// Tests/TestInputValidation.cs
using NUnit.Framework;
using System;

[TestFixture]
public class TestInputValidation
{
    [Test]
    public void TestForSQLInjection()
    {
        // Attempt a classic SQL injection payload
        var maliciousUsername = "admin'; DROP TABLE Users; --";

        // Expect sanitization to remove dangerous characters
        var sanitized = InputValidator.SanitizeUsername(maliciousUsername);

        // Should not contain quotes or semicolons
        Assert.IsFalse(sanitized.Contains("'"));
        Assert.IsFalse(sanitized.Contains(";"));
        Assert.IsFalse(sanitized.Contains("--"));
        Assert.IsNotEmpty(sanitized);
    }

    [Test]
    public void TestForXSSInUsername()
    {
        var maliciousUsername = "<script>alert('xss')</script>";

        var sanitized = InputValidator.SanitizeUsername(maliciousUsername);

        // Script tags should be stripped out
        Assert.IsFalse(sanitized.Contains("<script>"));
        Assert.IsFalse(sanitized.Contains("</script>"));
        Assert.IsNotEmpty(sanitized);
    }

    [Test]
    public void TestForXSSInEmail()
    {
        var maliciousEmail = "user@example.com<script>alert('xss')</script>";

        // Invalid format due to script tag, should throw
        Assert.Throws<ArgumentException>(() =>
        {
            InputValidator.SanitizeEmail(maliciousEmail);
        });
    }
}
