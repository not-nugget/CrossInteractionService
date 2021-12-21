using System;

namespace CrossInteractionService.Events.Twitch
{
    public class TwitchEvents
    {
        /// <summary>
        /// Invoked when a tracked channel's status changes due to the channel going live or offline, or if the status cannot be retrieved due to an outage
        /// </summary>
        public event EventHandler<ChannelStatusChangeEventArgs> OnChannelStatusChange;
    }
}
