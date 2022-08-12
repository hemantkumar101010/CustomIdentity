using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Asp.NetCoreIdentityCustom.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using Asp.NetCoreIdentityCustom.Services;
using Asp.NetCoreIdentityCustom.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<IdentityApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


//builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddDefaultUI().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultUI().AddEntityFrameworkStores<IdentityApplicationDbContext>();

builder.Services.AddAuthorization(o => { o.AddPolicy("readonlypolicy", builder => builder.RequireRole("Admin", "Clerk", "Manager"));
    o.AddPolicy("writepolicy", builder => builder.RequireRole("Admin","Clerk"));

});
builder.Services.AddScoped<Employees>();
builder.Services.AddScoped<EmployeeServices>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
