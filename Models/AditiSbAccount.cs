using System;
using System.Collections.Generic;

namespace BankProjectSSMS.Models;

public partial class AditiSbAccount
{
    public int AccountNumber { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public int? CurrentBalance { get; set; }

    public virtual ICollection<AditiSbTransaction> AditiSbTransactions { get; set; } = new List<AditiSbTransaction>();
}
