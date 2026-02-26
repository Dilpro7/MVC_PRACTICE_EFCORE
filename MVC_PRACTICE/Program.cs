using Microsoft.EntityFrameworkCore;
using MVC_PRACTICE.Context;
using MVC_PRACTICE.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



//whenever IEmployeeRepo will be called then it will give object of EmployeeRepo.
//Here IEmployeeRepository is the parent for EmployeeRepository,
//so it's object is passed to the controller when it gets the request of IEmployeeRepo
//      <--     THIS PROCESS IS CALLED DEPENDENCY INJECTION   -->
// IN SIMPLE WORDS DEPENDENCY INJECTION MEANS ASSIGNING AN INTERFACE TO ANOTHER 
//builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IEmployeeRepository, SqlEmployeeRepository>();


// Dependency Injection for EmployeeDBContext
builder.Services.AddScoped<EmployeeDbContext, EmployeeDbContext>();

//Setting options or passing options for DbContext..
builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
