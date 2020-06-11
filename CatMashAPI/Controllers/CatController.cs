using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMashAPI.Core;
using CatMashAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatMashAPI.Controllers
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