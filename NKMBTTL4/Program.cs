var builder = WebApplication.CreateBuilder(args);

// ==================================================
// ĐĂNG KÝ MVC
// ==================================================

builder.Services.AddControllersWithViews();

var app = builder.Build();


// ==================================================
// CẤU HÌNH HTTP PIPELINE
// ==================================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}


// HTTPS
app.UseHttpsRedirection();


// Cho phép sử dụng wwwroot
app.UseStaticFiles();


// Routing
app.UseRouting();


// Authorization
app.UseAuthorization();


// ==================================================
// MVC ROUTE
// ==================================================

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();