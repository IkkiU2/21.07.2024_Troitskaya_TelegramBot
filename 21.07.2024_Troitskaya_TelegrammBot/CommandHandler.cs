using PRTelegramBot.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using PRTelegramBot.Helpers.TG;
using PRTelegramBot.Models;
using Telegram.Bot.Types.ReplyMarkups;
using PRTelegramBot.Models.CallbackCommands;
using PRTelegramBot.Models.InlineButtons;
using PRTelegramBot.Models.Interface;
using System.Runtime.InteropServices;

namespace _21._07._2024_Troitskaya_TelegrammBot
{
    public class CommandHandler
    {
        [ReplyMenuHandler(true, "/start")]
        public static async Task Example(ITelegramBotClient botStart, Update updateStart)
        {
            var message = "Hello world, введите команду Меню";
            var sendMessageStart = await PRTelegramBot.Helpers.Message.Send(botStart, updateStart, message);
        }
        [ReplyMenuHandler(true, "Меню")]
        public static async Task Menu(ITelegramBotClient botMenu, Update updatMenu)
        {
            var message = "Меню";

            var menuList = new List<KeyboardButton>();
            var menuListString = new List<string>();

            List<IInlineContent> menu = new List<IInlineContent>();

            var exampleOne = new InlineCallback<EntityTCommand<long>>("hello", CustomerTHeader.ExampleOne, new EntityTCommand<long>(5));
            var exampleTwo = new InlineCallback<EntityTCommand<long>>("help", CustomerTHeader.ExampleTwo, new EntityTCommand<long>(3));
            var exampleThree = new InlineCallback<EntityTCommand<long>>("inn", CustomerTHeader.ExampleThree, new EntityTCommand<long>(3));
            var exampleFour = new InlineCallback<EntityTCommand<long>>("last", CustomerTHeader.ExampleFour, new EntityTCommand<long>(3));

            menu.Add(exampleOne);
            menu.Add(exampleTwo);
            menu.Add(exampleThree);
            menu.Add(exampleFour);

            var menuItems = MenuGenerator.InlineKeyboard(1, menu);

            var optins = new OptionMessage();
            optins.MenuInlineKeyboardMarkup = menuItems;

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botMenu, updatMenu, message, optins);

        }
        [InlineCallbackHandler<CustomerTHeader>(CustomerTHeader.ExampleOne)]
        public static async Task ButtonHello(ITelegramBotClient botButtons, Update updatButtons)
        {
            var messageFIO = "ФИО: Троицкая Мария Евдокимовна ";
            var messageGitHib = "Ссылка на GitHub: ";
            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botButtons, updatButtons, messageFIO);
            var sendMessage2 = await PRTelegramBot.Helpers.Message.Send(botButtons, updatButtons, messageGitHib);
        }

        [ReplyMenuHandler(true, "/hello")]
        public static async Task ExampleHello(ITelegramBotClient botButtons, Update updatButtons)
        {
            var messageFIO = "ФИО: Троицкая Мария Евдокимовна ";
            var messageGitHib = "Ссылка на GitHub: ";
            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botButtons, updatButtons, messageFIO);
            var sendMessage2 = await PRTelegramBot.Helpers.Message.Send(botButtons, updatButtons, messageGitHib);
        }

        [ReplyMenuHandler(true, "/inn")]
        public static async Task ExampleInn(ITelegramBotClient botButtons, Update updatButtons)
        {
            
        }

        [ReplyMenuHandler(true, "/help")]
        public static async Task ExampleHelp(ITelegramBotClient botButtons, Update updatButtons)
        {
            var message = "/hello - вывод информация о пользователе\n" +
                          "/help - вывод справочной информации о боте\n" +
                          "/inn - вывод ИНН компаний и адресов\n" +
                          "/last - повторение последнего действия бота";
            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botButtons, updatButtons, message);
        }

        [InlineCallbackHandler<CustomerTHeader>(CustomerTHeader.ExampleTwo)]
        public static async Task ButtonHelp(ITelegramBotClient botButtons, Update updatButtons)
        {
            var message = "/hello - вывод информация о пользователе\n" +
                          "/help - вывод справочной информации о боте\n" +
                          "/inn - вывод ИНН компаний и адресов\n" +
                          "/last - повторение последнего действия бота";
            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botButtons, updatButtons, message);
        }
        [InlineCallbackHandler<CustomerTHeader>(CustomerTHeader.ExampleThree)]
        public static async Task ButtonInn(ITelegramBotClient botButtons, Update updatButtons)
        {
            var message = updatButtons.Message;
            var messageFIO = "Введите ИНН компании: " + message;
            //CompanyData.Program 
            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botButtons, updatButtons, messageFIO);
        }
    }
}
