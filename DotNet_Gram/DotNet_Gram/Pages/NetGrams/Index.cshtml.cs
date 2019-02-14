using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_Gram.Models;
using DotNet_Gram.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNet_Gram.Pages.NetGrams
{
    public class IndexModel : PageModel
    {
        private readonly IGram _netGram;

        public IndexModel(IGram netGram)
        {
            _netGram = netGram;
        }

        [FromRoute]
        public int ID { get; set; }

        public NetGram NetGram { get; set; }


        public async Task OnGet()
        {
            NetGram = await _netGram.GetDetails(ID);
        }
    }
}