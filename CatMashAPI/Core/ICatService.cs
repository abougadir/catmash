using CatMashAPI.Models;
using CatMashAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashAPI.Core
{
    public interface ICatService
    {
        IList<CatVM> GetAll();

    }
}
