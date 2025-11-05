using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Project.Web.Net.Mvc.Data;
using Project.Web.Net.Mvc.Filters;
//using Project.Web.Net.Mvc.Middlewares;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("MyDbCon"),
    new MySqlServerVersion(new Version(8,0,36))
    ));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ErrorFilter>();

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

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

#region The MapWhen() Example
//app.MapWhen(context => context.Request.Query.ContainsKey("name"), app =>
//{

//    app.Use(async(context, next) =>
//    {
//        await next();
//    });

//    app.Run(async context =>
//    {
//        await context.Response.WriteAsync("Heyyo");
//    });

//});
#endregion

//app.UseMiddleware<WhiteIPControlMiddleware>();

app.UseAuthorization();

#region Contrubution themed Routing
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Dictionary}/{action=ContentsIndex}/{id?}"
//    );
#endregion

app.MapControllers();

app.Run();
