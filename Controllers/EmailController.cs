using EmailAPI.Models;
using EmailAPI.Services;
using MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Data;

namespace EmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }



        [HttpPost]
        public async Task<IActionResult> EnviarEmail(EmailData emailData)
        {
            var result = await _emailService.EnviarEmailAsync(emailData);

            if (result)
            {
                return Ok("Email enviado com sucesso.");
            }
            else
            {
                return BadRequest("Falha ao enviar email.");
            }
        }



        [HttpPost]
        [Route("ComAnexo")]
        public async Task<IActionResult> EnviarEmailComAnexo([FromForm] EmailData emailData)
        {
            var result = await _emailService.EnviarEmailComAnexoAsync(emailData);

            if (result)
            {
                return Ok("Email enviado com sucesso.");
            }
            else
            {
                return BadRequest("Falha ao enviar email.");
            }
        }




        [HttpPost]
        [Route("UsandoTemplates")]
        public async Task<IActionResult> EnviarEmailUsandoTemplates([FromForm] EmailData emailData)
        {
            var result = await _emailService.EnviarEmailUsandoTemplatesAsync(emailData);

            if (result)
            {
                return Ok("Email enviado com sucesso.");
            }
            else
            {
                return BadRequest("Falha ao enviar email.");
            }
        }



    }
}
