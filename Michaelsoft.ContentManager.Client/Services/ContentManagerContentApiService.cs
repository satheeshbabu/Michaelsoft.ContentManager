﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Michaelsoft.ContentManager.Client.Interfaces;
using Michaelsoft.ContentManager.Client.Settings;
using Michaelsoft.ContentManager.Common.HttpModels.Authentication;
using Michaelsoft.ContentManager.Common.HttpModels.Content;
using Microsoft.AspNetCore.Http;

namespace Michaelsoft.ContentManager.Client.Services
{
    public class ContentManagerContentApiService : ContentManagerBaseApiService,
                                                   IContentManagerContentApiService
    {

        public ContentManagerContentApiService(IContentManagerClientSettings settings,
                                               IHttpClientFactory httpClientFactory,
                                               IHttpContextAccessor httpContextAccessor) :
            base(settings, httpClientFactory, httpContextAccessor)
        {
        }

        public async Task<CreateResponse> CreateContent(CreateRequest createRequest)
        {
            var baseApiResult = await PostRequest<CreateResponse>("Create", createRequest);

            if (!baseApiResult.Success)
                throw new Exception(baseApiResult.Message);

            return baseApiResult.Response;
        }

        public async Task<ListResponse> ListContents()
        {
            var baseApiResult = await GetRequest<ListResponse>("List");

            if (!baseApiResult.Success)
                throw new Exception(baseApiResult.Message);

            return baseApiResult.Response;
        }

    }
}