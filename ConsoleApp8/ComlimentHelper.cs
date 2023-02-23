using ConsoleApp8.Contracts;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

internal static class ComlimentHelper
{
	public static async Task<string> GetComliment()
	{
		using (var client = new HttpClient())
		{
			var response = await client.GetAsync("https://complimentr.com/api");
			if (response.IsSuccessStatusCode)
			{
				var compliment = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<Comliment>(compliment).Compliment;
			}
			else
			{
				throw new ApplicationException( $"Error retrieving compliment: {response.StatusCode}");
			}
		}
	}
}