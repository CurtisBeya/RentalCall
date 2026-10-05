using RentalCall.Managers;
using RentalCall.Managers.Interfaces;
using RentalCall.Models;
using RentalCall.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace RentalCall.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionItemController: ControllerBase
    {
        private readonly IActionItemManager _actionItemManager;
        private readonly ICallManager _callManager;

        public ActionItemController(IActionItemManager actionItemManager, ICallManager callManager)
        {
            _actionItemManager = actionItemManager;
            _callManager = callManager;
        }

        /// <summary>
        /// Endpoint to return to add an action item manually
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("ManualAdd")]
        [SwaggerOperation(OperationId = nameof(ManualAdd))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ActionItemModel))]
        public async Task<ActionItemModel> ManualAdd(ActionItemCreateModelDto ActionItemDto)
        {
            ActionItemModel ActionItem = await _actionItemManager.ManualAdd(ActionItemDto);

            // Update call HasBeenReviewed automatically when an ActionItem is added manually
            if (ActionItem != null)
                await _callManager.CallReviewSystemUpdate(ActionItem.CallId);

            return ActionItem;
        }

        /// <summary>
        /// Endpoint to return to update an action item
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Route("Update")]
        [SwaggerOperation(OperationId = nameof(Update))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ActionItemModel))]
        public async Task<ActionItemModel> Update(ActionItemUpdateModelDto ActionItemDto)
        {
            return await _actionItemManager.Update(ActionItemDto);
        }

        /// <summary>
        /// Endpoint to return the list of all item actions
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("List")]
        [SwaggerOperation(OperationId = nameof(List))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ActionItemModel))]
        public async Task<List<ActionItemModel>> List()
        {
            return await _actionItemManager.List();
        }

        /// <summary>
        /// Endpoint to return the list of all item actions
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("List/GivenCallId/{id}")]
        [SwaggerOperation(OperationId = nameof(ListGivenCallId))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ActionItemModel))]
        public async Task<List<ActionItemModel>> ListGivenCallId([FromRoute] long id)
        {
            return await _actionItemManager.ListGivenCallId(id);
        }

        // <summary>
        /// Endpoint to return a specific action item file given its id.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Authorize]
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
