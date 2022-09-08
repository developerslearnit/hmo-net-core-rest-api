using AvonHMO.Application.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Application.ViewModels.Avon.Explore
{
    public class FAQCategoryViewModel
    {

        public Guid faqCategoryId { get; set; }
        public string description { get; set; }


    }
    
    public class FAQViewModel
    {

        public Guid faqId { get; set; }
        public Guid faqCategoryId { get; set; }
        public string faqCategory { get; set; }
        public string questionText { get; set; }
        public string answerText { get; set; }

    }

    public class FAQFilterParam : PagingParam
    {
        public string searchKey { get; set; }
    }








}
