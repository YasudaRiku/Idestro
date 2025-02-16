using Idestro.Server.Data;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);


// NLog‚Ìİ’èî•ñ‚ªæ‚ê‚é‚æ‚¤‚Éappsetting.json‚ğ“Ç‚İ‚Ş
var config = new ConfigurationBuilder()
     .SetBasePath(System.IO.Directory.GetCurrentDirectory())
     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

// builder‚ÉNLog‚ğ’Ç‰Á‚·‚é
builder.Logging.AddNLog(new NLogLoggingConfiguration(config.GetSection("NLog")));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //’Ç‰Á

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(userEndPpoints =>
{
    userEndPpoints.MapControllers();
});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
