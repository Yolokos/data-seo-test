namespace DataForSeo.BLL.Interfaces
{
    using DataForSeo.Common.DTO;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataService
    {
        Task<List<DataDTO>> GetData();

        Task PostData(DataDTO dataDTO);

        Task EditData(DataDTO dataDTO);
    }
}
