using System;
using System.Threading.Tasks;
using tenantCore.DTOs;
using tenantCore.Entities;
using tenantCore.Interfaces;

namespace tenantCore.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepo _iconfigRepo;

        public ConfigService(IConfigRepo iconfigRepo)
        {
            _iconfigRepo = iconfigRepo;
        }

        public async Task<responseData> GetConfig(int id)
        {
            return await _iconfigRepo.GetConfig(id);
        }

        public async Task<responseData> GetConfigs()
        {
            return await _iconfigRepo.GetConfigs();
        }

        public async Task<responseData> PutConfig(int id, Config config)
        {
            return await _iconfigRepo.PutConfig(id, config);
        }

        public async Task<responseData> GetConfigByName(string propName)
        {
            return await _iconfigRepo.GetConfigByName(propName);
        }

        public async Task<responseData> GetSystemTimeZones()
        {
            var responseData = new responseData
            {
                data = TimeZoneInfo.GetSystemTimeZones()
            };

            return responseData;
        }

        public async Task<responseData> UpdateConfig(ConfigDTO configDTO)
        {
            var responseData = new responseData();

            foreach (var propertyInfo in configDTO.GetType().GetProperties())
            {
                var configResponse = await _iconfigRepo.GetConfigByName(propertyInfo.Name);
                if (configResponse.error)
                {
                    return configResponse;
                }

                var config = (Config)configResponse.data;
                config.propValue = propertyInfo.GetValue(configDTO).ToString();

                configResponse = await _iconfigRepo.PutConfig(config.id, config);
                if (configResponse.error)
                {
                    return configResponse;
                }
            }

            return responseData;
        }
    }
}
