using FeedbackApi.Models;
using FeedbackApi.Services;
using FeedbackApi.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Read allowed origins from appsettings.json
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? new string[] { };

// ✅ Add CORS policy dynamically
builder.Services.AddCors(options =>
{
    options.AddPolicy("DynamicCorsPolicy", policy =>
    {
        if (allowedOrigins.Length > 0)
        {
            policy.WithOrigins(allowedOrigins)
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials(); // ✅ Needed for cookies/tokens
        }
        else
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        }
    });
});

// ✅ Add controllers and filters
builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

// ✅ Register required services in DI
builder.Services.AddScoped<HttpResponseExceptionFilter>();
builder.Services.AddScoped<FdBkConfigService>();
builder.Services.AddScoped<OrderService>(); // ✅ Ensure OrderService is registered

// ✅ Configure database connection
builder.Services.AddDbContext<FeedbackDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Add Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Feedback API",
        Version = "v1",
        Description = "API for handling feedback and order details"
    });
    c.EnableAnnotations();
});

// ✅ Build application
var app = builder.Build();

// ✅ Apply CORS **BEFORE** Routing & Authorization
app.UseCors("DynamicCorsPolicy");

// ✅ Serve Static Files
app.UseStaticFiles();

// ✅ Enable Swagger UI & API Documentation
if (app.Environment.IsDevelopment() || true) // Ensure Swagger works in production
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "swagger/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Feedback API v1");
        c.RoutePrefix = "swagger"; // Swagger UI at /swagger
    });
}

// ✅ Apply Middleware Pipeline
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// ✅ Run the application
app.Run();
