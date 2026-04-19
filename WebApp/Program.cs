using DataAccess;
using DataAccess.Repositories.Wheel;
using Masha.Services;
using Microsoft.Build.Execution;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddScoped<ViewRendererService>();

// Repositories
builder.Services.AddScoped<WheelListRepository>();
builder.Services.AddScoped<WheelItemRepository>();
builder.Services.AddScoped<SchemeRepository>();
builder.Services.AddScoped<SchemeItemRepository>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
