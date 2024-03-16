using Order.OrderAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddDependencyInjectionConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//TODO: Connection String eklenecek.

//TODO: UnitTest yazýlacak.

//TODO: Jenkinsde CI sürecine testler baðlanacak.

//TODO: EventSourcing implemente edilecek. EventStore

//TODO: FluentApi valueobjectler.

//TODO: EDD evet

//TODO: TDD?

//TODO: Saga Pattern!

//