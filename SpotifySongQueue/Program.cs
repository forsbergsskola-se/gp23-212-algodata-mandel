using TurboCollections;

var songQueue = new TurboLinkedQueue<string>();
bool quit = false;

while (!quit)
{
    CheckAddOrSkip();
}

void CheckAddOrSkip()
{
    Console.WriteLine("What would you like to do? [s]kip or [a]dd?");
    var input = Console.ReadLine();
    switch (input)
    {
        case "a":
            Console.WriteLine("Enter the Song's Name:");
            var songName = Console.ReadLine();
            songQueue.Enqueue(songName!);
            break;
        case "s" when songQueue.Count != 0:
            Console.WriteLine($"Now playing: {songQueue.Peek()}");
            songQueue.Dequeue();
            break;
        case "s":
            Console.WriteLine("The Queue is empty! [a]dd or [q]uit?");
            var continueOrQuit = Console.ReadLine();
            switch (continueOrQuit)
            {
                case "q":
                    Console.WriteLine("Quitting Spotify...");
                    quit = true;
                    break;
                case "a":
                    Console.WriteLine("Enter the Song's Name:");
                    var name = Console.ReadLine();
                    songQueue.Enqueue(name!);
                    break;
            }
            break;
    }
    Console.WriteLine();
}


