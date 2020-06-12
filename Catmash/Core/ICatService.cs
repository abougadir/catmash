using Catmash.ViewModel;
using System.Collections.Generic;

namespace Catmash.Core
{
    public interface ICatService
    {
        IList<CatVM> GetAll();

    }
}
