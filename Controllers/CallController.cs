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
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CallCreateModelDto))]
        public async Task<CallModel> Add(CallCreateModelDto call)
        {
            return await _callManager.Add(call);
        }

        /// <summary>
        /// Endpoint to add a new audio file and retunrs a summary.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        [SwaggerOperation(OperationId = nameof(Update))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CallUpdateModelDto))]
        public async Task<CallModel> Update(CallUpdateModelDto call)
        {
            return await _callManager.Update(call);
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

        /// <summary>
        /// Endpoint to return the list of all picture
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        [Route("List/Given/CategoryName/{category}")]
        [SwaggerOperation(OperationId = nameof(ListGivenCategoryName))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CallModel))]
        public async Task<List<CallModel>> ListGivenCategoryName([FromRoute] String category)
        {
            return await _callManager.ListGivenCategoryName(category);
        }

        // <summary>
        /// Endpoint to return a specific call given its id.
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

        // <summary>
        /// Endpoint to return a specific call given its audio file name
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Search/GivenAudioFileName/{filename}")]
        [SwaggerOperation(OperationId = nameof(SearchGivenAudioFileName))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CallModel))]
        public async Task<CallModel?> SearchGivenAudioFileName([FromRoute] String filename)
        {
            return await _callManager.SearchGivenAudioFileName(filename);
        }
    }
}
