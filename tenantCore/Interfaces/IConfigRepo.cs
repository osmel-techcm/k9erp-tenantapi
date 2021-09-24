using System.Threading.Tasks;
using tenantCore.Entities;

namespace tenantCore.Interfaces
{
    public interface IConfigRepo
    {
        Task<responseData> GetConfigs();
        Task<responseData> GetConfig(int id);
        Task<responseData> PutConfig(int id, Config config);
        Task<responseData> GetConfigByName(string propName);
    }
}
