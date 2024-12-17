using Discord;
using Discord.WebSocket;
using Discord.Commands;


class Program
{
  private static DiscordSocketClient _client;
  private static CommandService _commands;

  public static async Task Main()
  {
    Console.WriteLine("Hello, World!");
    var db = new BotContext();

    var token = db.Bots
          .OrderBy(b => b.BotId)
          .First()
          .ApiKey;
    

    _client = new DiscordSocketClient();

    _commands = new CommandService(new CommandServiceConfig
    {
      // Again, log level:
      LogLevel = LogSeverity.Info,

      // There's a few more properties you can set,
      // for example, case-insensitive commands.
      CaseSensitiveCommands = false,
    });



    await _client.LoginAsync(TokenType.Bot, token);
    await _client.StartAsync();

    // Block this task until the program is closed.
    await Task.Delay(-1);

  }


  private static async Task HandleCommandAsync(SocketMessage arg)
  {
    // Bail out if it's a System Message.
    var msg = arg as SocketUserMessage;
    if (msg == null) return;

    // We don't want the bot to respond to itself or other bots.
    if (msg.Author.Id == _client.CurrentUser.Id || msg.Author.IsBot) return;

    // Create a number to track where the prefix ends and the command begins
    int pos = 0;
    // Replace the '!' with whatever character
    // you want to prefix your commands with.
    // Uncomment the second half if you also want
    // commands to be invoked by mentioning the bot instead.
    if (msg.HasCharPrefix('.', ref pos) /* || msg.HasMentionPrefix(_client.CurrentUser, ref pos) */)
    {
      // Create a Command Context.
      var context = new SocketCommandContext(_client, msg);

      // Execute the command. (result does not indicate a return value, 
      // rather an object stating if the command executed successfully).
      Console.WriteLine("TESt");
      // Uncomment the following lines if you want the bot
      // to send a message if it failed.
      // This does not catch errors from commands with 'RunMode.Async',
      // subscribe a handler for '_commands.CommandExecuted' to see those.
      //if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
      //    await msg.Channel.SendMessageAsync(result.ErrorReason);
    }
  }
}

