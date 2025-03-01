using poc.api.redis.Configuration;
using poc.api.redis.EndPoints;
using poc.api.redis.Service;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddConnections();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig(builder.Configuration);


// Redis
builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(builder.Configuration.GetSection("Redis:Configuration").Value)
);
//builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConfiguration));

// Repository
builder.Services.AddScoped<ISendService, SendService>();

var app = builder.Build();

app.UseHttpsRedirection();

// Configura middlewere
app.UseStatusCodePages(async statusCodeContext => await Results.Problem(statusCode: statusCodeContext.HttpContext.Response.StatusCode).ExecuteAsync(statusCodeContext.HttpContext));



#region Conttroller
app.RegisterSendEndpoints();
#endregion



app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();