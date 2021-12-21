using CrossInteractionService.Models.Enums;

namespace CrossInteractionService.Events.Twitch
{
    public class ChannelStatusChangeEventArgs
    {
        public string Channel { get; init; }
        public string ChannelUrl { get; init; }
        public ChannelStatus Status { get; init; }
    }
}
