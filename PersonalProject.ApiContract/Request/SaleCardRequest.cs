using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.ApiContract.Request
{
    public class SaleCardRequest
    {
        public string cardNumber { get; set; }
        public string expiryDateMonth { get; set; }
        public string expiryDateYear { get; set; }
    }
}
