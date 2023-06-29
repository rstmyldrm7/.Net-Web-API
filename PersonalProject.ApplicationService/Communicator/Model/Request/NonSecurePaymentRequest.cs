using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.ApplicationService.Communicator.Model.Request
{
    public class NonSecurePaymentRequest
    {
        public long memberId { get; set; }
        public long merchantId { get; set; }
        public string cardNumber { get; set; }
        public string expiryDateMonth { get; set; }
        public string expiryDateYear { get; set; }
        public string userCode { get; set; }
        public string txnType { get; set; }
        public string installmentCount { get; set; }
        public string currency { get; set; }
        public string orderId { get; set; }
        public string totalAmount { get; set; }
        public string rnd { get; set; }
        public string hash { get; set; }
        public List<OrderProduct> orderProductList { get; set; }
    }

    public class OrderProduct
    {
        public long merchantId { get; set; }
        public string productId { get; set; }
        public string amount { get; set; }
        public string productName { get; set; }
        public string commissionRate { get; set; }
    }
}
