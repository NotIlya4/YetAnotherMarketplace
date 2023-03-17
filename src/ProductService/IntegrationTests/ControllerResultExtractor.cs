using Microsoft.AspNetCore.Mvc;

namespace IntegrationTests;

public class ControllerResultExtractor
{
    public static TResult Extract<TResult>(ActionResult<TResult> actionResult)
    {
        return (TResult)(((ObjectResult)actionResult.Result!).Value!);
    }
}