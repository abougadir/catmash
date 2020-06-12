using System.Collections.Generic;
using System.Linq;

namespace Catmash.Utils
{
    public static class Assembler
    {
        #region Cat

        public static Models.Cat ToCatDal(this ViewModel.CatVM catVM)
        {
            return (catVM == null) ? null : new Models.Cat
            {
                Id = catVM.Id,
                ImageUrl = catVM.ImageUrl,
                Key = catVM.Key
            };
        }

        public static ViewModel.CatVM ToCatVM(this Models.Cat cat)
        {
            return (cat == null) ? null : new ViewModel.CatVM
            {
                Id = cat.Id,
                ImageUrl = cat.ImageUrl,
                Key = cat.Key
            };
        }

        public static IList<Models.Cat> ToCatDalList(this IEnumerable<ViewModel.CatVM> catVMList)
        {
            if (catVMList == null || catVMList.Count() == 0)
            {
                return null;
            }
            else
            {
                return catVMList.ToList().ConvertAll(x => x.ToCatDal());
            }
        }

        public static IList<ViewModel.CatVM> ToCatVMList(this IEnumerable<Models.Cat> catList)
        {
            if (catList == null || catList.Count() == 0)
            {
                return null;
            }
            else
            {
                return catList.ToList().ConvertAll(x => x.ToCatVM());
            }
        }

        #endregion

        #region Vote

        public static Models.Vote ToVoteDal(this ViewModel.VoteVM voteVM)
        {
            return (voteVM == null) ? null : new Models.Vote
            {
                Id = voteVM.Id,
                FirstCat = voteVM.FirstCat.ToCatDal(),
                SecondCat = voteVM.SecondCat.ToCatDal(),
                //Winner = voteVM.WinnerCat.ToCatDal(),
                //User = voteVM.User
            };
        }

        public static ViewModel.VoteVM ToVoteVM(this Models.Vote vote)
        {
            return (vote == null) ? null : new ViewModel.VoteVM
            {
                Id = vote.Id,
                FirstCat = vote.FirstCat.ToCatVM(),
                SecondCat = vote.SecondCat.ToCatVM(),
                //WinnerCat = vote.Winner.ToCatVM(),
                //User = vote.User
            };
        }

        public static IList<Models.Vote> ToVoteDalList(this IEnumerable<ViewModel.VoteVM> voteVMList)
        {
            if (voteVMList == null || voteVMList.Count() == 0)
            {
                return null;
            }
            else
            {
                return voteVMList.ToList().ConvertAll(x => x.ToVoteDal());
            }
        }

        public static IList<ViewModel.VoteVM> ToVoteVMList(this IEnumerable<Models.Vote> voteList)
        {
            if (voteList == null || voteList.Count() == 0)
            {
                return null;
            }
            else
            {
                return voteList.ToList().ConvertAll(x => x.ToVoteVM());
            }
        }

        #endregion

    }
}
