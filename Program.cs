using NumberInterpreter.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Map("/interpret", interpretApp =>
{
    interpretApp.UseMiddleware<ParseNumberMiddleware>();
    interpretApp.UseMiddleware<SignMiddleware>();
    interpretApp.UseMiddleware<ThousandsMiddleware>();
    interpretApp.UseMiddleware<HundredsMiddleware>();
    interpretApp.UseMiddleware<TensUnitsMiddleware>();
    interpretApp.UseMiddleware<FinalizeMiddleware>();
});

app.Run();
