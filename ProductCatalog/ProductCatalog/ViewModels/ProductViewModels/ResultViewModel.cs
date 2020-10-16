using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.ViewModels.ProductViewModels
{
    public class ResultViewModel
    {
        public bool Sucess { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
