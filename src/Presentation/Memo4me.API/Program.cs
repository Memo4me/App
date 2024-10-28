using Memo4me.Application.Interfaces.Repositories;
using Memo4me.Persistence.Extensions;
using Memo4me.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args); 
{
    var configuration = builder.Configuration;
    
    builder.Services.AddHttpClient();
    
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddPersistence(configuration.GetConnectionString("PostgresConnection"));
    builder.Services.AddScoped<IUserRepository, UserRepository>();
}

var app = builder.Build(); 
{
    
    if (app.Environment.IsDevelopment())
    {
        
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();
        
    app.MapControllers();

    app.Run();
}
        