using Infrastructure.TaskContens;
using Microsoft.EntityFrameworkCore;
using Application.Interface;
using Infrastructure.Repository;
using Application.DrivingTask;
using Application.DrivingTask.Services;
using Infrastructure.services;
using Application.SendTaskEmail;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaskContext>(Options =>
{
    Options.UseOracle(builder.Configuration.GetConnectionString("Conexion"),
         b => b.MigrationsAssembly("TaskOpiTech"));
});

// AddScoped 
builder.Services.AddScoped<IRepository, TaskRepository>();
builder.Services.AddScoped<ICreateTask, CreateTask>();
builder.Services.AddScoped<IGetOneTask, GetOneTask>();
builder.Services.AddScoped<IGetTask, GetTask>();
builder.Services.AddScoped<IUpdateTask, UpdateTask>();
builder.Services.AddTransient<ISendEmail>(b => {
    string apiKey = b.GetRequiredService<IConfiguration>().GetValue<string>("emailKey");
    return new SendEmail(apiKey);
});

builder.Services.AddTransient<IEmailSend, EmailSend>();

builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

//builder.Services.AddHostedService<Worker>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowWebapp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
