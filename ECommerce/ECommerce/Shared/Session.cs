﻿namespace ECommerce.Shared
{
    public class Session
    {
        public string Username { get; set; }
        public string SessionId { get; set; }

        public string TokenId { get; set; }
        public DateTime LastLoginTime { get; set; }

    }

}
