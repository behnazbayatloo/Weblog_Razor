using App.Domain.AppServices.CategoryAggApp;
using App.Domain.AppServices.PostAggApp;
using App.Domain.AppServices.UserAggApp;
using App.Domain.Core.CategoryAgg.AppServices;
using App.Domain.Core.CategoryAgg.Data;
using App.Domain.Core.CategoryAgg.Services;
using App.Domain.Core.PostAgg.AppServices;
using App.Domain.Core.PostAgg.Data;
using App.Domain.Core.PostAgg.Services;
using App.Domain.Core.UserAgg.AppServices;
using App.Domain.Core.UserAgg.Data;
using App.Domain.Core.UserAgg.Services;
using App.Domain.Services.CategoryAggSrv;
using App.Domain.Services.PostAggSrv;
using App.Domain.Services.UserAggSrv;
using App.Infra.Data.Db.SqlServer.Ef.DbCxt;
using App.Infra.Data.Repos.Ef.CategoryAgg;
using App.Infra.Data.Repos.Ef.PostAgg;
using App.Infra.Data.Repos.Ef.UserAgg;
using EndPoint.Razor.Extentions;
using Files.Contrcat;
using Files.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")) );

builder.Services.AddScoped<ICookieService, CookieService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserService , UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryAppService , CategoryAppService>();
builder.Services.AddScoped<IPostAppService, PostAppService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IFileService ,FileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
