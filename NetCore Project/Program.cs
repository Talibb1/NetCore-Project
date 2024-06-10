using Service.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// add service Extension
builder.Services.LoadService(builder.Configuration);


var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "Api",
     pattern: "api/{controller=Category}/{action=GetList}/{id?}"

);

app.Run();
