using Catmash.Core;
using Catmash.Data;
using Catmash.Utils;
using Catmash.ViewModel;
using System.Collections.Generic;

namespace Catmash.Services
{
    /// <summary>
    /// Cat service
    /// </summary>
    public class CatService : ICatService
    {
        private ApiDbContext _context;

        public CatService(ApiDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Retrieve all cats
        /// </summary>
        /// <returns>list of cats</returns>
        public IList<CatVM> GetAll()
        {
            return this._context.Cats.ToCatVMList();
        }
    }
}
