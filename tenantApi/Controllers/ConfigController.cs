using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using tenantCore.DTOs;
using tenantCore.Entities;
using tenantCore.Interfaces;

namespace tenantApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _configService;

        public ConfigController(IConfigService configService)
        {
            _configService = configService;
        }

        [HttpGet]
        public async Task<responseData> GetConfigs()
        {
            return await _configService.GetConfigs();
        }

        [HttpGet]
        [Route("getTimeZones")]
        public async Task<responseData> getTimeZones()
        {
            return await _configService.GetSystemTimeZones();
        }

        [HttpPost]
        [Route("updateConfig")]
        public async Task<responseData> updateConfig(ConfigDTO configDTO)
        {
            return await _configService.UpdateConfig(configDTO);
        }
    }
}
