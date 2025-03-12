using Casus.Commands.ProcesTextFileMutations;
using Casus.Extensions;
using Casus.Services;
using MediatR;
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
        private readonly IMediator _mediator;

        public FileModifierController(IMediator mediator)
        {
            _mediator = mediator;
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
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ModifyFileAsync(IFormFile formFile)
        {
            if (formFile == null) { return BadRequest("A file is required"); }

            var command = await Mapping.MapToCommandAsync(formFile);
            var result = await _mediator.Send(command);

            if (result.Succeeded)
            {
                return File(result.Value.FileContent, formFile.ContentType, result.Value.FileName);
            }

            return Problem(result.ErrorMessage);
        }






    }
}
