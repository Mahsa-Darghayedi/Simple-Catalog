using Catalog.API.Application.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceConfig(builder.Configuration.GetConnectionString("CatalogDB"));
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
