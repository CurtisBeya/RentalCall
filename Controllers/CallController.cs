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
    public class CallController : ControllerBase
    {
        private readonly ICallManager _callManager;

        public CallController(ICallManager callManager)
        {
            _callManager = callManager;
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
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CallModelDto))]
        public async Task<CallModel> Add(CallModelDto audio)
        {
            return await _callManager.Add(audio);
        }

        /// <summary>
        /// Endpoint to return the list of all picture
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        [Route("List")]
        [SwaggerOperation(OperationId = nameof(List))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CallModel))]
        public async Task<List<CallModel>> List()
        {
            return await _callManager.List();
        }

        // <summary>
        /// Endpoint to return a specific audio file given it is id.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Details/{id}")]
        [SwaggerOperation(OperationId = nameof(Details))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CallModel))]
        public async Task<CallModel?> Details([FromRoute] long id)
        {
            return await _callManager.Details(id);
        }
    }
}
