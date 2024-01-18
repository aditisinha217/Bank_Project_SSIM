using BankProjectSSMS.Models;

namespace BankProjectSSMS;

class BankRepository : IBankRepository
{
    private readonly Ace52024Context db;
    public BankRepository(Ace52024Context _db){
        db=_db;
    }

    public BankRepository()
    {
    }

    public void NewAccount(AditiSbAccount acc)
    {
        db.AditiSbAccounts.Add(acc);
        db.SaveChanges();
    }

    

    public AditiSbAccount GetAccountDetails(int accno)
    {
        AditiSbAccount a=db.AditiSbAccounts.Where(x=> x.AccountNumber==accno).FirstOrDefault();
        return a;
    }

    public void DepositAmount(int accno, int amt)
    {
        AditiSbAccount a=db.AditiSbAccounts.Where(x=> x.AccountNumber==accno).FirstOrDefault();
        if(a!=null){
            a.CurrentBalance+=amt;
            db.AditiSbAccounts.Update(a);
            AditiSbTransaction at=db.AditiSbTransactions.Where(x=>x.AccountNumber==accno).FirstOrDefault();
            at.TransactionType="Deposit";
            at.TransactionDate=DateTime.Now;
            db.AditiSbTransactions.Add(at);
            db.SaveChanges();
            Console.WriteLine("Yay!! Deposited successfully");
        }
    }

    public void WithdrawAmount(int accno, int amt)
    {
        AditiSbAccount a=db.AditiSbAccounts.Where(x=> x.AccountNumber==accno).FirstOrDefault();
        if(a!=null){
            a.CurrentBalance-=amt;
            db.AditiSbAccounts.Update(a);
            AditiSbTransaction at=db.AditiSbTransactions.Where(x=>x.AccountNumber==accno).FirstOrDefault();
            at.TransactionType="Deposit";
            at.TransactionDate=DateTime.Now;
            db.AditiSbTransactions.Add(at);
            db.SaveChanges();
            Console.WriteLine("Yay!! Withdrawn successfully");
        }
    }

    public List<AditiSbTransaction> GetTransactions(int accno)
    {
        var list=db.AditiSbTransactions.Where(x=>x.AccountNumber==accno).ToList();
        return list;
    }


    public List<AditiSbAccount> GetAllAccounts()
    {
        var list=db.AditiSbAccounts.Where(x=>true).ToList();
        return list;
    }

    public void DepositAmount(int accno, decimal amt)
    {
        throw new NotImplementedException();
    }

    public void WithdrawAmount(int accno, decimal amt)
    {
        throw new NotImplementedException();
    }
}