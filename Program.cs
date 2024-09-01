
using GuessMaster.Utilities;
using System.Reflection.Emit;

WelcomeText();
DifficultySelectionMenu();
while (true)
{
    Console.WriteLine("\nEnter your choice : ");
    var level = Console.ReadLine();
    int totalTries = 0;
    if (!ValidLevel(level))
    {
        ConsoleMessage.PrintErrorMessage("Wrong input given. Please enter difficulty level from 1 to 3.");
        continue;
    }
    Int32.TryParse(level, out var levelInt);

    var currentLevelSelected = FindLevelSelected(levelInt);
    if(currentLevelSelected != null && !string.IsNullOrEmpty(currentLevelSelected))
    {
        totalTries = GetTotalTries(currentLevelSelected);
        ConsoleMessage.PrintInfoMessage($"You have selected {currentLevelSelected} mode. You have {totalTries} chances to guess the answer.");
        ConsoleMessage.PrintErrorMessage($"Good Luck :)");
    }
    else
    {
        ConsoleMessage.PrintErrorMessage("Wrong input given. Please enter number from 1 to 3.");
        continue;
    }

    ConsoleMessage.PrintMessage($"Lets start the game :)");
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
    switch (level) {
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

bool ValidLevel(string? level)
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

ConsoleMessage.PrintInfoMessage("I'm thinking of a number between 1 and 100.");
void WelcomeText()
{
    ConsoleMessage.PrintInfoMessage("Welcome to the Number Guessing Game!");
    ConsoleMessage.PrintCommandMessage("Please select the difficulty level: ");
}