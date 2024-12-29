# Anonymous Chatbot Telegram Bot

Welcome to **Anonymous Chatbot**, a Telegram bot that allows users to chat anonymously with a random stranger. This project is written in **C#** and uses the Telegram Bot API to facilitate anonymous conversations in a simple and efficient way.

## Features

- **Anonymous Matching**: Users can connect to a random stranger anonymously and start chatting.
- **Easy Commands**: The bot offers intuitive commands like `/start` and `/connect` for a seamless user experience.
- **Queue System**: Users are added to a waiting queue and paired automatically when a partner becomes available.
- **Message Forwarding**: Messages are relayed between paired users without revealing their identities.

---

## How It Works

1. **Initialization**: The bot starts and listens for incoming messages using the Telegram Bot API.
2. **User Commands**:
   - `/start`: Welcomes the user and provides instructions.
   - `/connect`: Adds the user to the waiting queue and pairs them with a random stranger.
3. **Pairing Users**: When two users are in the queue, they are paired, and their messages are forwarded to each other anonymously.
4. **Messaging**: Users can chat until they decide to disconnect or close the conversation.

---

## Installation and Setup

Follow these steps to set up the bot on your system:

### Prerequisites
- **C# Development Environment**: Install the [.NET SDK](https://dotnet.microsoft.com/download) for building and running the application.
- **Telegram Bot Token**: Obtain a bot token from [BotFather](https://core.telegram.org/bots#botfather) on Telegram.

### Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/aryanteymoori/anonymous-chatbot.git
   ```

2. Navigate to the project directory:
   ```bash
   cd anonymous-chatbot
   ```

3. Update the bot token in the code:
   Replace the placeholder bot token in the line below with your token:
   ```csharp
   Client = new TelegramBotClient("<your-bot-token>");
   ```

4. Build and run the bot:
   ```bash
   dotnet run
   ```

5. Start chatting with the bot on Telegram!

---

## Bot Commands

| Command      | Description                                      |
|--------------|--------------------------------------------------|
| `/start`     | Welcomes the user and provides basic instructions. |
| `/connect`   | Adds the user to the waiting queue to find a partner. |

---

## Code Overview

- **Main Class**: The `Program` class initializes the bot and manages the core functionality.
- **Queue System**: A `Queue<long>` manages waiting users.
- **Pair Management**: A `Dictionary<long, long>` stores active user pairs.
- **Message Forwarding**: Messages are forwarded between paired users while maintaining anonymity.

---

## Example Usage

1. User starts the bot by typing `/start`.
   - Bot responds: "Welcome! Type /connect to chat anonymously with someone."

2. User types `/connect`.
   - Bot adds the user to the queue and matches them with a partner when available.

3. Users exchange messages through the bot anonymously.

---

## Future Improvements

- Add `/disconnect` command to allow users to end a conversation.
- Implement a timeout for users in the queue to prevent long waits.
- Introduce a feature to report inappropriate behavior.
- Add support for multimedia messages.

---

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests to enhance the bot.

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Commit your changes and submit a pull request.

---

## Acknowledgments

- [Telegram Bot API Documentation](https://core.telegram.org/bots/api)
- Community contributors and testers

---

## Contact

For questions or feedback, reach out to [Aryan Teymoori](mailto:aryanteymoori@yahoo.com).

Happy chatting! 🎉