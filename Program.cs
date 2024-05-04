using System;
using System.Security.Cryptography.X509Certificates;

public class cardID
{
    String cardNum;
    int pinCode;
    String firstName;
    String lastName;
    double balance;


    public cardID(string cardNum, int pin, string firstName, string lastName, double balance)

    {
        this.cardNum = cardNum;
        this.pinCode = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pinCode;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;

        
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pinCode = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String [] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");


        }

        void deposit(cardID currentUser)
        {

            Console.WriteLine("How much $ would you like to deposit:");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $ Your new balance is : " + currentUser.getBalance()); 


        }

        void withdraw(cardID currentUser)
        {
            Console.WriteLine("How much $ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //Check if the user has enoungh money
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else 
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you :)");
            }



        }

        void balance(cardID currentUser)
        {
            Console.WriteLine("Current Balance : " + currentUser.getBalance());

        }

        List<cardID> cardIDs = new List<cardID>();
        cardIDs.Add(new cardID("4532772818527123", 1235, "Glody", "Mbatu", 250.31));
        cardIDs.Add(new cardID("4632772818527456", 1234, "David", "Tube", 321.15));
        cardIDs.Add(new cardID("4732772818527789", 1234, "Garcia", "Smith", 859.347));
        cardIDs.Add(new cardID("4832772818527958", 1234, "Joel", "kane", 118.731));
        cardIDs.Add(new cardID("4932772818527632", 1234, "Christine", "Angel", 68.12));

         //Prompt user 
        Console.WriteLine("Welcome to Cash point ATM");
        Console.WriteLine("Please insert your debit");
        String debitCardNum = "";
        cardID currentUser;

        while(true)
        {
            try{
                debitCardNum = Console.ReadLine();
                // Check on our db list
                currentUser = cardIDs.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) {break;}
                else { Console.WriteLine("card not recognized. Please try again"); }
            }

            catch{ Console.WriteLine("card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin:");
        int userPin = 0;

        while(true)
        {
            try{
                userPin = int.Parse(Console.ReadLine());
            
                if (currentUser.getPin() == userPin) {break;}
                else { Console.WriteLine("Incorrect pin. Please try again."); }
            }

            catch{ Console.WriteLine("Incorrect pin. Please try again."); }
        } 

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }

            catch {}
            if(option == 1) { deposit(currentUser);}
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }
            


            
        }
        while (option != 4);
        Console.WriteLine("Thank you! See you soon :)");


         


    }



}