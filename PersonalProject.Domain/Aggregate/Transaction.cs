using PersonalProject.Domain.Entities;
using PersonalProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Domain.Aggregate
{
    public class Transaction : Entity
    {
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public TransactionType TypeId { get; set; }
        public decimal Amount { get; set; }
        public string CardPan { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public Transaction(string customerId, string orderId, TransactionType typeId, decimal amount, string cardPan)
        {
            CustomerId = customerId;
            OrderId = orderId;
            TypeId = typeId;
            Amount = amount;
            CardPan = cardPan;
        }
        public void SetTransactionComplete(string responseCode, string responseMessage)
        { 
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
        }
    }
}
