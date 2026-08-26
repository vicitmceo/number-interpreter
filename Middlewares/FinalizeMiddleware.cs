using Microsoft.AspNetCore.Http;

namespace NumberInterpreter.Middlewares;

public class FinalizeMiddleware
{
    private readonly RequestDelegate _next;

    public FinalizeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var originalNumber = (int)context.Items["OriginalNumber"]!;
        var words = (List<string>)context.Items["Words"]!;

        if (words.Count == 0)
        {
            words.Add("нуль");
        }

        var result = string.Join(' ', words);

        await context.Response.WriteAsJsonAsync(new { number = originalNumber, result });
    }
}
