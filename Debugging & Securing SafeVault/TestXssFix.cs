// Tests/TestXssFix.cs
using NUnit.Framework;

[TestFixture]
public class TestXssFix
{
    [Test]
    public void XssPayloadShouldBeEncoded()
    {
        var payload = "<script>alert('xss')</script>";
        var safe = InputValidator.SanitizeForXss(payload);

        Assert.IsFalse(safe.Contains("<script>"));
        Assert.IsTrue(safe.Contains("&lt;script&gt;"));
    }
}
