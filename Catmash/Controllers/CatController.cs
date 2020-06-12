using Catmash.Core;
using Catmash.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Catmash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {

        readonly ICatService _catService;

        public CatController(ICatService catService)
        {
            this._catService = catService;
        }

        [HttpGet("GetAll")]
        [ResponseCache(Duration = 60)]
        public IList<CatVM> GetAll()
        {
            return this._catService.GetAll();
        }
    }
}