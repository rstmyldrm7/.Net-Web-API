using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.ApplicationService.Communicator.Model.Response
{
    public class NonSecurePaymentResponse
    {
        public bool fail { get; set; }
        public int statusCode { get; set; }
        public NonSecurePaymentResult result { get; set; } 
    }

    public class NonSecurePaymentResult
    {
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public string orderId { get; set; }
        public string txnType { get; set; }
        public string txnStatus { get; set; }
        public int vposId { get; set; }
        public string vposName { get; set; }
        public string authCode { get; set; }
        public string hostReference { get; set; }
        public string totalAmount { get; set; }
    }
}
