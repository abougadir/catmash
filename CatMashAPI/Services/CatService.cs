using CatMashAPI.Core;
using CatMashAPI.Data;
using CatMashAPI.Utils;
using CatMashAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashAPI.Services
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
