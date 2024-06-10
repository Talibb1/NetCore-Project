using Service.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Inject Service extension
builder.Services.LoadService(builder.Configuration);


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        areaName: "Admin",
        name: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"

        );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"

        );

});

app.Run();
