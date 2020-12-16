using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Argos.Authentication;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.UsuarioRoot;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.WebApi.ViewModels;
using AutoMapper;

namespace Argos.WebApi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthenticationController : BaseController<Usuario, UsuarioViewModel>
    {
        private readonly IUsuarioService Service;
        private readonly IMapper mapper;

        public AuthenticationController(
            IUnitOfWork unitOfWork,
            IUsuarioService usuarioService,
            IMapper mapper) : base(
            unitOfWork,
            usuarioService,
            mapper
        )
        {
            this.Service = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UsuarioModel item)
        {
            
            if (item == null)
                return BadRequest(new
                {
                    status = 400,
                    message = "Objeto inválido."
                });

            if (ModelState.IsValid)
            {
                var user = await this.Service.AuthenticateAsync(item);
                await _unitOfWork.Commit();
                if (user == null)
                    return BadRequest(new
                    {
                        status = 400,
                        message = "Usuário e/ou senha incorreto(s)."
                    });



                return HttpMessageOk(new
                {
                    status = HttpContext.Response.StatusCode,
                    message = "Autenticado com sucesso.",
                    usuario = new
                    {
                        perfil = user.TipoId,
                        nome = user.Nome,
                        email = user.Email,
                        cpf = user.Cpf,
                        token = TokenGenerator.BuildToken(user.Id, AccessLevel.Usuario)
                    }
                });

            }
            else return BadRequest(new
            {
                status = 400,
                message = ModelState.Values.SelectMany(m => m.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList()
            });
        }
        
        [HttpPost("loginMobile")]
        public async Task<IActionResult> AuthenticateMobileAsync([FromBody] UsuarioModel item)
        {
            
            if (item == null)
                return BadRequest(new
                {
                    status = 400,
                    message = "Objeto inválido."
                });

            if (ModelState.IsValid)
            {
                var user = await this.Service.AuthenticateAsync(item);
                await _unitOfWork.Commit();
                if (user == null)
                    return BadRequest(new
                    {
                        status = 400,
                        message = "Usuário e/ou senha incorreto(s)."
                    });



                return HttpMessageOk(new
                {
                    status = HttpContext.Response.StatusCode,
                    message = "Autenticado com sucesso.",
                    usuario = new
                    {
                        perfil = user.TipoId,
                        nome = user.Nome,
                        email = user.Email,
                        cpf = user.Cpf,
                        token = TokenGenerator.BuildToken(user.Id, AccessLevel.Usuario)
                    }
                });

            }
            else return BadRequest(new
            {
                status = 400,
                message = ModelState.Values.SelectMany(m => m.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList()
            });
        }
    
    }
}