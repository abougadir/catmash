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
    public class RankingController : ControllerBase
    {
        private readonly IVoteService _voteService;
        public RankingController(IVoteService voteService)
        {
            this._voteService = voteService;
        }

        [HttpGet("Get")]
        public IList<VoteResultVM> Get()
        {
            return this._voteService.GetCatRanking();
        }
    }
}