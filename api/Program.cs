using Api.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/{zipcode}", (string zipcode) =>
{
	var apiKey = app.Configuration["weather:apiKey"]!;
	var cliant = new WeatherApiCliant(apiKey);
	var serializedCliant = JsonSerializer.Deserialize<WeatherApiCliant.WeatherData>(cliant.GetWeather(zipcode));
	return serializedCliant;
});

app.Run();