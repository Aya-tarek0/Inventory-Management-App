using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Models
{
    public class Transaction
    {
     
            public Guid Id { get; set; }                 
            public Guid ProductId { get; set; }            
            public TransactionType TransactionType { get; set; } 
            public int Quantity { get; set; }               
            public DateTime Date { get; set; }             
            public Guid UserId { get; set; }              
        

    }
 

}
