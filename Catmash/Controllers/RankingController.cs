using Catmash.Core;
using Catmash.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Catmash.Controllers
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