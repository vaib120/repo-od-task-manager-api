using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TaskContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), npgsqlOptions =>
{
    npgsqlOptions.CommandTimeout(60); // Timeout in seconds
}));

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
    policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Update with your frontend URL
    .AllowAnyHeader()
    .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TaskContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseCors("AllowSpecificOrigin"); // Use CORS policy in development
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();