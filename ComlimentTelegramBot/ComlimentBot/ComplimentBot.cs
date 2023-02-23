namespace ComlimentTelegramBot;

using ConsoleApp8.Contracts;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

public class ComplimentBot
{
	private readonly TelegramBotClient _bot;



	public ComplimentBot(string token)
	{
		_bot = new TelegramBotClient(token);
		_bot.ReceiveAsync<ComlimetReciver>();
	}

	public async Task GeneraterAndSendComliment()
	{
		Random random = new Random();
		int index = random.Next(9);
		if (index != 2)
			return;
		try
		{
			var comliment= await ComlimentHelper.GeneraterAndSendComliment();
			await _bot.SendTextMessageAsync(
			chatId: Secrets.Default.KateChatId,
			text: comliment
		);
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
