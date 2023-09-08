using ITB.Cse.Project.WebUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebUIRegistration(hostBuilder: builder.Host);//HangfireApp Layer => Add IoC(DI) Services Collection

var app = builder.Build();// => BuildServiceProvider()

app.UseWebUIMiddleware();//HangfireApp Layer => Use Middleware Settings
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();// Application Start