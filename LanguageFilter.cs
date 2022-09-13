using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

namespace ProjectFeatureFlags
{
    [FilterAlias(nameof(LanguageFilter))]
    public class LanguageFilter : IFeatureFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LanguageFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context, CancellationToken cancellationToken = default)
        {
            var userLanguage = _httpContextAccessor.HttpContext.Request.Headers["Accept-Language"].ToString();
            var settings = context.Parameters.Get<LanguageFilterSettings>();
            return Task.FromResult(settings.AllowedLanguages.Any(a => userLanguage.Contains(a)));
        }
    }
}
