﻿using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.AssetChanges
{
    public class Channels : ApiRequest
    {
        protected const string V3ChannelsPath = "/asset-changes/channels";

        private Channels(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static Channels GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new Channels(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3ChannelsPath;

            return await base.ExecuteAsync();
        }
    }
}
