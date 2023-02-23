namespace ComlimentTelegramBot;
internal class Program
{
	internal static void Main(string[] args)
	{
		ComplimentBot bot = new ComplimentBot(Secrets.Default.Token);
		bot.StartComplimentTimer();
		while (true)
		{
			Console.ReadLine();
		}
	}
}
