using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Data.Sqlite;
using System;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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

app.MapPost("/api/v1/appeal", (PostRequestBody requestBody) =>
{
    Console.WriteLine(requestBody.complaintText);

    using (var connection = new SqliteConnection("Data Source=/Users/rolandsilt/desktop/AgileWorksINternship/agile.db"))
    {
        connection.Open();

        var command = connection.CreateCommand();
        //https://stackoverflow.com/questions/60364847/how-to-insert-values-with-foreign-key-in-sqlite/60365480#60365480
        command.CommandText =
        @"
            INSERT INTO agile (description, time_of_appeal, appeal_deadline, is_solved, appeal_type_id)
            VALUES ($description, $timeOfAppeal, $appealDeadline, $isSolved, $appealTypeId)
        ";

        //siin kasuta docsi https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlparametercollection.addwithvalue?view=dotnet-plat-ext-8.0
        command.Parameters.AddWithValue("$description", requestBody.complaintText);
        command.Parameters.AddWithValue("$timeOfAppeal", DateTime.Now);
        command.Parameters.AddWithValue("$appealDeadline", DateTime.Now.AddHours(24));
        command.Parameters.AddWithValue("$isSolved", false);
        command.Parameters.AddWithValue("$appealType", requestBody.ComplaintType);

        command.ExecuteNonQuery();
    }

    return requestBody;
});

app.MapGet("/api/v1/appeal", () =>
{
    using (var connection = new SqliteConnection("Data Source=/Users/rolandsilt/desktop/AgileWorksINternship/agile.db"))
    {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        @"
            SELECT * FROM agile ORDER BY appeal_deadline DESC;
        ";

        using (var reader = command.ExecuteReader())
        {
            var response = new List<GetRequestResponse>();

            while (reader.Read())
            {
                Console.WriteLine(reader.Read());
                response.Add(new GetRequestResponse
                {
                    Description = reader.GetString(0),
                    TimeOfAppeal = reader.GetDateTime(1),
                    AppealDeadline = reader.GetDateTime(2),
                    IsSolved = reader.GetBoolean(3),
                    AppealType = reader.GetInt32(4)
                });
            }

            return Results.Ok(response);
        }
    }
});





app.Run();

public class PostRequestBody // KUI error pane Requestbody
{
    public int ComplaintType { get; set; }
    public string complaintText { get; set; }
}

public class GetRequestResponse
{
    public string Description { get; set; }
    public DateTime TimeOfAppeal { get; set; }
    public DateTime AppealDeadline { get; set; }
    public bool IsSolved { get; set; }
    public int AppealType { get; set; }
}

