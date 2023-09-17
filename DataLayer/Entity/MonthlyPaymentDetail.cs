using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace DataLayer.Entity
{
    public class MonthlyPaymentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
       
        public int mortageId { get; set; }
       
        public DateTime paymentDate { get; set; }
        public double remainingBalance { get; set; }
        public double principalAmt { get; set; }
        public double monthlyInterest { get; set; }
        public double monthlyPayment{ get; set; }
        public double totalInterest { get; set; }
        public double totalPaid {  get; set; }

        [ForeignKey("mortageId")]
        public MortgageDetail mortgageDetail { get; set; } = null!;

        public MonthlyPaymentDetail(DateTime paymentDate, double remainingBalance, double principalAmt, double monthlyInterest, double monthlyPayment, double totalInterest, double totalPaid)
        {
            this.paymentDate = paymentDate;
            this.remainingBalance = remainingBalance;
            this.principalAmt = principalAmt;
            this.monthlyInterest = monthlyInterest;
            this.monthlyPayment = monthlyPayment;
            this.totalInterest = totalInterest;
            this.totalPaid = totalPaid;
        }
    }
}
