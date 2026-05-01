using TestContainerSampleApp;

var builder = WebApplication.CreateBuilder(args);



var app = builder.Build();

app.MapGet("/sample", () => "Hello World!");

app.UseHttpsRedirection();


app.Run();

public record Coder(int Id, string Name, string Language, string Architecture, bool IsVibeCoder);
