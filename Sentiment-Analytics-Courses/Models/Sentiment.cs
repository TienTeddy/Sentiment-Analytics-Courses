using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sentiment_Analytics_Courses.Models
{
    public class Sentiment
    {
        [Required(ErrorMessage ="Bạn cần nhập dữ liệu")]
        public string sentiment { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập dữ liệu Text")]
        public string sentimentText { get; set; }

        public bool checkbox { get; set; }
    }
}
