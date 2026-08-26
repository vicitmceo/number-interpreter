using Microsoft.AspNetCore.Http;

namespace NumberInterpreter.Middlewares;

public class ParseNumberMiddleware
{
    private readonly RequestDelegate _next;

    public ParseNumberMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var raw = context.Request.Query["number"].ToString();

        if (string.IsNullOrEmpty(raw))
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new { error = "Параметр \"number\" є обов'язковим" });
            return;
        }

        if (!int.TryParse(raw, out var number))
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new { error = "Параметр \"number\" має бути цілим числом" });
            return;
        }

        if (number < -100000 || number > 100000)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new { error = "Число має бути в діапазоні від -100000 до 100000" });
            return;
        }

        context.Items["OriginalNumber"] = number;
        context.Items["Num"] = Math.Abs(number);
        context.Items["Words"] = new List<string>();

        await _next(context);
    }
}
