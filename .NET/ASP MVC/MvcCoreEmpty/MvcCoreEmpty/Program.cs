var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(name: "dafault", pattern: "{controller=Home}/{action=Index}");

app.Run();
