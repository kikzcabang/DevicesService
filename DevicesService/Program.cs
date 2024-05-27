using DevicesService.Hubs;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var hosts = builder.Configuration.GetValue<string>("AllowedCorsHosts").Split(',');




builder.Services.AddSignalR(options => { 
    options.EnableDetailedErrors = true;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins(hosts)
                .AllowAnyHeader()
                .WithMethods("GET", "POST")
                .AllowCredentials();
        });
});


builder.Services.AddRouting(o => { o.LowercaseUrls = true; });


var x = builder.Environment;



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions() 
{
    OnPrepareResponse = context =>
    {
        context.Context.Response.Headers["Access-Control-Allow-Origin"] = "*";
    }
}); // allow wwwroot with CORS


app.UseDeveloperExceptionPage(); // exception page
app.UseCors(); // allow CORS

//app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();


app.MapHub<DevicesHub>("/DevicesHub"); // Map SignalR 


app.Run();
