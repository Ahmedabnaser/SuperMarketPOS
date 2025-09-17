using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupermarketPOS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.Domain.Configurations
{
    public class PaymentConfiguration:IEntityTypeConfiguration<Payment>
    {
        public void  Configure(EntityTypeBuilder<Payment> builder) {


        }
    }
}
