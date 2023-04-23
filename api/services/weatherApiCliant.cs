namespace Api.Services;

public class WeatherApiCliant
{
	private readonly string apiKey;

	public WeatherApiCliant(string ApiKey)
	{
		this.apiKey = ApiKey;
	}
	public string GetWeather(string zipcode)
	{
		var httpClient = new HttpClient();
		var url = $"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={zipcode}&aqi=no";
		var response = httpClient.GetAsync(url).Result;

		return response.Content.ReadAsStringAsync().Result;
	}

	public class WeatherData
	{
		public string? name { get; set; }
		public string? region { get; set; }

		public string? country { get; set; }
		public double? temp_f { get; set; }
	}

}