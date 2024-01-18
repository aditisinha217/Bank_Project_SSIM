using System;
using System.Collections.Generic;

namespace BankProjectSSMS.Models;

public partial class AditiSbTransaction
{
    public int TransactionId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public int? AccountNumber { get; set; }

    public int? Amount { get; set; }

    public string? TransactionType { get; set; }

    public virtual AditiSbAccount? AccountNumberNavigation { get; set; }
}
