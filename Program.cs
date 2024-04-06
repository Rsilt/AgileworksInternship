var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapPost("/api/v1/appeal", (RequestBody requestBody) =>
{
    Console.WriteLine(requestBody.complaintText);
    return requestBody;
});

app.Run();

public class RequestBody
{
    public int complaintType { get; set; }
    public string complaintText { get; set; }
}