namespace DataForSeo.DAL.Repositories
{
    using DataForSeo.Common.DTO;
    using DataForSeo.DAL.EF;
    using DataForSeo.DAL.Entities;
    using DataForSeo.DAL.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataRepository : IDataRepository
    {
        private readonly ApplicationContext db;

        public DataRepository(ApplicationContext _db)
        {
            db = _db;
        }

        public async Task EditData(DataDTO dataDTO)
        {
            var data = await db.Data.Where(d => d.Id == dataDTO.Id).SingleOrDefaultAsync();

            if(data != null)
            {
                data.Position = dataDTO.Position;
                data.Status = dataDTO.Status;

                db.Data.Update(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<DataDTO>> GetData()
        {
            return await db.Data.Select(p => new DataDTO { 
                Id = p.Id,
                SearchEngine = p.SearchEngine,
                TaskId = p.TaskId,
                WebSite = p.WebSite,
                KeyWord = p.KeyWord,
                Position = p.Position,
                Status = p.Status
            }).ToListAsync();
        }

        public async Task PostData(DataDTO data)
        {
            await db.Data.AddAsync(new Data { 
                Id = data.Id,
                KeyWord = data.KeyWord,
                TaskId = data.TaskId,
                Position = data.Position,
                SearchEngine = data.SearchEngine, 
                WebSite = data.WebSite,
                Status = data.Status
            });

            await db.SaveChangesAsync();
        }
    }
}
