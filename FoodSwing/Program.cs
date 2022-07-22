
using Serilog;
using Microsoft.EntityFrameworkCore;
using DbAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration.GetConnectionString("FoodSwingContextConnection") ?? throw new InvalidOperationException("Connection string 'FoodSwingContextConnection' not found.");

// builder.Services.AddDbContext<FoodSwingContext>(options =>
//     options.UseSqlServer(connectionString));;

// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<FoodSwingContext>();;


// Add services to the container.

// Add services to the container.

IConfiguration Configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
.AddEnvironmentVariables()
.AddCommandLine(args)
.Build();


// ---------log File--------
builder.Host.UseSerilog((hostingcontaxt, loggerConfig) =>

loggerConfig.ReadFrom.Configuration(hostingcontaxt.Configuration)

);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<FoodSwingContext>(options => options.UseSqlServer(
    Configuration.GetConnectionString("FoodSwing")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedEmail = true).AddEntityFrameworkStores<FoodSwingContext>();
builder.Services.AddRazorPages();
builder.Host.UseSerilog((hostingContext, loggerConfig) =>
            loggerConfig.ReadFrom.Configuration(hostingContext.Configuration)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



