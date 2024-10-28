Console.WriteLine("Welcome to the Grand Circus Casino!");
bool agreePlayAgain = false;
{
    do
    {
        Console.WriteLine("How many sides should each die have?");
        string userInput = Console.ReadLine();
        int userNumber = 0;
        bool validNumber = int.TryParse(userInput, out userNumber); // will return a true or a false - true if an integer, false if unable to parse
        while (validNumber == false)
        {
            Console.WriteLine("Please enter a valid, whole number. Try again");
            userInput = Console.ReadLine();
            validNumber = int.TryParse(userInput, out userNumber);
        }
        Console.WriteLine("Press any key to roll the dice");
        Console.ReadKey(); // waits for the user to press any key to continue
        Console.WriteLine();

        int diceRollOne = GenerateRandomNumber(userNumber);
        Console.WriteLine($"First roll: You rolled a {diceRollOne}");
        int diceRollTwo = GenerateRandomNumber(userNumber);
        Console.WriteLine($"Second roll: You rolled a {diceRollTwo}");
        int total = diceRollOne + diceRollTwo;
        Console.WriteLine($"Your total is: {total}");
        if (userNumber == 6)
        {
            string diceCombiation = HandleSixSidedDice(diceRollOne, diceRollTwo);
                Console.WriteLine(diceCombiation);
            string winnerOrLoser = HandleSixSidedDiceTotals(diceRollOne, diceRollTwo);
                Console.WriteLine(winnerOrLoser);
        }
        Console.WriteLine("Would you like to play again? (y/n)");
        string playAgain = Console.ReadLine();
        if (playAgain.ToLower() == "y")
        {
            agreePlayAgain = true;
        }
        else
        {
            Console.WriteLine("Thanks for playing! Goodbye!");
            break;
        }
    } while (agreePlayAgain == true);
}
static int GenerateRandomNumber(int numberOfSides) // static method to generate random numbers (dont need to type static - implied in VS)
{
    Random random = new Random(); // creates new instance of random
    int number = random.Next(1, numberOfSides + 1); // number from 1 to number of sides + 1 due to upper bound being exclusive
    return number;
}
static string HandleSixSidedDice(int diceOne, int diceTwo)
{
    if (diceOne == 1 && diceTwo == 1)
    { return ("Snake Eyes"); }
    if (diceOne == 1 && diceTwo == 2 || diceOne == 2 && diceTwo == 1)
    { return ("Ace Deuce"); }
    if (diceOne == 6 && diceTwo == 6)
    { return ("Box Cars"); }
    else
    { return ""; }
}
static string HandleSixSidedDiceTotals(int diceOne, int diceTwo)
{
    int total = diceOne + diceTwo;
    if (total == 7 || total == 11)
    { return ("Winner!"); }
    if (total == 2 || total == 3 || total == 12)
    { return ("Craps!"); }
    else
    { return ""; }
}

// What's the difference between an "else" and an "if else"? 

// Both "else" and "if else" statements are typically used in conjunction with an "if" statement. The "if" statement checks a certain condition to be true or false.
// If the "if" statement is found to be false, then the condition of the "if else" statement will be checked and the code will be executed if found to be true.
// If the "if else" is also found to be false, then the code within the "else" statement will be executed by default.