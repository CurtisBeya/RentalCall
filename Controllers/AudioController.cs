using AudioSummarizer.Managers.Interfaces;
using AudioSummarizer.Models;
using AudioSummarizer.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AudioSummarizer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AudioController : ControllerBase
    {
        private readonly IAudioManager _audioManager;

        public AudioController(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        /// <summary>
        /// Endpoint to add a new audio file and retunrs a summary.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        [SwaggerOperation(OperationId = nameof(Add))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AudioModelDto))]
        public async Task<AudioModel> Add(AudioModelDto audio)
        {
            return await _audioManager.Add(audio);
        }

        /// <summary>
        /// Endpoint to return the list of all picture
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("List")]
        [SwaggerOperation(OperationId = nameof(List))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AudioModel))]
        public async Task<List<AudioModel>> List()
        {
            return await _audioManager.List();
        }

        // <summary>
        /// Endpoint to return a specific audio file given it is id.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("Details/{id}")]
        [SwaggerOperation(OperationId = nameof(Details))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AudioModel))]
        public async Task<AudioModel?> Details([FromRoute] long id)
        {
            return await _audioManager.Details(id);
        }
    }
}
