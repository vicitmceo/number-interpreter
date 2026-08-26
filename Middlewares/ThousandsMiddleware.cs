using Microsoft.AspNetCore.Http;
using NumberInterpreter.Extensions;

namespace NumberInterpreter.Middlewares;

public class ThousandsMiddleware
{
    private readonly RequestDelegate _next;

    public ThousandsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var num = (int)context.Items["Num"]!;
        var words = (List<string>)context.Items["Words"]!;

        var thousands = num / 1000;

        if (thousands > 0)
        {
            words.AddRange(thousands.ConvertTriplet(true));
            words.Add(thousands.ThousandWord());
        }

        context.Items["Num"] = num % 1000;

        await _next(context);
    }
}
