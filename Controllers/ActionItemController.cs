using AudioSummarizer.Managers;
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
    public class ActionItemController: ControllerBase
    {
        private readonly IActionItemManager _actionItemManager;

        public ActionItemController(IActionItemManager actionItemManager)
        {
            _actionItemManager = actionItemManager;
        }

        /// <summary>
        /// Endpoint to return to update an action item
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        [SwaggerOperation(OperationId = nameof(Update))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ActionItemModel))]
        public async Task<ActionItemModel> Update(ActionItemModelDto ActionItemDto)
        {
            return await _actionItemManager.Update(ActionItemDto);
        }

        // <summary>
        /// Endpoint to return a specific action item file given its id.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Details/{id}")]
        [SwaggerOperation(OperationId = nameof(Details))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ActionItemModel))]
        public async Task<ActionItemModel?> Details([FromRoute] long id)
        {
            return await _actionItemManager.Details(id);
        }
    }
}
