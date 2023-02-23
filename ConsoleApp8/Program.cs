using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

internal class Program
{

	internal static void Main(string[] args)
	{
		string token = "";
		long kateChatId = 0;

		ComplimentBot bot = new ComplimentBot(token, kateChatId);
		bot.StartComplimentTimer();
		Console.ReadKey();
	}
}
