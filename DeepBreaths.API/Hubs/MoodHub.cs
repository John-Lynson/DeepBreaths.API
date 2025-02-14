using Microsoft.AspNetCore.SignalR;

namespace DeepBreaths.API.Hubs
{
    public class MoodHub : Hub
    {
        public async Task SendMoodUpdate(string mood, string note)
        {
            await Clients.All.SendAsync("ReceiveMoodUpdate", mood, note);
        }
    }
}
