﻿using Telegram.Bot;
using Telegram.Bot.Types;

var botClient = new TelegramBotClient ("5215566052:AAFgF40V0IVpe4UtClu0nvebwY-rLQHtLQE");

var me = await botClient.GetMeAsync();

while (true)
{
    var updates = await botClient.GetUpdatesAsync();
    for (int i = 0; i < updates.Count(); i++)
    {
        switch (updates[i].Type)
        {
            case Telegram.Bot.Types.Enums.UpdateType.Message: {
                MessageHandle(updates[i].Message!);
                updates = await botClient.GetUpdatesAsync(updates[^1].Id + 1);
                break;
            }
        }
    }
}
async void MessageHandle (Message message){







    await botClient!.SendTextMessageAsync(message.Chat.Id, $"{message.From.Username} Ты мне писал {message.Text}?");
}

