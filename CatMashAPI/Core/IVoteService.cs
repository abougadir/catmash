using CatMashAPI.Models;
using CatMashAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashAPI.Core
{
    public interface IVoteService
    {
        void ChooseWinner(int voteId, User user, bool firstCatWins);

        VoteVM PrepareVote(User user);

        IList<VoteVM> GetAll();

        IList<VoteResultVM> GetCatRanking();

    }
}
