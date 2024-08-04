using EventManagementProject.DTOs.QuotationDTO.cs;
using EventManagementProject.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class QuotationController : ControllerBase
    {
        private readonly IPvtQuotationRequestService _pvtQuotationRequestService;
        private readonly  IPvtQuotationResponseService _pvtQuotationResponseService;
        private readonly IPubQuotationRequestService _pubQuotationRequestService;
        private readonly IPubQuotationResponseService _pubQuotationResponseService;


        public QuotationController(IPvtQuotationRequestService pvtQuotationRequestService, IPvtQuotationResponseService pvtQuotationResponseService,IPubQuotationRequestService pubQuotationRequestService,IPubQuotationResponseService pubQuotationResponseService)
        {
            _pvtQuotationRequestService = pvtQuotationRequestService;
            _pvtQuotationResponseService = pvtQuotationResponseService;
            _pubQuotationRequestService = pubQuotationRequestService;
            _pubQuotationResponseService = pubQuotationResponseService;

        }

        [HttpPost("add/pvt")]
        public async Task<IActionResult> AddPvtQuotationRequest(AddPvtQuotationRequestDTO pvtQuotationRequestDto)
        {
            try
            {
                await _pvtQuotationRequestService.AddPvtQuotationRequest(pvtQuotationRequestDto);
                return Ok("Private Quotation Request Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("return/pvt")]
        public async Task<IActionResult> ReturnPvtQuotation()
        {
            try
            {
                var pvtQuotations = await _pvtQuotationRequestService.ReturnPvtQuotation();
                return Ok(pvtQuotations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add/pvt/response")]
        public async Task<IActionResult> AddQuotationResponse(PvtQuotationResponseDTO pvtQuotationResponseDTO)
        {
            try
            {
                await _pvtQuotationResponseService.AddQuotationResponse(pvtQuotationResponseDTO);
                return Ok("Private Quotation Response Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("pvt/response/ByuserId")]
        public async Task<IActionResult> GetPrivateQuotationResponseByUserId(int userId)
        {
            try
            {
                var responses = await _pvtQuotationResponseService.GetQuotationResponseByuserId(userId);
                return Ok(responses);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("pub/response/ByuserId")]
        public async Task<IActionResult> GetPublicQuotationResponseByUserId(int userId)
        {
            try
            {
                var responses = await _pubQuotationResponseService.GetPubQuotationResponseByUserId(userId);
                return Ok(responses);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        [HttpPost("add/pub")]
        public async Task<IActionResult> AddPubQuotationRequest(AddPubQuotationRequestDTO pubQuotationRequestDto)
        {
            try
            {
                await _pubQuotationRequestService.AddPubQuotationRequest(pubQuotationRequestDto);
                return Ok("Public Quotation Request Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/return/pub")]
        public async Task<IActionResult> ReturnPubQuotation()
        {
            try
            {
                var responses = await _pubQuotationRequestService.ReturnPubQuotation();
                return Ok(responses);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("add/pub/response")]
        public async Task<IActionResult> AddPubQuotationResponse(PubQuotationResponseDTO pubQuotationResponseDTO)
        {
            try
            {
                await _pubQuotationResponseService.AddPubQuotationResponse(pubQuotationResponseDTO);
                return Ok("Public Quotation Response Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
