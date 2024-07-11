using TurboCollections;

var stateHistory = new TurboLinkedStack<String>();
stateHistory.Push("Main Menu");
var level = 1;
var previousState = stateHistory.Peek();
bool quit = false;


while (!quit)
{
    PrintNext();
    CheckInput();
}


void PrintNext()
{
    if (stateHistory.Peek() == "Main Menu")
    {
        Console.WriteLine("What do you want to do?\n" +
                          $"[0]: Go to Level {level}\n" +
                          "[1]: Go to Settings\n" +
                          "[q]: Quit");
    }
    else
    {
        Console.WriteLine($"You are here: {stateHistory.Peek()}");
        Console.WriteLine("What do you want to do?\n" +
                          $"[0]: Go to Level {level}\n" +
                          "[1]: Go to Main Menu\n" +
                          $"[b]: Go back to {previousState}");
    }
    Console.WriteLine();
}

void CheckInput()
{
    var input = Console.ReadLine();
    
    if (stateHistory.Peek() == "Main Menu")
    {
        switch (input)
        {
            case "0":
                stateHistory.Push($"Level {level}");
                level++;
                break;
            case "1":
                stateHistory.Push("Settings");
                Console.WriteLine("[b]: Go back to Main Menu");
                tryAgain:
                var backFromSettings = Console.ReadLine();
                while (backFromSettings != "b")
                {
                    goto tryAgain;
                }
                stateHistory.Pop();
                break;
            case "q":
                stateHistory.Clear();
                quit = true;
                break;
        }
    }
    else
    {
        switch (input)
        {
            case "0":
                previousState = stateHistory.Peek();
                stateHistory.Push($"Level {level}");
                level++;
                break;
            case "1":
                previousState = stateHistory.Peek();
                stateHistory.Clear();
                level = 1;
                stateHistory.Push("Main Menu");
                break;
            case "b":
                level--;
                stateHistory.Pop();
                break;
            case "q":
                stateHistory.Clear();
                quit = true;
                break;
        }
    }
}         

