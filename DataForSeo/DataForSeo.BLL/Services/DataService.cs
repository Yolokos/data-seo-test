namespace DataForSeo.BLL.Services
{
    using DataForSeo.BLL.Interfaces;
    using DataForSeo.Common.DTO;
    using DataForSeo.DAL.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DataService : IDataService
    {
        private readonly IDataRepository dataRepository;

        public DataService(IDataRepository _dataRepository)
        {
            dataRepository = _dataRepository;
        }

        public async Task EditData(DataDTO dataDTO)
        {
            await dataRepository.EditData(dataDTO);
        }

        public async Task<List<DataDTO>> GetData()
        {
            return await dataRepository.GetData();
        }

        public async Task PostData(DataDTO dataDTO)
        {
            await dataRepository.PostData(dataDTO);
        }
    }
}
