using Microsoft.AspNetCore.Http;
using NumberInterpreter.Extensions;

namespace NumberInterpreter.Middlewares;

public class TensUnitsMiddleware
{
    private readonly RequestDelegate _next;

    public TensUnitsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var rest = (int)context.Items["Num"]!;
        var words = (List<string>)context.Items["Words"]!;

        if (rest >= 10 && rest < 20)
        {
            words.Add(Dictionaries.Teens[rest - 10]);
        }
        else
        {
            var t = rest / 10;
            var u = rest % 10;
            if (t > 0) words.Add(Dictionaries.Tens[t]);
            if (u > 0) words.Add(Dictionaries.UnitsMasculine[u]);
        }

        await _next(context);
    }
}
