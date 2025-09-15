using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketPOS.Domain.Enums;

namespace SupermarketPOS.Domain.Entites
{
    public class Payment : BaseEntity
    {

        public Guid SaleId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string CardType { get; set; }
        public string TransactionId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public Sale? Sale { get; set; }
    }
    
}

