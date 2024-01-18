using BankProjectSSMS.Models;

namespace BankProjectSSMS;

interface IBankRepository{
    public void NewAccount(AditiSbAccount acc);
    List<AditiSbAccount> GetAllAccounts();
    AditiSbAccount GetAccountDetails(int accno);
    public void DepositAmount(int accno, decimal amt);
    public void WithdrawAmount(int accno, decimal amt);
    List<AditiSbTransaction> GetTransactions(int accno);
}