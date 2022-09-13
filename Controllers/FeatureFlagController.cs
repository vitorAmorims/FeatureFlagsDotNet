using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace ProjectFeatureFlags.Controllers
{
    [ApiController]
    public class FeatureFlagController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;

        public FeatureFlagController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        [HttpGet("BooleanFilterBoolean")]
        public async Task<IActionResult> BooleanFilter()
        {
            if (await _featureManager.IsEnabledAsync("BooleanFilter"))
            {
                return Ok("Feature enabled");
            }
            else
            {
                return BadRequest("Feature not enabled");
            }
        }
        [HttpGet("BooleanFilterPercentageFilter")]
        public async Task<IActionResult> PercentageFilter()
        {
            if (await _featureManager.IsEnabledAsync("PercentageFilter"))
            {
                return Ok("Feature enabled");
            }
            else
            {
                return BadRequest("Feature not enabled");
            }
        }

        [HttpGet("CustomFilter")]
        public async Task<IActionResult> CustomFilter()
        {
            if (await _featureManager.IsEnabledAsync("CustomFilter"))
            {
                return Ok("Feature enabled");
            }
            else
            {
                return BadRequest("Feature not enabled");
            }
        }

        [HttpGet("TimeWindowFilter")]
        public async Task<IActionResult> TimeWindowFilter()
        {
            if (await _featureManager.IsEnabledAsync("TimeWindowFilter"))
            {
                return Ok("Feature enabled");
            }
            else
            {
                return BadRequest("Feature not enabled");
            }
        }
    }
}
