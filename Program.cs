using Microsoft.EntityFrameworkCore;
using miniZeiterfassung.Data;
using miniZeiterfassung.Models;
using miniZeiterfassung.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext with SQL Server support
builder.Services.AddDbContext<TimeRecordingContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("TimeRecordingContext")));

// This goes in ConfigureServices in Startup.cs or in the builder.Services configuration section in Program.cs
builder.Services.AddScoped<RecordService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
