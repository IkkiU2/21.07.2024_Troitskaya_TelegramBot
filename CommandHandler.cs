using Telegram.Bot;
using Telegram.Bot.Types;
using PRTelegramBot.Attributes;
using System;

public class CommandHandler
{
	public CommandHandler()
	{
        [ReplyMenuHandler(true, "Tecт")]
        public static async Task Example(ITelegramBotClient botClient, Update update)

        var message = "Hello world";
        var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message);
    }
}
