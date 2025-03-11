using Casus.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;


namespace Casus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileModifierController : ControllerBase
    {
        private readonly IModifierService _modifierService;

        public FileModifierController(IModifierService modifierService)
        {
            _modifierService = modifierService;
        }

        /// <summary>
        /// Modifies the uploaded textfile and returns the modified textfile
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns>A modified file</returns>
        /// <reponse code="200">Returns the modified file</reponse>
        /// <reponse code="400">When something went wrong</reponse>
        [HttpPut("/Modify")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ModifyFileAsync(IFormFile formFile)
        {
            if (formFile == null) { return BadRequest("A file is required"); }
           
            var fileStateService = FileStateContainerService.Create(formFile);
            var result = await _modifierService.ModifyAsync(fileStateService);

            if (result.Succeeded)
            {
                return File(fileStateService.FileContent, fileStateService.ContentType, fileStateService.FileName);
            }

            return BadRequest(result.ErrorMessage);
        }
    }
}
