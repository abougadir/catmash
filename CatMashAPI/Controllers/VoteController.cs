using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatMashAPI.Core;
using CatMashAPI.Models;
using CatMashAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CatMashAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public VoteController(IVoteService voteService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this._voteService = voteService;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpGet("NextGame")]
        public async Task<VoteVM> NextGame()
        {
            var currentUser = await GetAuthenticateUser();
            return this._voteService.PrepareVote(currentUser);
        }

        [HttpPut("{voteId}")]
        public async Task<IActionResult> ChooseWinner(int voteId, bool firstCatWins)
        {
            var currentUser = await GetAuthenticateUser();
            this._voteService.ChooseWinner(voteId, currentUser, firstCatWins);
            return Ok();
        }

        private async Task<User> GetAuthenticateUser()
        {
            var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;
            return await _userManager.FindByEmailAsync(email);
        }
    }
}