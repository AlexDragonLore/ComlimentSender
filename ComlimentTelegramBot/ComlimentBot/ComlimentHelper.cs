namespace ComlimentTelegramBot;

using ConsoleApp8.Contracts;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

internal static class ComlimentHelper
{
	private static string[] _compliments = {
		  $"My dear Kate",
			"Rudich",
			"Kate Rudich",
			"Kate",
			"Katie",
			"Kat",
			"Katherine",
			"Katya",
			"Dear",
			"Love",
			"Sweetie",
			"Honey",
			"Darling",
			"Angel",
	};
	public static async Task<string> GeneraterAndSendComliment()
	{
		Random random = new Random();
		int index = random.Next(_compliments.Length);
		string name = _compliments[index];


		var comliment = await GetComliment();
		return  $"{name}, {comliment}";
	}

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