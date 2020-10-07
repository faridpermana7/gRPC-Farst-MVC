using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcFarstMvc.Utility
{
    public class Pagination
    {
        public List<SelectListItem> PageSizeList
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem() { Value="5", Text= "5" },
                    new SelectListItem() { Value="10", Text= "10" },
                    new SelectListItem() { Value="15", Text= "15" },
                    new SelectListItem() { Value="25", Text= "25" },
                    new SelectListItem() { Value="50", Text= "50" },
                };
            }
        }
    }
}
