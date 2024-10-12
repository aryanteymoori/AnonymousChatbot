using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace Telief
{
    public class Program
    {
        public static TelegramBotClient? Client;

        private static Queue<long> waitingQueue = new Queue<long>();
        private static Dictionary<long, long> userPairs = new Dictionary<long, long>();

        [Obsolete]
        public static void Main(string[] args)
        {
            Client = new TelegramBotClient("Your Telgram Token");
            Client.OnMessage += Client_OnMessage;
            Client?.StartReceiving();
            Console.WriteLine("started");
            Thread.Sleep(-1);
        }

        [Obsolete]
        private static void Client_OnMessage(object? sender, MessageEventArgs e)
        {
            Console.WriteLine($"{e.Message.Chat.Id} : {e.Message.Text}");
            if (e.Message.Type == MessageType.Text)
            {
                long chatId = e.Message.Chat.Id;

                // Check if user wants to start chatting
                if (e.Message.Text.ToLower() == "/start")
                {
                     Client?.SendTextMessageAsync(chatId, "Welcome! Type /connect to chat anonymously with someone.");
                    return;
                }

                // Handle connect command
                if (e.Message.Text.ToLower() == "/connect")
                {
                    if (waitingQueue.Contains(chatId))
                    {
                        Client?.SendTextMessageAsync(chatId, "You are already in the queue.");
                        return;
                    }

                    // Add user to the queue
                    waitingQueue.Enqueue(chatId);
                    Client?.SendTextMessageAsync(chatId, "Looking for a chat partner...");

                    // Try to find a partner
                    if (waitingQueue.Count > 1)
                    {
                        var partnerId = waitingQueue.Dequeue();
                        userPairs[chatId] = partnerId;
                        userPairs[partnerId] = chatId;

                        Client?.SendTextMessageAsync(chatId, "You are now connected! Type your message:");
                        Client?.SendTextMessageAsync(partnerId, "You are now connected! Type your message:");
                    }

                    return;
                }

                // Forward messages between paired users
                if (userPairs.ContainsKey(chatId))
                {
                    var partnerId = userPairs[chatId];
                     Client?.SendTextMessageAsync(partnerId, $"{chatId}: {e.Message.Text}");
                }
                else
                {
                    Client?.SendTextMessageAsync(chatId, "You are not connected to anyone. Type /connect to find a partner.");
                }
            }
        }
    }
}