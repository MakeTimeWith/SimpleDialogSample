using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace SimpleDialogBot.Dialogs
{
    [Serializable]
    public class MeetingDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(AskName);
        }

        public virtual async Task AskName(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            await context.PostAsync("What's your name?");
            context.Wait(AskDemand);
        }

        public virtual async Task AskDemand(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            await context.PostAsync($"Thanks {message.Text}. what do you want to do?");
            context.Wait(AskAttendee);
        }

        public virtual async Task AskAttendee(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            await context.PostAsync("You want to set meeting tomorrow. With whom?");
            context.Done<object>(null);
        }

    }
}