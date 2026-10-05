using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCall.Managers.Interfaces;
using RentalCall.Models;
using RentalCall.Models.Dtos;
using Swashbuckle.AspNetCore.Annotations;

namespace RentalCall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Endpoint to add a new user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Add")]
        [SwaggerOperation(OperationId = nameof(Add))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserCreateModelDto))]
        public async Task<UserModel> Add(UserCreateModelDto user)
        {
            return await _userManager.Add(user);
        }

        /// <summary>
        /// Endpoint to update a an existing user
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("Role/Update")]
        [SwaggerOperation(OperationId = nameof(Update))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserUpdateModelDto))]
        public async Task<UserModel> Update(UserUpdateModelDto user)
        {
            return await _userManager.Update(user);
        }

        /// <summary>
        /// Endpoint to return the list of all users
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("List")]
        [SwaggerOperation(OperationId = nameof(List))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserModel))]
        public async Task<List<UserModel>> List()
        {
            return await _userManager.List();
        }

        // <summary>
        /// Endpoint to return a specific user given its id.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("Details/{id}")]
        [SwaggerOperation(OperationId = nameof(Details))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserModel))]
        public async Task<UserModel?> Details([FromRoute] long id)
        {
            return await _userManager.Details(id);
        }
    }
}
