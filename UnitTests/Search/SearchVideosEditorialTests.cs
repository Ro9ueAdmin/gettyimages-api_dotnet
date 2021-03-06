﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Entity;
using Xunit;

namespace UnitTests.Search
{
    public class SearchVideosEditorialTests
    {
        [Fact]
        public async Task SearchForEditorialVideosWithPhrase()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").ExecuteAsync();
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithAgeOfPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithAgeOfPeople(AgeOfPeople.Months6To11 | AgeOfPeople.Adult).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("age_of_people=adult%2C6-11_months");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithCollectionCodes()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var codes = new List<string>() { "WRI", "ARF" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithCollectionCodes(codes).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collection_codes=WRI%2CARF");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithCollectionFilterType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithCollectionFilterType(CollectionFilter.Exclude).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collections_filter_type=exclude");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithDownloadProduct()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
               .WithPhrase("cat").WithDownloadProduct(ProductType.Easyaccess).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("download_product=easyaccess");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithEditorialVideoType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithEditorialVideoType(EditorialVideo.Raw | EditorialVideo.Produced).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("editorial_video_types=raw%2Cproduced");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithEntityUri()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var uris = new List<string>() { "example_uri_1", "example_uri_2" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithEntityUris(uris).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("entity_uris=example_uri_1%2Cexample_uri_2");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithExcludeNudity()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithExcludeNudity().ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("exclude_nudity=True");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "asset_family", "id" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithResponseFields(fields).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=asset_family%2Cid");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithFormatFilter()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithAvailableFormat("HD").ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("format_available=hd");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithFrameRates()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithFrameRate(FrameRate.FrameRate24 | FrameRate.FrameRate29).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("frame_rates=24%2C29.97");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithKeywordId()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 64284, 67255 };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithKeywordIds(ids).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("keyword_ids=64284%2C67255");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithPage(2).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithPageSize(50).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithProductType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithProductType(ProductType.Easyaccess | ProductType.Editorialsubscription).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_types=editorialsubscription%2Ceasyaccess");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithSortOrder()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithSortOrder(SortOrder.BestMatch).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("sort_order=best_match");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithSpecificPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var people = new List<string>() { "Reggie Jackson" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithSpecificPeople(people).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("specific_people=Reggie+Jackson");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithReleaseStatus()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithReleaseStatus(ReleaseStatus.FullyReleased).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("release_status=fully_released");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithMinimumClipLength()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
               .WithPhrase("cat").WithMinimumVideoClipLength(20).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("min_clip_length=20");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithMaximumClipLength()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
               .WithPhrase("cat").WithMaximumVideoClipLength(200).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("max_clip_length=200");
        }

        [Fact]
        public async Task SearchForEditorialVideosWithMinimumAndMaximumClipLength()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
               .WithPhrase("cat").WithMinimumVideoClipLength(20).WithMaximumVideoClipLength(200).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("min_clip_length=20");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("max_clip_length=200");
        }
    }
}
