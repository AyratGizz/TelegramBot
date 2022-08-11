using Telegram.Bot;
using Telegram.Bot.Types;

var botClient = new TelegramBotClient("5215566052:AAFgF40V0IVpe4UtClu0nvebwY-rLQHtLQE");

var me = await botClient.GetMeAsync();

while (true)
{
    var updates = await botClient.GetUpdatesAsync();
    for (int i = 0; i < updates.Count(); i++)
    {
        switch (updates[i].Type)
        {
            case Telegram.Bot.Types.Enums.UpdateType.Message:
                {
                    MessageHandle(updates[i].Message!);
                    updates = await botClient.GetUpdatesAsync(updates[^1].Id + 1);
                    break;
                }


        }
    }
}
async void MessageHandle(Message message)
{
    if (message.Text == "Привет"){
        await botClient!.SendTextMessageAsync(message.Chat.Id, "Ухты, а ты вежливый!");
    }   
    int number = Convert.ToInt32(message.Text);
    
    int square = number * number;

    //await botClient!.SendTextMessageAsync(message.Chat.Id, $"{message.From.Username} Ты мне писал {message.Text}?");
    //await botClient!.SendTextMessageAsync(message.Chat.Id, $"{message.Text}");
    //await botClient!.SendTextMessageAsync(message.Chat.Id, $"{square}");
}

