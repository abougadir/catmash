using CatMashAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashAPI.ViewModel
{
    public class VoteVM
    {
        public int Id { get; set; }

        public CatVM FirstCat { get; set; }

        public CatVM SecondCat { get; set; }

        //public CatVM WinnerCat { get; set; }

        //public User User;
    }
}
