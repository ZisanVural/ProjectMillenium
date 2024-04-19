using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectMillenium.Core.Extensions;
using ProjectMillenium.Core.Helpers;
using ProjectMillenium.Core.Mapping;
using ProjectMillenium.Core.Web;
using ProjectMillenium.Data.Context;
using ProjectMillenium.Data.Implements;
using ProjectMillenium.Data.Interfaces;
using ProjectMillenium.Web.Extensions;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllersWithViews(); 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Logging.AddConsole();

builder.Host.UseSerilog((context, configuration) =>
configuration.ReadFrom.Configuration(context.Configuration)); //serilog yapilandirmasi ve ayarlanmasi

builder.Services.AddRepositories();
builder.Services.AddHelpers();
builder.Services.AddBusinessService(); 
builder.Services.AddAutoMapper(typeof(UserProfile));


var app = builder.Build();


app.UseExceptionMiddleware();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();   
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();

