using LiveMessageAPI.Data;
using LiveMessageAPI.Hubs;
using LiveMessageAPI.Interfaces;
using LiveMessageAPI.Services;
using Microsoft.AspNetCore.Hosting.Server;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var conString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configuração do banco de dados com MySQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(conString, new MySqlServerVersion(new Version(8, 0, 5)), mysqlOptions =>
    {
        mysqlOptions.EnableRetryOnFailure();
    });
});


// Configuração das services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<ConversationService>();
builder.Services.AddScoped<NotificationService>();


builder.Services.AddControllers();
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Aplicar as migrações do banco de dados (opcional)
////using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var dbContext = services.GetRequiredService<ApplicationDbContext>();
//    dbContext.Database.Migrate();
//}


// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler(
    new ExceptionHandlerOptions()
    {
        AllowStatusCode404Response = true, // important!
        ExceptionHandlingPath = "/error"
    }
  );
}
app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

app.UseHsts();

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chatHub");
    endpoints.MapControllers();
});

app.Run();

