using Microsoft.AspNetCore.Http;
using NumberInterpreter.Extensions;

namespace NumberInterpreter.Middlewares;

public class HundredsMiddleware
{
    private readonly RequestDelegate _next;

    public HundredsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var num = (int)context.Items["Num"]!;
        var words = (List<string>)context.Items["Words"]!;

        var h = num / 100;

        if (h > 0)
        {
            words.Add(Dictionaries.Hundreds[h]);
        }

        context.Items["Num"] = num % 100;

        await _next(context);
    }
}
