using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Gram.Models.Interfaces
{
    public interface IGram
    {
        Task Delete(int id);

        Task<List<NetGram>> GetAllNetGrams();

        Task<NetGram> GetDetails(int id);

        Task SaveNetGram(NetGram netGram);
        
    }
}
