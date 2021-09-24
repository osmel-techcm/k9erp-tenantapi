using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using tenantCore.Entities;
using tenantCore.Interfaces;
using tenantInfrastructure.Data;

namespace tenantInfrastructure.Repositories
{
    public class ConfigRepo : IConfigRepo
    {
        private readonly MultitenantDbContext _context;

        public ConfigRepo(MultitenantDbContext context)
        {
            _context = context;
        }

        public async Task<responseData> GetConfig(int id)
        {
            var responseData = new responseData();
            try
            {
                responseData.data = await _context.Config.AsNoTracking().FirstOrDefaultAsync(x => x.id == id);
            }
            catch (Exception e)
            {
                responseData.error = true;
                responseData.errorValue = 2;
                responseData.description = e.Message;
                responseData.data = e;
            }

            return responseData;
        }

        public async Task<responseData> GetConfigs()
        {
            var responseData = new responseData();
            try
            {
                responseData.data = await _context.Config.AsNoTracking().ToListAsync();
            }
            catch (Exception e)
            {
                responseData.error = true;
                responseData.errorValue = 2;
                responseData.description = e.Message;
                responseData.data = e;
            }

            return responseData;
        }

        public async Task<responseData> PutConfig(int id, Config config)
        {
            var responseData = new responseData();
            try
            {
                if (id != config.id)
                {
                    responseData.error = true;
                    responseData.errorValue = 2;
                    responseData.description = "Not Found!";
                    return responseData;
                }

                _context.Entry(config).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                responseData.error = true;
                responseData.errorValue = 2;
                responseData.description = e.Message;
                responseData.data = e;
            }

            return responseData;

        }

        public async Task<responseData> GetConfigByName(string propName)
        {
            var responseData = new responseData();
            try
            {
                responseData.data = await _context.Config.FirstOrDefaultAsync(x => x.propName == propName);
            }
            catch (Exception e)
            {
                responseData.error = true;
                responseData.errorValue = 2;
                responseData.description = e.Message;
                responseData.data = e;
            }

            return responseData;
        }
    }
}
