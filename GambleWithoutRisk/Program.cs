using Spectre.Console;

var balance = new Balance();
Random random = new Random();
string number = string.Empty,
number2 = string.Empty,
number3 = string.Empty;

while (true)
{
    var panel = new Panel($"""
        [bold green]Menu:[/]

        [bold blue]1. Play[/]
        [bold blue]2. Deposit[/]
        [bold blue]3. Withdraw[/]
        [bold blue]4. Exit[/]

        [bold red]GAMBLE WITHOUT RISK[/]
        [bold yellow]Your balance: {balance.balance} AURA [/]
        """);

    AnsiConsole.Render(panel);
    Console.WriteLine("Type your choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            number = random.Next(1, 10).ToString();
            number2 = random.Next(1, 10).ToString();
            number3 = random.Next(1, 10).ToString();

            Console.CursorVisible = false;
            Console.WriteLine("How much do you want to bet?");
            string betAmount = Console.ReadLine();
            int bet;
            if (!int.TryParse(betAmount, out bet))
            {
                AnsiConsole.Write("[bold red]Invalid input. Please enter a number.[/]");
                return;
            }

            balance.balance -= bet;
            Console.WriteLine($"Your balance now: {balance.balance} AURA.");
            Thread.Sleep(2000);

            while (balance.balance > -1)
            {
                if (number == number2 && number2 == number3)
                {
                    AnsiConsole.Write(
                        new Markup("[bold green]" + number + " " + number2 + " " + number3 + "[/]").Centered()
                    );
                    AnsiConsole.Write(
                        new Markup(
                            "[bold]YOU WON GAZILION AURA [green]+1000000000[/] AURA FOR U BRO U ARE AWESOME![/]"
                        ).Centered()
                    );
                    balance.balance += 1000000000;
                    break;
                }
                else
                {
                    balance.balance -= bet;
                    AnsiConsole.Write(
                        new Markup("[bold yellow]" + number + " " + number2 + " " + number3 + "[/]").Centered()
                    );
                    AnsiConsole.Write(new Markup($"[bold]YOU LOST [red]-{bet}[/] AURA[/]").Centered());
                    AnsiConsole.Write(new Markup("[bold yellow]Press ANY key to continue. Press ESC exit. Press B to change bet.[/]").Centered());

                    var key = Console.ReadKey();
                    Console.WriteLine();

                    if (key.Key == ConsoleKey.B)
                    {
                        Console.WriteLine("How much do you want to bet?");
                        betAmount = Console.ReadLine();
                        if (!int.TryParse(betAmount, out bet))
                        {
                            AnsiConsole.Write("[bold red]Invalid input. Please enter a number.[/]");
                            continue;
                        }

                        balance.balance -= bet;
                        Console.WriteLine($"Your balance now: {balance.balance} AURA.");
                        Thread.Sleep(2000);
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        number = random.Next(1, 10).ToString();
                        number2 = random.Next(1, 10).ToString();
                        number3 = random.Next(1, 10).ToString();
                    }

                    Console.Clear();
                }
            }
            break;
        case "2":
            Console.WriteLine("How much do you want to deposit?");
            string depositString = Console.ReadLine();
            int deposit;
            if (int.TryParse(depositString, out deposit))
            {
                balance.balance += deposit;
                Console.WriteLine($"You have deposited {deposit} AURA. Your new balance is {balance.balance} AURA.");
                Thread.Sleep(2000);
            }
            else
            {
                AnsiConsole.Write("[bold red]Invalid input. Please enter a number.[/]");
            }
            break;
        case "3":
            Console.WriteLine("How much do you want to withdraw?");
            string withdrawString = Console.ReadLine();
            Console.WriteLine("Enter your paypal: ");
            string paypal = Console.ReadLine();
            int withdraw;
            if (int.TryParse(withdrawString, out withdraw))
            {
                if (balance.balance - withdraw >= 0)
                {
                    balance.balance -= withdraw;
                    Console.WriteLine($"You have withdrawn {withdraw} AURA. Your new balance is {balance.balance} AURA.");
                    Console.WriteLine($"´We will send aura to your paypal in 5 seconds: {paypal}");
                    Thread.Sleep(5000);
                    Console.WriteLine("SIKEEEE!!!");
                    Environment.Exit(0);
                }
                else
                {
                    AnsiConsole.Write("[bold red]Insufficient balance. Please choose a smaller amount to withdraw.[/]");
                    Thread.Sleep(2000);
                }
            }
            else
            {
                AnsiConsole.Write("[bold red]Invalid input. Please enter a number.[/]");
                Thread.Sleep(2000);
            }
            break;
        case "4":
            Console.WriteLine("Exiting the program...");
            Thread.Sleep(1000);
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            Thread.Sleep(1000);
            break;
    }

    Console.Clear();
}

public class Balance
{
    public int balance { get; set; } = 0;
}
