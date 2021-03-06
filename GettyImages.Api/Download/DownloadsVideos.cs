﻿using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Download
{
    public class DownloadsVideos : ApiRequest
    {
        protected const string V3DownloadVidoesPath = "/downloads/videos";
        protected string AssetId { get; set; }

        private DownloadsVideos(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
            AddQueryParameter(Constants.AutoDownloadKey, false);
        }

        internal static DownloadsVideos GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new DownloadsVideos(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "POST";
            Path = V3DownloadVidoesPath + "/" + AssetId;

            return await base.ExecuteAsync();
        }

        public DownloadsVideos WithId(string value)
        {
            AssetId = value;
            return this;
        }

        public DownloadsVideos WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public DownloadsVideos WithAutoDownload(bool value = true)
        {
            AddQueryParameter(Constants.AutoDownloadKey, value);
            return this;
        }

        public DownloadsVideos WithDownloadDetails(string value)
        {
            BodyParameter = value;
            return this;
        }

        public DownloadsVideos WithProductId(int value)
        {
            AddQueryParameter(Constants.ProductIdKey, value);
            return this;
        }

        public DownloadsVideos WithSize(string value)
        {
            AddQueryParameter(Constants.SizeKey, value);
            return this;
        }
    }
}
