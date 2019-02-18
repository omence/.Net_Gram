using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNet_Gram.Models;
using DotNet_Gram.Models.Interfaces;
using DotNet_Gram.Models.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DotNet_Gram.Pages.NetGrams
{
    public class ManageModel : PageModel
    {
        /// <summary>
        /// brings in service
        /// </summary>
        private readonly IGram _netGram;

        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public NetGram NetGram { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public Blob BlobImage { get; set; }

        /// <summary>
        /// configures model and blob
        /// </summary>
        /// <param name="netGram"></param>
        /// <param name="configuration"></param>
        public ManageModel(IGram netGram, IConfiguration configuration)
        {
            _netGram = netGram;

            BlobImage = new Blob(configuration);
        }

        /// <summary>
        /// Get details of post
        /// </summary>
        /// <returns></returns>
        public async Task OnGet()
        {
            NetGram = await _netGram.GetDetails(ID.GetValueOrDefault()) ?? new NetGram();
        }

        /// <summary>
        /// saves uploaded image file
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            var gram = await _netGram.GetDetails(ID.GetValueOrDefault()) ?? new NetGram();

            gram.NamePoster = NetGram.NamePoster;
            gram.Caption = NetGram.Caption;


             if(Image != null)
            {
                var path = Path.GetTempFileName();

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                var container = await BlobImage.GetContainer("gram");

                BlobImage.UploadFile(container, Image.FileName, path);

                CloudBlob blob = await BlobImage.GetBlob(Image.FileName, container.Name);

                gram.ImageURL = blob.Uri.ToString();
            }
            await _netGram.SaveNetGram(gram);

            return RedirectToPage("/Index");
        }

        /// <summary>
        /// Deletes a post
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDelete()
        {
            await _netGram.Delete(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}