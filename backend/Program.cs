using backend.Data;
using backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------
// Add DbContext with SQLite
// ---------------------------
builder.Services.AddDbContext<ImprovDbContext>(options =>
    options.UseSqlite("Data Source=improv.db"));

// ---------------------------
// Register Services
// ---------------------------
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAppreciationService, AppreciationService>();
builder.Services.AddScoped<ISelfEvaluationService, SelfEvaluationService>();

// ---------------------------
// Add Controllers
// ---------------------------
builder.Services.AddControllers();

// ---------------------------
// Configure CORS
// ---------------------------
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// ---------------------------
// Swagger (OpenAPI)
// ---------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------------------------
// Build the app
// ---------------------------
var app = builder.Build();

// ---------------------------
// Middleware
// ---------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

// If you later add JWT auth, add:
// app.UseAuthentication();
// app.UseAuthorization();

app.UseCors();

app.MapControllers();

// ---------------------------
// Run the app
// ---------------------------
app.Run();
