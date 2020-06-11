using CatMashAPI.Core;
using CatMashAPI.Data;
using CatMashAPI.Models;
using CatMashAPI.Utils;
using CatMashAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashAPI.Services
{
    public class VoteService : IVoteService
    {
        private ApiDbContext _context;

        public VoteService(ApiDbContext context)
        {
            this._context = context;
        }

        public void ChooseWinner(int voteId, User currentUser, bool firstCatWins)
        {
            if (voteId < 1) throw new ArgumentNullException("Vous n'avez pas renseigner le vote !");
            else
            {
                Vote voteDal = this._context.Votes.Include(v => v.FirstCat).Include(v=>v.SecondCat).FirstOrDefault(x => x.Id == voteId);
                if (voteDal != null)
                {
                    if (voteDal.User?.Id == currentUser.Id)
                    {
                        voteDal.Winner = firstCatWins ? voteDal.FirstCat : voteDal.SecondCat;
                        this._context.Update(voteDal);
                        if (this._context.SaveChanges() == 0)
                        {
                            throw new Exception("Erreur lors de l'enregistrement du chat vainqueur !");
                        }
                    }
                    else
                    {
                        throw new Exception("Vous n'avez pas de droit sur ce vote !");
                    }
                }
                else
                {
                    throw new Exception("Ce vote n'existe pas !");
                }
                
            }
        }

        public IList<VoteVM> GetAll()
        {
            return this._context.Votes.ToVoteVMList();
        }

        public IList<VoteResultVM> GetCatRanking()
        {
            var cats = this._context.Cats.ToList();
            var votes = this._context.Votes.Include(v => v.Winner).ToList();
            List<VoteResultVM> voteResults = new List<VoteResultVM>();

            foreach (var cat in cats)
            {
                VoteResultVM resultVote = new VoteResultVM
                {
                    Cat = cat.ToCatVM()
                };

                resultVote.TotalVote = (votes != null) ? votes.Where(x => x.Winner?.Id == cat.Id).Count() : 0;
                voteResults.Add(resultVote);
            }

            return voteResults.OrderByDescending(x => x.TotalVote).ToList();
        }

        public VoteVM PrepareVote(User user)
        {
            var cats = this._context.Cats.ToList();
            int lastIndex = cats.Count() - 1;

            // Choisir deux chats differents
            Cat firstCat = cats[RandomNumber(0, lastIndex)];
            Cat secondCat = cats[RandomNumber(0, lastIndex)];
            while (firstCat == secondCat)
            {
                secondCat = cats.ElementAt(RandomNumber(0, lastIndex));
            }

            // Suppression des votes inachevés
            var voteToClear = this._context.Votes.Include(v => v.Winner).Where(x => x.User.Id == user.Id && x.Winner == null);
            this._context.RemoveRange(voteToClear);
            this._context.SaveChanges();

            // Initialisation des chats prise pour le vote
            Vote vote = new Vote
            {
                FirstCat = firstCat,
                SecondCat = secondCat,
                User = user
            };

            this._context.Votes.Add(vote);
            if (this._context.SaveChanges() > 0)
            {
                return vote.ToVoteVM();
            } else {
                throw new Exception("Erreur lors de la creation du vote");
            }
        }

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random(); 
            return random.Next(min, max);
        }
    }
}
