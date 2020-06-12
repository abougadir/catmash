using Catmash.Models;
using Catmash.ViewModel;
using System.Collections.Generic;

namespace Catmash.Core
{
    public interface IVoteService
    {
        void ChooseWinner(int voteId, User user, bool firstCatWins);

        VoteVM PrepareVote(User user);

        IList<VoteVM> GetAll();

        IList<VoteResultVM> GetCatRanking();

    }
}
