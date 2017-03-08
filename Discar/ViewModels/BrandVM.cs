using Discar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discar.ViewModels
{
    public class BrandVM
    {
        public string BrandName { get; set; }
        public List<Disc> Discs { get; set; }

        public BrandVM(DiscContext context, int brandId)
        {
            this.BrandName = context.Brands.Where(b => b.BrandId == brandId).First().BrandName;
            this.Discs = context.Discs.Where(x => x.BrandId == brandId).ToList();
        }
    }
}
