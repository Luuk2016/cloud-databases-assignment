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
using Microsoft.OpenApi.Models;

namespace LKenselaar.CloudDatabases.API.Controllers
{
    public class MortgageController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMortgageService _mortgageService;
        private readonly IMapper _mapper;

        public MortgageController(ILogger<UserController> log, IMortgageService mortgageService, IMapper mapper)
        {
            _logger = log ?? throw new ArgumentNullException(nameof(log));
            _mortgageService = mortgageService ?? throw new ArgumentNullException(nameof(mortgageService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Function("GetMortgage")]
        [OpenApiOperation(operationId: "GetMortgage", tags: new[] { "GetMortgage" }, Summary = "Get a mortgage by id", Description = "This endpoint returns the mortgage by id")]
        [OpenApiParameter(name: "mortgageId", In = ParameterLocation.Path, Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(CreateUserResponseDTO), Description = "The OK response")]
        public async Task<HttpResponseData> GetMortgageById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "mortgage/{mortgageId}")] HttpRequestData req, Guid mortgageId)
        {
            HttpResponseData response = req.CreateResponse();

            try
            {
                // Get the mortgage
                Mortgage mortgage = await _mortgageService.GetById(mortgageId);

                // Map entity to response DTO
                MortgageResponseDTO mappedMortgage = _mapper.Map<MortgageResponseDTO>(mortgage);

                await response.WriteAsJsonAsync(mappedMortgage);
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
