using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Entities
{

    public class FAQCategory : BaseEntity
    {
        public Guid FAQCategoryId { get; set; }
        public string Description { get; set; }
       

    }
}
