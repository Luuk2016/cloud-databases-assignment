using System.Net;
using AutoMapper;
using LKenselaar.CloudDatabases.CustomExceptions;
using LKenselaar.CloudDatabases.Models;
using LKenselaar.CloudDatabases.Models.DTO;
using LKenselaar.CloudDatabases.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LKenselaar.CloudDatabases.API.Controllers
{
    public class UserController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> log, IUserService userService, IMailService mailService, IMapper mapper)
        {
            _logger = log ?? throw new ArgumentNullException(nameof(log));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Function("CreateUser")]
        [OpenApiOperation(operationId: "CreateUser", tags: new[] { "CreateUser" }, Summary = "Create a new user", Description = "This endpoint allows the creation of a new user.")]
        [OpenApiRequestBody("application/json", typeof(CreateUserRequestDTO), Description = "The user data.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(CreateUserResponseDTO), Description = "The CREATED response")]
        public async Task<HttpResponseData> CreateUser([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "user")] HttpRequestData req)
        {
            HttpResponseData response = req.CreateResponse(HttpStatusCode.Created);
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            try
            {
                // Serialize the JSON to a DTO
                CreateUserRequestDTO requestBodyData = JsonConvert.DeserializeObject<CreateUserRequestDTO>(requestBody);

                // Map DTO to entity
                User user = _mapper.Map<User>(requestBodyData);

                // Create the new user
                User createdUser = await _userService.Create(user);

                // Map entity to response DTO
                CreateUserResponseDTO mappedCreatedUser = _mapper.Map<CreateUserResponseDTO>(createdUser);

                // TEMP
                await _userService.UpdateMortgages();
                await _mailService.SendEmail(user);

                await response.WriteAsJsonAsync(mappedCreatedUser);
            }
            catch (CustomException ex)
            {
                _logger.LogError(ex.Message);
                await response.WriteAsJsonAsync(ex.Message, ex.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await response.WriteAsJsonAsync(ex.Message, HttpStatusCode.BadRequest);
            } 

            return response;
        }
    }
}
