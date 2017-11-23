using AutoMapper;
using NotificationBackend.Models;
using NotificationBackend.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.SwaggerGen.Annotations;
using System;
using System.Collections.Generic;
using NotificationBackend.DAL.NotificationEntities;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NotificationBackend.Controllers
{
    [AllowAnonymous]
    [EnableCors("AllowCors")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;

        private IMapper _mapper;
        private ILogger<UsersController> _logger;
        public UsersController(IUserRepository userRepository, IMapper mapper, ILogger<UsersController> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [SwaggerOperation("Get")]
        [HttpGet("")]
        public IActionResult Get()
        {
            _logger.LogDebug("Getting paged Users for logged in user entity");
            IEnumerable<Users> users = new List<Users>();

            try
            {
                users = _userRepository.GetAll();
                IEnumerable<UserBaseDto> userAccountSimpleDto = _mapper.Map<IEnumerable<Users>, IEnumerable<UserBaseDto>>(users);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting user list: " + ex.Message);
            }
            return Ok(users);
        }
    }
}
