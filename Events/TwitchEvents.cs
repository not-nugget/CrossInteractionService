namespace CrossInteractionService.Events
{
    public class TwitchEvents
    {
        public delegate void ChannelGoLive(string channel);
        public event ChannelGoLive ChannelGoLiveEvent;
    }
}
