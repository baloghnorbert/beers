using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using Backend.Core.Constans;
using Backend.Core.Enums;
using Backend.Core.Modell.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Backend.Core.Modell.Request;
using System.Threading.Tasks;
using System.Linq;

namespace Backend.API.Controllers
{
    [ApiController]
    public partial class BeerController : ControllerBase
    {
        private static List<Beer> _data = null;

        static BeerController()
        {
            _data = FetchData().Result;
        }

        public BeerController()
        {
        }

        [ApiExplorerSettings(GroupName = ApplicationSettingsConstans.PublicAPI)]
        [SwaggerOperation(OperationId = "beers")]
        [Route("api/v{version:apiVersion}/beers/get-all")]
        [ApiVersion(ApplicationSettingsConstans.ActiveVersion)]
        [HttpGet]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(List<Beer>))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]
        public List<Beer> GetAll()
        {
            try
            {
                return _data;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [ApiExplorerSettings(GroupName = ApplicationSettingsConstans.PublicAPI)]
        [SwaggerOperation(OperationId = "paged")]
        [Route("api/v{version:apiVersion}/beers/page/{page}")]
        [ApiVersion(ApplicationSettingsConstans.ActiveVersion)]
        [HttpGet]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(List<Beer>))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]
        public List<Beer> Page([FromRoute] [Required] int page = 0)
        {
            try
            {
                return _data.Skip(page * 10)
                             .Take(10)
                             .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [ApiExplorerSettings(GroupName = ApplicationSettingsConstans.PublicAPI)]
        [SwaggerOperation(OperationId = "byId")]
        [Route("api/v{version:apiVersion}/beers/get/{id}")]
        [ApiVersion(ApplicationSettingsConstans.ActiveVersion)]
        [HttpGet]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(Beer))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]
        public Beer GetById([FromRoute] [Required] int id)
        {
            try
            {
                return GetBeerById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [ApiExplorerSettings(GroupName = ApplicationSettingsConstans.PublicAPI)]
        [SwaggerOperation(OperationId = "delete")]
        [Route("api/v{version:apiVersion}/beers/delete/{id}")]
        [ApiVersion(ApplicationSettingsConstans.ActiveVersion)]
        [HttpDelete]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]
        public bool Delete([FromRoute][Required] int id)
        {
            try
            {
                DeletBeer(id);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [ApiExplorerSettings(GroupName = ApplicationSettingsConstans.PublicAPI)]
        [SwaggerOperation(OperationId = "crate")]
        [Route("api/v{version:apiVersion}/beers/create")]
        [ApiVersion(ApplicationSettingsConstans.ActiveVersion)]
        [HttpPost]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(Beer))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]
        public Beer CreateAsync([FromBody] [Required] BeerRequest requestParam)
        {
            try
            {
                Beer beer = AddBeer(requestParam);
                return beer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [ApiExplorerSettings(GroupName = ApplicationSettingsConstans.PublicAPI)]
        [SwaggerOperation(OperationId = "update")]
        [Route("api/v{version:apiVersion}/beers/update")]
        [ApiVersion(ApplicationSettingsConstans.ActiveVersion)]
        [HttpPut]
        [ProducesResponseType((int)HttpResponseType.OK, Type = typeof(Beer))]
        [ProducesResponseType((int)HttpResponseType.BadRequest)]
        [Produces("application/json")]
        public Beer UpdateAsync([FromBody][Required] Beer requestParam)
        {
            try
            {
                Beer beer = UpdateBeer(requestParam);
                return beer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
