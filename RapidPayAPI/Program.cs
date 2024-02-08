using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Net;
using Microsoft.EntityFrameworkCore;
using RapidPay.Database;
using RapidPay.Services;
using RapidPay.API;

var builder = WebApplication.CreateBuilder(args);
bool useInMemoryProvider = false;
string useInMemoryDB = string.Empty;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


try
{
    useInMemoryProvider = bool.Parse(builder.Configuration["AppSettings:InMemoryProvider"]);
    useInMemoryDB = builder.Configuration["AppSettings:InMemoryDBName"];
}
catch 
{ 

}

builder.Services.AddDbContext<RapidPayContext>(options => {
    switch (useInMemoryProvider)
    {
        case true:
            options.UseInMemoryDatabase(useInMemoryDB);
            break;
        default:
            options.UseSqlServer(connectionString);
            break;
    }
});

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

SchedulerDbInitializer.Initialize(app.Services);
app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
app.Run();

