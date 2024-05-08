using Microsoft.EntityFrameworkCore;
using Persistence;
using Application;

string AllowedSpecificOrigins = "_allowedSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

builder.Services.AddDbContext<VotingDbContext>(options =>
        options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Voting;Integrated Security=True")
          .LogTo(Console.WriteLine,
            new[]
            {
                      DbLoggerCategory.Database.Command.Name
            },
            LogLevel.Information)
          .EnableSensitiveDataLogging());

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddCors(options =>
{
  options.AddPolicy(AllowedSpecificOrigins,
    builder =>
    {
      var stringSplitChars = new char[] { ',', ';' };
      String[] origins = "http://localhost:7092;http://localhost:54082;http://localhost:4200".Split(stringSplitChars);
      foreach (string origin in origins)
      {
        builder.WithOrigins(origin);
      }
      builder.WithHeaders("*");
      builder.AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(AllowedSpecificOrigins);

app.MapControllers();

app.Run();
