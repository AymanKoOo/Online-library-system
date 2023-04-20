using Core.Entites;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repo.Base;
using Infrastructure.Repo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Infrastructure.Services;
using Web.Areas.Admin.Factories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<DataContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("EcoMeraceDb")));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<DataContext>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    options.SlidingExpiration = true;
});


builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));

builder.Services.AddScoped(typeof(IPictureRepo), typeof(PictureRepo));
builder.Services.AddScoped(typeof(IHoldRepo), typeof(HoldRepo));
builder.Services.AddScoped(typeof(IBookRepo), typeof(BookRepo));
builder.Services.AddScoped(typeof(IBorrowingRepo), typeof(BorrowingRepo));


builder.Services.AddScoped(typeof(IPictureService), typeof(PictureService));
builder.Services.AddScoped(typeof(ISlugService), typeof(SlugService));

builder.Services.AddScoped(typeof(IBookModelFactory), typeof(BookModelFactory));
builder.Services.AddScoped(typeof(IHoldModelFactory), typeof(HoldModelFactory));


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

app.UseCors("policyName");
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
       name: "areaRoute",
       pattern: "{area:exists}/{controller=AdminHome}/{action=Index}/{id?}"
     );

    endpoints.MapControllerRoute(
         name: "defualtRoute",
         pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
