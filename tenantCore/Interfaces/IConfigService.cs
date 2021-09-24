using System.Threading.Tasks;
using tenantCore.DTOs;
using tenantCore.Entities;

namespace tenantCore.Interfaces
{
    public interface IConfigService
    {
        Task<responseData> GetConfigs();
        Task<responseData> GetConfig(int id);
        Task<responseData> PutConfig(int id, Config config);
        Task<responseData> GetConfigByName(string propName);
        Task<responseData> GetSystemTimeZones();
        Task<responseData> UpdateConfig(ConfigDTO configDTO);
    }
}
