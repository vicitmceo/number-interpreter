using Microsoft.AspNetCore.Http;

namespace NumberInterpreter.Middlewares;

public class SignMiddleware
{
    private readonly RequestDelegate _next;

    public SignMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var originalNumber = (int)context.Items["OriginalNumber"]!;
        var words = (List<string>)context.Items["Words"]!;

        if (originalNumber < 0)
        {
            words.Add("мінус");
        }

        await _next(context);
    }
}
