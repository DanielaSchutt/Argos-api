using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Argos.Domain.BaseRoot;
using Argos.Domain.Interfaces.ServiceInterfaces;
using Argos.Domain.Interfaces.RepositoryInterfaces;
using Argos.Authentication;
using Argos.WebApi.ViewModels;

namespace Argos.WebApi.Controllers
{    
    public abstract class BaseController<TEntity, TEntityMapper> : ControllerBase
        where TEntity : Entity
        where TEntityMapper : EntityViewModel
    {
        private const int HTTP_STATUS_CODE_SUCESSO = 200;
        private const int HTTP_STATUS_CODE_ERRO_GERAL = 400;
        private const int HTTP_STATUS_CODE_ERRO_NAO_AUTORIZADO = 401;

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IBaseService<TEntity> _baseService;

        public BaseController(
            IUnitOfWork unitOfWork,
            IBaseService<TEntity> service,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._baseService = service;
            this._mapper = mapper;
        }

        [NonAction]
        public virtual async Task<IActionResult> _GetAllAsync()
        {
            var item = await _baseService.GetAllAsync();
            var itemVM = _mapper.Map<List<TEntityMapper>>(item);

            return HttpMessageOk(itemVM);
        }

        [NonAction]
        public virtual async Task<IActionResult> _GetByIdAsync(long id)
        {
            var item = await _baseService.GetByIdAsync(id);
            var itemVM = _mapper.Map<TEntityMapper>(item);

            if (item == null)
            {
                return HttpMessageError("Id inválido");
            }

            return HttpMessageOk(itemVM);
        }

        [NonAction]
        public virtual async Task<IActionResult> _AddAsync([FromBody] TEntity item)
        {
            if (item == null)
            {
                return HttpMessageError("Objeto inválido.");
            }

            _baseService.Add(item);
            await _unitOfWork.Commit();

            return HttpMessageOk(item);
        }

        [NonAction]
        public virtual async Task<IActionResult> _UpdateAsync(long id, [FromBody] TEntity item)
        {
            if (item == null)
            {
                return HttpMessageError("Objeto inválido.");
            }

            _baseService.Update(item);
            await _unitOfWork.Commit();

            return HttpMessageOk(item);
        }

        [NonAction]
        public virtual async Task<IActionResult> _RemoveAsync(long id)
        {
            var item = await _baseService.GetByIdAsync(id);

            if (item == null)
            {
                return HttpMessageError("Id inválido.");
            }

            _baseService.Remove(item);
            await _unitOfWork.Commit();

            return HttpMessageOk("Deletado com sucesso");
        }

        protected IActionResult HttpMessageOk(dynamic data)
        {
            return Ok(new
            {
                status = HTTP_STATUS_CODE_SUCESSO,
                data = data,
                //token = RebuildTokenDefault()
            });
        }

        protected IActionResult HttpMessageError(string message = "", int HTTP_STATUS_CODE = HTTP_STATUS_CODE_ERRO_GERAL)
        {
            return BadRequest(new
            {
                status = HTTP_STATUS_CODE,
                message = message
            });
        }

        protected string GetTokenDefault()
        {
            return Request.Headers["Authorization"];
        }

        protected string RebuildTokenDefault()
        {
            string token = GetTokenDefault();

            return TokenGenerator.ReBuildToken(token);
        }
    }
}