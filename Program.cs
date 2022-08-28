using Telegram.Bot;
using Telegram.Bot.Types;

var botClient = new TelegramBotClient("5215566052:AAFgF40V0IVpe4UtClu0nvebwY-rLQHtLQE");

var me = await botClient.GetMeAsync();

List<long> userIds = new List<long>();
long adminId = 0;
int pincode = 123;

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
    // Запись в оперативную память пользователя
    if (pincode.ToString() == message.Text && adminId == 0)
    {
        adminId = message.From.Id;
        Console.WriteLine($"Admin - {adminId}");
    }

    if (!userIds.Contains(message.From.Id))
    {
        userIds.Add(message.From.Id);
    }

    foreach (int id in userIds)
    {
        Console.WriteLine(id);
    }
    if (message.From.Id == adminId)
    {
        await SendMessageAllSubscribers(message.Text);
    }


    if (message.Text == "Привет")
    {
        await botClient!.SendTextMessageAsync(message.Chat.Id, "Ухты, а ты вежливый!");
    }
    //     int number = Convert.ToInt32(message.Text);
    //     int number2 = GetNumber();

    //     int square = number * number;

    //     //await botClient!.SendTextMessageAsync(message.Chat.Id, $"{message.From.Username} Ты мне писал {message.Text}?");
    //     //await botClient!.SendTextMessageAsync(message.Chat.Id, $"{message.Text}");
    //     await botClient!.SendTextMessageAsync(message.Chat.Id, $"{square}");
    // }
    // int GetNumber()
    // {
    //     return 12;
}
async Task SendMessageAllSubscribers(string message)
{
    for (int i = 0; i < userIds.Count; i++)
    {
        await botClient!.SendTextMessageAsync(userIds[i], message);
    }

}



