using System.Transactions;

namespace Final_CSharp_Assignment
{
    public class Transaction
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
    public class TrackerApp
    {
        List<Transaction> trans;
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public TrackerApp()
        {
            trans = new List<Transaction>();
        }

        public void AddTrans()
        {
            Console.Write("Enter the Title of Transaction: ");
            string title = Console.ReadLine();

            Console.Write("Enter the Description of Transaction: ");
            string description = Console.ReadLine();

            decimal amount = 0;
            try
            {
                Console.Write("Enter the Amount of Transaction: ");
                amount = decimal.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Amount will be only Integers!");
            }

            DateTime date = new DateTime();
            try
            {
                Console.Write("Enter Date(DD/MM/YYYY): ");
                date = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Enter Correct Date Format!");
            }

            if (amount >= 0)
            {
                Income += amount;
            }
            else
            {
                Expenses += Math.Abs(amount);
            }

            trans.Add(new Transaction() { Title = title, Description = description, Amount = amount, Date = date });
            Console.WriteLine("Transaction Added Successfully");
            Console.WriteLine();
        }

        public void ShowExpenses()
        {
            Console.WriteLine("Title\tDescription\tAmount\tDate");
            foreach (Transaction transaction in trans)
            {
                if (transaction.Amount < 0)
                {
                    Console.WriteLine($"{transaction.Title}\t{transaction.Description}   \t{transaction.Amount}   \t{transaction.Date}");
                }
            }
            Console.WriteLine();
        }
        public void ShowIncome()
        {
            Console.WriteLine("Title\tDescription\tAmount\tDate");
            foreach (Transaction transaction in trans)
            {
                if (transaction.Amount >= 0)
                {
                    Console.WriteLine($"{transaction.Title}\t{transaction.Description}  \t{transaction.Amount}  \t{transaction.Date}");
                }
            }
            Console.WriteLine();
        }

        public void ShowBalance()
        {
            decimal Balance = ((Income) - (Expenses));
            Console.WriteLine(Balance);
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TrackerApp t = new TrackerApp();
            string ret = "y";
            do
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. View Income");
                Console.WriteLine("4. View Balance");
                int choice = 0;
                try
                {
                    Console.WriteLine("Enter Your choice: ");
                    choice = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter only Numbers");
                }
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the data of the Transaction");
                            t.AddTrans();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("The total Expenses recoreded so far are given below :");
                            t.ShowExpenses();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("The total Income recoreded so far is given below :");
                            t.ShowIncome();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("The total Balance remaining so far is given below :");
                            t.ShowBalance();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong Choice Entered");
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue? [y/n] ");
                ret = Console.ReadLine();
            } while (ret.ToLower() == "y");
        }
    }
}
 