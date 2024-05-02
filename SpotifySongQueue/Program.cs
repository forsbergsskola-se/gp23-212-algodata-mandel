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
    tryAgain:
    var input = Console.ReadLine();
    switch (input)
    {
        case "a":
            Console.WriteLine("Enter the Song's Name:");
            var songName = Console.ReadLine();
            songQueue.Enqueue(songName);
            Console.WriteLine($"Added: {songQueue.Peek()}");
            break;
        case "s" when songQueue.Count > 0:
            Console.WriteLine($"Now playing: {songQueue.Peek()}");
            songQueue.Dequeue();
            break;
        case "s":
            Console.WriteLine("The Queue is empty! [a]dd or [q]uit?");
            goto tryAgain;
        case "q" :
            Console.WriteLine("Quitting Spotify...");
            quit = true;
            break;
        default:
            goto tryAgain;
    }
}


