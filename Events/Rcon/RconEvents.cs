﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossInteractionService.Events.Rcon
{
    public class RconEvents
    {
        /// <summary>
        /// 
        /// </summary>
        public static event EventHandler<UserWhitelistArgs> OnUserWhitelist;
    }
}
