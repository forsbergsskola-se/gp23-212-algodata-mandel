// Marc's TicTackToe

CheckAllPossibleMoves(GameState.Start());

void CheckAllPossibleMoves(GameState currentState)
{
    Console.WriteLine(currentState);
    foreach (var move in currentState.PossibleMoves())
    {
        CheckAllPossibleMoves(move);
    }
}



class GameState
{
    // Using a one-dimensional array for a 2D-Grid
    // Because it's easier to clone
    private char[]? cells = null;

    private bool IsTerminal()
    {
        return IsWin() || IsLose() || IsDraw();
    }

    public bool IsWin()
    {
        return IsWin('X');
    }

    public bool IsWin(char c)
    {
        // Using evil maths to check all cells in a hard-coded way
        // check the rows
        for (int x = 0; x < 9; x += 3)
        {
            if (cells![x] == cells[x + 1] && cells[x + 1] == cells[x + 2] && cells[x + 2] == c) return true;
        }
        // check the columns
        for (int x = 0; x < 3; x++)
        {
            if (cells![x] == cells[x + 3] && cells[x + 3] == cells[x + 6] && cells[x + 6] == c) return true;
        }
        // check diagonals
        if (cells![0] == cells[4] && cells[4] == cells[8] && cells[8] == c) return true;
        if (cells[2] == cells[4] && cells[4] == cells[6] && cells[6] == c) return true;
        return false;
    }
    
    public bool IsLose()
    {
        return IsWin('O');
    }
    
    public bool IsDraw()
    {
        if (IsWin() || IsLose()) return false;
        // using LINQ magic, to count, how many cells are empty
        return cells!.Count(it => it == ' ') == 0;
    }
    
    public char CurrentPlayer()
    {
        // using LINQ & modulo magic to check if the number of moves
        // is even, then it's X's turn
        switch (cells!.Count(it => it != ' ') % 2)
        {
            case 0:
                return 'X';
            case 1:
                return 'O';
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    // Using IEnumerable (Iterator pattern)
    public IEnumerable<GameState> PossibleMoves()
    {
        if (IsTerminal()) yield break;

        char symbol = CurrentPlayer();
        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i] == ' ')
            {
                var newCells = new char[cells.Length];
                Array.Copy(cells, newCells, cells.Length);
                newCells[i] = symbol;
                
                // As well as yield to return multiple possible next moves
                yield return new GameState 
                {
                    cells = newCells,
                };
            }
        }
    }

    // using a public static function to make it easy to
    // create the initial state
    public static GameState Start()
    {
        return new GameState()
        {
            cells = new[]
            {
                ' ', ' ', ' ',
                ' ', ' ', ' ',
                ' ', ' ', ' ',
            },
        };
    }

    // Overriding to string modifies what happens
    // if you do Console.WriteLine(gameState);
    public override string ToString()
    {
        string state = IsWin() ? "X Wins." : IsLose() ? "O Wins." : IsDraw() ? "Draw." : "TBC";
        return $@"{cells![0]} | {cells[1]} | {cells[2]}
---------
{cells[3]} | {cells[4]} | {cells[5]}
---------
{cells[6]} | {cells[7]} | {cells[8]}
{state}

";
    }
}