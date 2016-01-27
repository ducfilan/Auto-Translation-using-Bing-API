using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpdateDataForLocalizedTables
{
    class BingClient
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        public BingClient(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }
}