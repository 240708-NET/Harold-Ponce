class Account{
    String name = "";
    int accountNumber = 0;
    double balance = 0;

    public Account(String name, int accountNumber,double balance){
        this.name = name;
        this.accountNumber = accountNumber;
        this.balance = balance;
    }    

    public int getAccountNumber(){
        return accountNumber;
    }

    public double getBalance(){
        return balance;
    }

    public void setBalance(double balance){
        this.balance = balance;       
    }

    public override string ToString(){
        return "Name: " + name + "\nAccount Number: " + accountNumber + "\nBalance: $" + balance; 
    }
}