using BankProjectSSMS.Models;
namespace BankProjectSSMS
{
    class Program{
        public static void Main(string[] args){
            IBankRepository bankRepository = new BankRepository();
            bool check = true;

            while (check)
            {
                Console.WriteLine("Choose you options: ");
                Console.WriteLine("1. Create new account");
                Console.WriteLine("2. Get all account details");
                Console.WriteLine("3. Get Account details");
                Console.WriteLine("4. Deposit amount");
                Console.WriteLine("5. Withdraw amount");
                Console.WriteLine("6. Get all transactions");
                Console.WriteLine("7. Exit");

                int c = Convert.ToInt32(Console.ReadLine());

                switch (c)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter name, address and current balance");
                            string? CustomerName = Console.ReadLine();
                            string? CustomerAdd = Console.ReadLine();
                            int CurrentBalance =Convert.ToInt32(Console.ReadLine());

                            AditiSbAccount newAccount = new()
                            {
                                CustomerName = CustomerName,
                                CustomerAddress = CustomerAdd,
                                CurrentBalance = CurrentBalance
                            };
                            bankRepository.NewAccount(newAccount);

                            break;
                        }
                    case 2:
                        {
                            List<AditiSbAccount>? acc = bankRepository.GetAllAccounts();

                            
                                if (acc != null)
                                {
                                    Console.WriteLine("All Details are below mentioned");
                                    foreach (AditiSbAccount i in acc)
                                    {
                                        Console.WriteLine(i);
                                    }
                                }

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter the account number: ");
                            int accNo = Convert.ToInt32(Console.ReadLine());
                            AditiSbAccount? a = bankRepository.GetAccountDetails(accNo);
                                if (a != null)
                                {
                                    Console.WriteLine("Details");
                                    Console.WriteLine(a);
                                }
                            
                            

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter the account number and amount:");
                            int accNo = Convert.ToInt32(Console.ReadLine());
                            int amount= Convert.ToInt32(Console.ReadLine());
                            bankRepository.DepositAmount(accNo, amount);

                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter the account number and amount: ");
                            int accNo = Convert.ToInt32(Console.ReadLine());
                            int amount= Convert.ToInt32(Console.ReadLine());

                            bankRepository.WithdrawAmount(accNo, amount);

                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter the account number");
                            int accNo = Convert.ToInt32(Console.ReadLine());
                            List<AditiSbTransaction>? t = bankRepository.GetTransactions(accNo);

                                if (t != null)
                                {
                                    Console.WriteLine("All transactions details:");
                                    foreach (AditiSbTransaction transaction in t)
                                    {
                                        Console.WriteLine(transaction);
                                    }
                                }

                            break;
                        }
                    default:
                        check = false;
                        break;
                }
            }
        }
    }
}