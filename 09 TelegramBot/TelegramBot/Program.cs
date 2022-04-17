using Newtonsoft.Json.Linq;
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

namespace TelegramBot
{
    internal class Program
    {
        static TelegramBotClient bot;

        static string dowloadPath = "download";

        static string token = System.IO.File.ReadAllText(@"meowsic.token");

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
                        string response = $"мяу, {userFirstName}\nПока что бот может только реагировать на \\start, на hi и на мяу";
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

            Console.ReadLine();

            #endregion
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message)
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
                switch (update.Message.Type)
                {
                    case MessageType.Audio:
                    case MessageType.Document:
                    case MessageType.Video:
                    case MessageType.Photo:
                        DownloadFile(update);
                        break;
                    case MessageType.Text:
                        var message = update.Message;
                        switch (message.Text.ToLower())
                        {
                            case "/start":
                                await bot.SendTextMessageAsync(message.Chat, $"Привет, {update.Message.From.Username}" +
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
                                await bot.SendPhotoAsync(message.Chat, "http://thecatapi.com/api/images/get?format=src&type=jpg,png");
                                break;

                            case "/showlist":
                                foreach (var fileInfo in ShowFiles())
                                {
                                    await bot.SendTextMessageAsync(message.Chat, fileInfo.FullName);
                                }
                                break;
                        }
                        
                        break;
                }
                
            }
        }

        private static async void DownloadFile(Update update)
        {
            var file = await bot.GetFileAsync(update.Message.Photo[2].FileId);

            //var client = new WebClient();
            //using (Stream stream = client.OpenRead($"https://api.telegram.org/file/bot{token}/{file.FilePath}"))
            //{
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        string line = "";
            //        while ((line = reader.ReadLine()) != null)
            //        {
            //            Console.WriteLine(reader.ReadToEnd());
            //        }
            //    }
            //}

            if (!Directory.Exists(dowloadPath))
            {
                Directory.CreateDirectory(dowloadPath);

            }
            FileStream fs = new FileStream(dowloadPath, FileMode.Create);//----------------разбей на части и проверь что из этого ошибка

            await bot.DownloadFileAsync(file.FilePath, fs);
            fs.Close();

            fs.Dispose();

        }

        private static List<FileInfo> ShowFiles()
        {
            Directory.CreateDirectory(dowloadPath);
            return Directory.GetFiles(dowloadPath).Select(c => new FileInfo(c)).ToList();
        }



        private static Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}

