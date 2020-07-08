using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Interfaces;
using System;

namespace SocialMedia.Infrastructure.Services
{
    public class UrlService : IUrlService
    {
        private readonly string _baseUrl;
        public UrlService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public Uri GetPostPaginationUrl(PostQueryFilter filters, string actionUrl)
        {
            string baseUrl = $"{_baseUrl}{actionUrl}";
            return new Uri(baseUrl);

        }
    }
}
