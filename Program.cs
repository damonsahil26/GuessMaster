
using GuessMaster.Utilities;

Console.Clear();
WelcomeText();
Console.WriteLine("\nPlease enter your name : ");
var playerName = Console.ReadLine();
Console.Clear();
PrintPlayerName(playerName);

void PrintPlayerName(string? playerName)
{
    ConsoleMessage.PrintPlayerNameMessage("*********************************");
    ConsoleMessage.PrintPlayerNameMessage($"   * Welcome  {playerName}!!   *");
    ConsoleMessage.PrintPlayerNameMessage("*********************************");
}

Task.Delay(2000).Wait();
ConsoleMessage.PrintCommandMessage("Please select the difficulty level: ");
DifficultySelectionMenu();
Random rnd = new Random();
int answer = rnd.Next(1, 30);
while (true)
{
    Console.WriteLine("\nEnter your difficulty level : ");
    var level = Console.ReadLine();
    int totalTries = 0;
    if (!ValidNumber(level))
    {
        ConsoleMessage.PrintErrorMessage("Wrong input given. Please enter difficulty level from 1 to 3.");
        continue;
    }
    Int32.TryParse(level, out var levelInt);

    var currentLevelSelected = FindLevelSelected(levelInt);
    if (currentLevelSelected != null && !string.IsNullOrEmpty(currentLevelSelected))
    {
        totalTries = GetTotalTries(currentLevelSelected);
        ConsoleMessage.PrintInfoMessage($"You have selected {currentLevelSelected} mode. You have {totalTries} chances to guess the number.");
        ConsoleMessage.PrintErrorMessage($"Good Luck :)");
        Task.Delay(5000).Wait();
        Console.Clear();
    }
    else
    {
        ConsoleMessage.PrintErrorMessage("Wrong input given. Please enter number from 1 to 3.");
        continue;
    }

    ConsoleMessage.PrintMessage($"Lets start the game :)");
    ConsoleMessage.PrintInfoMessage("I'm thinking of a number between 1 and 30.");
    int count = 0;
    bool winner = false;
    while (count < totalTries)
    {
        var chancesLeft = totalTries - count;
        string oridnalName = Utility.GetOrdinalString(count + 1);
        ConsoleMessage.PrintCommandMessage($"\nTotal chances left : {chancesLeft}");
        Console.WriteLine($"\nEnter your {oridnalName} guess {playerName} : ");
        var guess = Console.ReadLine();
        if (!ValidNumber(guess))
        {
            ConsoleMessage.PrintErrorMessage("Wrong input given. Please enter a valid number");
            continue;
        }
        Console.Clear();
        Int32.TryParse(guess, out var guessedNumber);

        if (guessedNumber == answer)
        {
            ConsoleMessage.PrintCongratulatoryMessage("**************************************");
            ConsoleMessage.PrintCongratulatoryMessage("*                                    *");
            ConsoleMessage.PrintCongratulatoryMessage("*        CONGRATULATIONS!            *");
            ConsoleMessage.PrintCongratulatoryMessage("*  You've guessed the right number!  *");
            ConsoleMessage.PrintCongratulatoryMessage("*                                    *");
            ConsoleMessage.PrintCongratulatoryMessage("**************************************");
            winner = true;
            break;
        }
        else
        {
            PrintWrongAnswerMessage(guessedNumber, answer);
        }

        count++;
    }

    if(!winner) PrintGameOverMessage();
    break;
}

void PrintGameOverMessage()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("****************************************");
    Console.WriteLine("*                                      *");
    Console.WriteLine("*            GAME OVER!                *");
    Console.WriteLine("*                                      *");
    Console.WriteLine("*    You've run out of chances.        *");
    Console.WriteLine($"*     The correct number was {answer}.       *");
    Console.WriteLine("*     Please restart the game.         *");
    Console.WriteLine("*                                      *");
    Console.WriteLine("****************************************");
    Console.ResetColor();
}

void PrintWrongAnswerMessage(int guessedNumber, int answer)
{
    if(guessedNumber < answer)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("****************************************");
        Console.WriteLine("*                                      *");
        Console.WriteLine("*            WRONG ANSWER!             *");
        Console.WriteLine("*         Please try again!!           *");
        Console.WriteLine($"*  Hint: The number is greater than {guessedNumber}.*");
        Console.WriteLine("*                                      *");
        Console.WriteLine("****************************************");
        Console.ResetColor();
    }

    if (guessedNumber > answer)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("****************************************");
        Console.WriteLine("*                                      *");
        Console.WriteLine("*            WRONG ANSWER!             *");
        Console.WriteLine("*         Please try again!!           *");
        Console.WriteLine($"*  Hint: The number is smaller than {guessedNumber}.*");
        Console.WriteLine("*                                      *");
        Console.WriteLine("****************************************");
        Console.ResetColor();
    }
}

int GetTotalTries(string currentLevelSelected)
{
    switch (currentLevelSelected)
    {
        case "Easy":
            return 10;
        case "Medium":
            return 5;
        case "Hard":
            return 3;
        default:
            return 0;
    }
}

string FindLevelSelected(int level)
{
    switch (level)
    {
        case 1:
            return "Easy";
        case 2:
            return "Medium";
        case 3:
            return "Hard";
        default:
            return string.Empty;
    }
}

bool ValidNumber(string? level)
{
    if (Int32.TryParse(level, out var levelInt))
    {
        return true;
    }
    return false;
}

void DifficultySelectionMenu()
{
    ConsoleMessage.PrintMessage("1. Easy (10 chances)");
    ConsoleMessage.PrintMessage("2. Medium (5 chances)");
    ConsoleMessage.PrintMessage("3. Hard (3 chances)");
}

void WelcomeText()
{
    ConsoleMessage.PrintInfoMessage("Welcome to the Guess Master!");
}