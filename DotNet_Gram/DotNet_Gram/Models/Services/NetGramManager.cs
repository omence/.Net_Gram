using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_Gram.Models.Interfaces;
using DotNet_Gram.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Gram.Models.Services
{
    public class NetGramManager : IGram
    {
        private readonly NetGramDbContext _context;

        public NetGramManager(NetGramDbContext context)
        {
            _context = context;
        }

         
        /// <summary>
        /// Deletes a net gram
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            NetGram netGram = await _context.NetGrams.FindAsync(id);
            if (netGram != null)
            {
                _context.Remove(netGram);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets all net grams and displays to page
        /// </summary>
        /// <returns></returns>
        public async Task<List<NetGram>> GetAllNetGrams()
        {
            return await _context.NetGrams.ToListAsync();
        }

        /// <summary>
        /// Gets details of netgram
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<NetGram> GetDetails(int id)
        {
            NetGram netGram = await _context.NetGrams.FirstOrDefaultAsync(net => net.ID == id);
            return netGram;
        }

        /// <summary>
        /// Saves new and or  updates existing netgrams
        /// </summary>
        /// <param name="netGram"></param>
        /// <returns></returns>
        public async Task SaveNetGram(NetGram netGram)
        {
            if (await _context.NetGrams.FirstOrDefaultAsync(n => n.ID == netGram.ID) == null)
            {
                _context.NetGrams.Add(netGram);
            }
            else
            {
                _context.NetGrams.Update(netGram);
            }

            await _context.SaveChangesAsync();
        }
    }
}
