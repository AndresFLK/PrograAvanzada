using Aplication;
using Aplication.Students;
using Domain.Configuration;
using Infrastructure;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddAplicationServices(builder.Configuration);


var endpoints = builder.Configuration.GetSection(nameof(EndpointConfiguration)).Get<List<EndpointConfiguration>>();

builder.Services.Configure<List<EndpointConfiguration>>(options => {
    options.AddRange(endpoints);
});   

builder.Services.AddHttpClient<IStudentClient, StudentClient>((provider, client) =>
{
    var endpoint = endpoints.Where(s => s.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
    client.BaseAddress = new Uri(endpoint.Uri);
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
