﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    internal class Program
    {
        static TelegramBotClient bot;

        static string downloadPath = "download";

        static string token = System.IO.File.ReadAllText("meowsic.token");

        static void Main(string[] args)
        {


            #region 9.2 - через WebClient
            /*
            
            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };

            string startUrl = $@"https://api.telegram.org/bot{token}/";

            int update_id = 0;

            while (true)
            {
                string url = $"{startUrl}getUpdates?offset={update_id}";
                var jsonfile = wc.DownloadString(url);
                var results = JObject.Parse(jsonfile)["result"].ToArray();

                foreach(dynamic result in results)
                {
                    update_id = Convert.ToInt32(result.update_id) + 1;

                    string userMessage = result.message.text;
                    string userID = result.message.from.id;
                    string userFirstName = result.message.from.first_name;

                    string text = $"{userFirstName} {userID} {userMessage}";
                    Console.WriteLine(text);

                    if(userMessage == "hi")
                    {
                        string response = $"Привет, {userFirstName}";
                        url = $"{startUrl}sendMessage?chat_id={userID}&text={response}";
                        Console.WriteLine(wc.DownloadString(url));
                    }
                    if (userMessage == "\\start")
                    {
                        string response = $"Привет, {userFirstName}\nПока что бот может только реагировать на \\start, на hi и на мяу";
                        url = $"{startUrl}sendMessage?chat_id={userID}&text={response}";
                        Console.WriteLine(wc.DownloadString(url));
                    }
                    if (userMessage == "мяу")
                    {
                        string response = $"мяу";
                        url = $"{startUrl}sendMessage?chat_id={userID}&text={response}";
                        Console.WriteLine(wc.DownloadString(url));
                    }
                }

                Thread.Sleep(100);

            }

            */
            #endregion


            #region 9.3 - через TelegramBotClient
            
            bot = new TelegramBotClient(token);

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new UpdateType[]
                {
                    UpdateType.Message,
                    UpdateType.EditedMessage
                }
            };

            bot.StartReceiving(HandleUpdateAsync, ErrorHandler, receiverOptions);
            bot.AnswerCallbackQueryAsync("");
            Console.ReadLine();

            #endregion
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            //надо разобраться посылается ли callbackData, куда посылается, как ловить

            if (update.Type == UpdateType.CallbackQuery)
            {
                var files = ShowFiles(update);
                foreach (var fileInfo in files)
                {
                    if (fileInfo.Name == update.CallbackQuery.Data)
                    {
                        await bot.AnswerCallbackQueryAsync(callbackQueryId: fileInfo.Name);
                        await bot.SendDocumentAsync(update.Message.Chat, new InputMedia(fileInfo.OpenRead(), fileInfo.Name));
                    }
                }

            }
            if (update.CallbackQuery != null)
            {
                await bot.AnswerCallbackQueryAsync(callbackQueryId: update.CallbackQuery.Data, text: $"{update.CallbackQuery.Data}");
                Console.WriteLine(update.CallbackQuery.Data);
            }



            if (update.Type == UpdateType.Message)
            {
                
                switch (update.Message.Type)
                {
                    case MessageType.Audio:
                    case MessageType.Document:
                    case MessageType.Video:
                    case MessageType.Photo:
                        DownloadFile(bot, update);
                        break;
                    case MessageType.Text:
                        var message = update.Message;
                        switch (message.Text.ToLower())
                        {
                            case "/start":
                                await bot.SendTextMessageAsync(message.Chat, $"Привет, {update.Message.From.FirstName}" +
                                $"\nТекущий набор команд можно посмотреть по каманде /help");
                                break;

                            case "/help":
                                await bot.SendTextMessageAsync(message.Chat, "Текущий набор команд:" +
                                    "\n/help - выводит все доступный команды" +
                                    "\n/showlist - выводит все доступные файлы" +
                                    "\nТакже можно поздороваться с ботом" +
                                    "\nТакже можно помяукать с ботом");
                                break;

                            case "hi":
                            case "hello":
                            case "привет":
                                await bot.SendTextMessageAsync(message.Chat, $"Привет, " +
                                    $"{update.Message.From.FirstName}, рад тебя видеть");
                                break;

                            case "mew":
                            case "meow":
                            case "mrr":
                            case "mur":
                            case "мр":
                            case "мур":
                            case "мяу":
                            case "миу":
                                await bot.SendTextMessageAsync(message.Chat, message.Text.ToLower());
                                break;
                            case "pur":
                                await bot.SendTextMessageAsync(message.Chat, "https://purrli.com/");
                                break;
                            case "котя":
                                await bot.SendPhotoAsync(message.Chat, "https://thiscatdoesnotexist.com/"); //сайт возвращает только одну картинку
                                break;

                            case "/showlist":
                                SendList(bot, update);
                                break;
                            case "/inline":
                                await bot.SendTextMessageAsync(message.Chat, "idk how to catch callbackData");
                                SendInline(update, cancellationToken);
                                break;
                        }

                        if(message.Text.ToLower()[0] == '/' && message.Text.ToLower()[1] == '_')
                        {
                            string requestedFile = message.Text.ToLower().Substring(2);
                            var files = ShowFiles(update);
                            foreach (var fileInfo in files)
                            {
                                if (requestedFile == fileInfo.CreationTime.ToString("dd_MM_yyyy_HH_mm_ss"))
                                {
                                    await bot.SendDocumentAsync(update.Message.Chat, new InputMedia(fileInfo.OpenRead(), fileInfo.Name));
                                }
                            }
                        }

                        break;
                }

            }

            
        }

        public static async void SendList(ITelegramBotClient bot, Update update)
        {
            StringBuilder fulltext = new StringBuilder("Your full file list\n\n");

            var files = ShowFiles(update);
            foreach (var fileInfo in files)
            {
                fulltext.Append(
                    $"{fileInfo.Name}\n" +
                    $"{fileInfo.Length} bytes\n" +
                    $"Uploaded time: {fileInfo.CreationTime}\n" +
                    "Download: /_" +
                    $"{fileInfo.CreationTime.ToString("dd_MM_yyyy_HH_mm_ss")} \n\n");
            }

            await bot.SendTextMessageAsync(update.Message.Chat, fulltext.ToString());
        }

        public static async void SendInline(Update update, CancellationToken cancellationToken)
        {
            List<InlineKeyboardButton[]> buttons = new List<InlineKeyboardButton[]>();
            var files = ShowFiles(update);
            foreach (var fileInfo in files)
            {
                buttons.Add(new[] { 
                    InlineKeyboardButton.WithCallbackData(text: $"{fileInfo.Name}",callbackData: $"{fileInfo.Name}")
                });
            }

            await bot.SendTextMessageAsync(
                chatId: update.Message.Chat,
                text: "Choose",
                replyMarkup: new InlineKeyboardMarkup(buttons.ToArray()),
                cancellationToken: cancellationToken);
        }

        private static async void DownloadFile(ITelegramBotClient bot, Update update)
        {

            if (update.Message.Photo != null)
            {
                var photo = update.Message.Photo[update.Message.Photo.Length - 1];
                var username = update.Message.From.Username;

                Console.WriteLine($"\n{username} {photo.FileUniqueId} photo {photo.FileSize}");

                if (photo.FileSize >= 20971520)
                {
                    await bot.SendTextMessageAsync(update.Message.Chat, $"Photo is too big. Max size - 20MB") ;
                    return;
                }

                var file = await bot.GetFileAsync(photo.FileId);

                if (!Directory.Exists(downloadPath + $"\\{username}"))
                {
                    Directory.CreateDirectory(downloadPath + $"\\{username}");
                }
                string fullPath = downloadPath + $"\\{username}\\{photo.FileUniqueId}.png";
                using (FileStream fs = new FileStream(fullPath, FileMode.Create))
                {
                    await bot.DownloadFileAsync(file.FilePath, fs);
                }
            }

            if (update.Message.Audio != null)
            {
                var audio = update.Message.Audio;
                var username = update.Message.From.Username;

                Console.WriteLine($"\n{username} {audio.FileUniqueId} {audio.MimeType} {audio.FileSize}");

                if(audio.FileSize >= 20971520)
                {
                    await bot.SendTextMessageAsync(update.Message.Chat, $"{audio.FileName} too big. Max size - 20MB") ;
                    return;
                }

                var file = await bot.GetFileAsync(audio.FileId);

                if (!Directory.Exists(downloadPath + $"\\{username}"))
                {
                    Directory.CreateDirectory(downloadPath + $"\\{username}");
                }
                string fullPath = downloadPath + $"\\{username}\\{audio.FileName}";
                using (FileStream fs = new FileStream(fullPath, FileMode.Create))
                {
                    await bot.DownloadFileAsync(file.FilePath, fs);
                }
            }

            if (update.Message.Document != null)
            {
                var doc = update.Message.Document;
                var username = update.Message.From.Username;

                Console.WriteLine($"\n{username} {doc.FileUniqueId} {doc.MimeType} {doc.FileSize}");

                if (doc.FileSize >= 20971520)
                {
                    await bot.SendTextMessageAsync(update.Message.Chat, $"File {doc.FileName} is too big. Max size - 20MB");
                    return;
                }

                var file = await bot.GetFileAsync(doc.FileId);

                if (!Directory.Exists(downloadPath + $"\\{username}"))
                {
                    Directory.CreateDirectory(downloadPath + $"\\{username}");
                }
                string fullPath = downloadPath + $"\\{username}\\{doc.FileName}";
                using (FileStream fs = new FileStream(fullPath, FileMode.Create))
                {
                    await bot.DownloadFileAsync(file.FilePath, fs);
                }
            }

            await bot.SendTextMessageAsync(update.Message.Chat, "downloaded");
        }

        private static List<FileInfo> ShowFiles(Update update)
        {
            var username = update.Message.From.Username;
            if (!Directory.Exists(downloadPath + $"\\{username}"))
            {
                Directory.CreateDirectory(downloadPath + $"\\{username}");
            }
            return Directory.GetFiles(downloadPath + $"\\{username}").Select(c => new FileInfo(c)).ToList();
        }

        private static Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}

