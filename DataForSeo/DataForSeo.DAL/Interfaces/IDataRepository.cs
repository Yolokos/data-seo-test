namespace DataForSeo.DAL.Interfaces
{
    using DataForSeo.Common.DTO;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataRepository
    {
        Task<List<DataDTO>> GetData();
        Task PostData(DataDTO data);
        Task EditData(DataDTO dataDTO);
    }
}
