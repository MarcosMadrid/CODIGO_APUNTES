using ApiStorageTokens.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ServiceSasToken>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/testapi", () =>
{
    return "TstMinimalApi";
});

app.MapGet("/token/{curso}", (string curso, ServiceSasToken serviceSas) =>
{
    return
        new
        {
            accessUrl = serviceSas.GenerateToken(curso)
        };
});


app.Run();

