using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Gram.Models.Interfaces
{
    public interface IGram
    {
        /// <summary>
        /// delete a post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);

        /// <summary>
        /// get all post and display them on index
        /// </summary>
        /// <returns></returns>
        Task<List<NetGram>> GetAllNetGrams();

        /// <summary>
        /// get details of one post and display to manage page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<NetGram> GetDetails(int id);

        /// <summary>
        /// save changes or new post
        /// </summary>
        /// <param name="netGram"></param>
        /// <returns></returns>
        Task SaveNetGram(NetGram netGram);
        
    }
}
