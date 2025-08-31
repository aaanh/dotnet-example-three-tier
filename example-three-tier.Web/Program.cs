using Microsoft.EntityFrameworkCore;
using example_three_tier.Data;
using example_three_tier.Data.Repositories;
using example_three_tier.Business.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
  var conn = builder.Configuration.GetConnectionString("Default");
  if (builder.Environment.IsDevelopment())
    options.UseNpgsql(conn); // no retry
  else
    options.UseNpgsql(conn, o => o.EnableRetryOnFailure());
});

// Repositories & Services
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerService>();

// Controllers + Swagger + Razor Pages
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Example API", Version = "v1" });
});

// ✅ THIS IS MISSING
builder.Services.AddRazorPages();

var app = builder.Build();

// Check DB connectivity
using (var scope = app.Services.CreateScope())
{
  var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
  try
  {
    db.Database.CanConnect();
    Console.WriteLine("✅ Database connection successful");
  }
  catch (Exception ex)
  {
    Console.WriteLine("❌ Database not available: " + ex.Message);
  }
}

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();   // works only if AddRazorPages() was registered

app.Run();
