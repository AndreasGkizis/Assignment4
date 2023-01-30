using Assignment4Final.Services;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models.DTO;
using ModelLibrary.Models.DTO.Certificates;

namespace Assignment4Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly CertificatesService _certificateService;

        public CertificatesController(CertificatesService certificateService)
        {
            _certificateService = certificateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var certificates = await _certificateService.GetAllAsync();
            var response = new BaseResponse<List<CertificateDto>>
            {
                RequestId = Request.HttpContext.TraceIdentifier,
                Success = true,
                Data = certificates
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var certificate = await _certificateService.GetAsync(id);
            if (certificate == null)
            {
                return NotFound(
                    new BaseResponse<CertificateDto>
                    {
                        RequestId = Request.HttpContext.TraceIdentifier,
                        Success = false,
                        Message = $"Certificate with id {id} not found."
                    }
                );
            }

            var response = new BaseResponse<CertificateDto>
            {
                RequestId = Request.HttpContext.TraceIdentifier,
                Success = true,
                Data = certificate
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CertificateDto certificateDto)
        {
            var addedCertificate = await _certificateService.AddAsync(certificateDto);
            if (addedCertificate == null)
            {
                return BadRequest(
                    new BaseResponse<CertificateDto>
                    {
                        RequestId = Request.HttpContext.TraceIdentifier,
                        Success = false,
                        Message = "Failed to add certificate."
                    }
                );
            }

            var response = new BaseResponse<CertificateDto>
            {
                RequestId = Request.HttpContext.TraceIdentifier,
                Success = true,
                Data = addedCertificate
            };

            return CreatedAtAction(nameof(Get), new { id = addedCertificate.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CertificateDto certificateDto)
        {
            var updatedCertificate = await _certificateService.UpdateAsync(id, certificateDto);
            if (updatedCertificate == null)
            {
                return NotFound(
                    new BaseResponse<CertificateDto>
                    {
                        RequestId = Request.HttpContext.TraceIdentifier,
                        Success = false,
                        Message = "Certificate not found"
                    }
                );
            }

            var response = new BaseResponse<CertificateDto>
            {
                RequestId = Request.HttpContext.TraceIdentifier,
                Success = true,
                Data = updatedCertificate
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedCertificate = await _certificateService.DeleteAsync(id);
            if (deletedCertificate == null)
            {
                return NotFound(
                    new BaseResponse<CertificateDto>
                    {
                        RequestId = Request.HttpContext.TraceIdentifier,
                        Success = false,
                        Message = "Certificate not found"
                    }
                );
            }

            var response = new BaseResponse<CertificateDto>
            {
                RequestId = Request.HttpContext.TraceIdentifier,
                Success = true,
                Data = deletedCertificate
            };

            return Ok(response);
        }
    }
}