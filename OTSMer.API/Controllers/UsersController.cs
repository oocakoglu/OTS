using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OTS.Model;
using OTS.Core.Services;
using OTSMer.API.DTO;
using OTSMer.API.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTSMer.API.Controllers
{

    [ApiController]
    //[Route("api/[controller]")]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this._mapper = mapper;
            this._userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            return Ok(userResources);
        }

        [HttpGet("{id}")]
         public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            var userResource = _mapper.Map<User, UserDTO>(user);
            return Ok(userResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] SaveUserDTO saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var userToCreate = _mapper.Map<SaveUserDTO, User>(saveUserResource);

            var newUser = await _userService.CreateUser(userToCreate);

            //var user = await _userService.GetUserById(newUser.UserId);

            var userResource = _mapper.Map<User, UserDTO>(newUser);

            return Ok(userResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateMusic(int id, [FromBody] SaveUserDTO saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var userToBeUpdate = await _userService.GetUserById(id);

            if (userToBeUpdate == null)
                return NotFound();

            var user = _mapper.Map<SaveUserDTO, User>(saveUserResource);

            await _userService.UpdateUser(userToBeUpdate, user);

            var updatedUser = await _userService.GetUserById(id);
            var updatedUserResource = _mapper.Map<User, UserDTO>(updatedUser);

            return Ok(updatedUserResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == 0)
                return BadRequest();

            var user = await _userService.GetUserById(id);

            if (user == null)
                return NotFound();

            await _userService.DeleteUser(user);

            return NoContent();
        }

    }
}
