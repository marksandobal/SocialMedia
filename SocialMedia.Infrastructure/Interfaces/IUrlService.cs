using SocialMedia.Core.QueryFilters;
using System;

namespace SocialMedia.Infrastructure.Interfaces
{
    public interface IUrlService
    {
        Uri GetPostPaginationUrl(PostQueryFilter filters, string actionUrl);
    }
}