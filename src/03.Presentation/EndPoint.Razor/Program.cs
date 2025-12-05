using App.Domain.AppServices.PostAggApp;
using App.Domain.AppServices.UserAggApp;
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
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(@"Server=DESKTOP-LO9POA3\SQLEXPRESS;Database=Weblog;Integrated Security = true;Encrypt=True;TrustServerCertificate=True;");
});
builder.Services.AddScoped<ICookieService, CookieService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserService , UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryService , CategoryService>();
builder.Services.AddScoped<IPostAppService, PostAppService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

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
