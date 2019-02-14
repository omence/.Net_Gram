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
    public class ManageModel : PageModel
    {
        private readonly IGram _netGram;

        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public NetGram NetGram { get; set; }

        public ManageModel(IGram netGram)
        {
            _netGram = netGram;
        }

        public async Task OnGet()
        {
            NetGram = await _netGram.GetDetails(ID.GetValueOrDefault()) ?? new NetGram();
        }

        public async Task<IActionResult> OnPost()
        {
            var gram = await _netGram.GetDetails(ID.GetValueOrDefault()) ?? new NetGram();

            gram.NamePoster = NetGram.NamePoster;
            gram.Caption = NetGram.Caption;
            gram.ImageURL = NetGram.ImageURL;

            await _netGram.SaveNetGram(gram);

            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _netGram.Delete(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}