using System.Diagnostics;
using System.Text.RegularExpressions;

namespace XpressTest.Narration;

public static class TitleProvider
{
    public static string Get()
    {
        var stackTrace = new StackTrace();
        
        var unprocessedTitle = stackTrace.GetFrame(3).GetMethod().Name;

        var processedTitle = Regex.Replace(
                unprocessedTitle,
                "(?<=[a-z])([A-Z])",
                " $1",
                RegexOptions.Compiled)
            .Trim();

        return processedTitle;
    }
}