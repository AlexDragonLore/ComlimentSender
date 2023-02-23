namespace ComlimentTelegramBot;

using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

internal class ComlimetReciver : IUpdateHandler
{
	public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}

	public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
	{
		if (update.Message == null)
			return;

		try
		{
			var comliment = await ComlimentHelper.GetComliment();
			
			await botClient.SendTextMessageAsync(chatId: update.Message.Chat.Id, $"{update.Message.Chat.FirstName + " " + update.Message.Chat.LastName}, {comliment}");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{DateTime.Now} Errror - {ex}");
		}
	}
}