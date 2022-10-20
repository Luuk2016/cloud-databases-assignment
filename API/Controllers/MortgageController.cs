using System.Net;
using AutoMapper;
using LKenselaar.CloudDatabases.Models.DTO;
using LKenselaar.CloudDatabases.Services;
using LKenselaar.CloudDatabases.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace LKenselaar.CloudDatabases.API.Controllers
{
    public class MortgageController
    {
        private readonly ILogger<UserController> _logger;
        private readonly MortgageService _mortgageService;
        private readonly IMapper _mapper;
        public MortgageController(ILogger<UserController> log, MortgageService mortgageService, IMapper mapper)
        {
            _logger = log ?? throw new ArgumentNullException(nameof(log));
            _mortgageService = mortgageService ?? throw new ArgumentNullException(nameof(mortgageService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Function("GetMortgage")]
        [OpenApiOperation(operationId: "GetMortgage", tags: new[] { "GetMortgage" }, Summary = "Get a mortgage by id", Description = "This endpoint returns the mortgage by id")]
        [OpenApiParameter(name: "mortgageId", In = ParameterLocation.Path, Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(CreateUserResponseDTO), Description = "The OK response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.NotFound, contentType: "application/json", bodyType: typeof(CreateUserResponseDTO), Description = "The NOT FOUND response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(CreateUserResponseDTO), Description = "The BAD REQUEST response")]
        public async Task<IActionResult> GetMortgageById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "mortgage/{mortgageId}")] HttpRequestData req, Guid mortgageId)
        {
            try
            {
                // TODO, get the mortgage
                var mortgage = await _mortgageService.GetById(mortgageId);

                // Map Entity to response DTO 
                var response = _mapper.Map<MortgageResponseDTO>(mortgage);

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
