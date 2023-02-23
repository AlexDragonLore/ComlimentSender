using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

public class ComplimentBot
{
	private readonly TelegramBotClient _bot;
	private readonly long _kateChatId; // the ID of Kate's chat with the bot

	private readonly string[] compliments = {
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

	public ComplimentBot(string token, long kateChatId)
	{
		_bot = new TelegramBotClient(token);
		_kateChatId = kateChatId;
	}

	public async Task SendCompliment(string comlimetn)
	{
		// Select a random compliment
		

		// Send the compliment to Kate's chat with the bot
		await _bot.SendTextMessageAsync(
			chatId: _kateChatId,
			text: comlimetn
		);
	}

	public async Task GeneraterAndSendComliment()
	{
		Random random = new Random();
		int index = random.Next(9);
		if (index != 2)
			return;

		index = random.Next(compliments.Length);
		string name = compliments[index];

		try
		{
			var comliment= await ComlimentHelper.GetComliment();
			await SendCompliment($"{name}, {comliment}");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{DateTime.Now} Errror - {ex}");
		}
	}

	public void StartComplimentTimer()
	{
		TimeSpan interval = TimeSpan.FromMinutes(37);
		Timer timer = new Timer(async state => await GeneraterAndSendComliment(), null, TimeSpan.Zero, interval);
	}


}
