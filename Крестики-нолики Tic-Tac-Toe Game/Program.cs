using System;

class TicTacToeGame
{
    static char[,] board = new char[3, 3];
    static bool isGameOver = false;
    static char currentPlayer;
    static string имяИгрокаX;
    static string имяИгрокаO;

    static void Main()
    {
        Console.WriteLine("Добро пожаловать в игру 'Крестики-Нолики'!");
        do
        {
            InitializeGame();
            PlayGame();
        } while (PlayAgain());
    }

    static void InitializeGame()
    {
        isGameOver = false;
        Console.Write("Введите имя первого игрока (Крестики): ");
        имяИгрокаX = Console.ReadLine();

        Console.Write("Введите имя второго игрока (Нолики): ");
        имяИгрокаO = Console.ReadLine();

        Console.WriteLine($"{имяИгрокаX} будет использовать крестики (X), а {имяИгрокаO} - Нолики (O).\n");

        InitializeBoard();
        currentPlayer = 'X';
    }

    static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                board[i, j] = ' ';
    }

    static void PlayGame()
    {
        do
        {
            DisplayBoard();
            GetPlayerMove();
            CheckForWinner();
            CheckForTie();
            SwitchPlayer();
        } while (!isGameOver);

        DisplayResult();
    }

    static void DisplayBoard()
    {
        Console.WriteLine("  0 1 2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"{i} ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"{board[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void GetPlayerMove()
    {
        int row, col;
        do
        {
            Console.Write($"Ход игрока {currentPlayer}. Введите номер строки (0-2): ");
            row = int.Parse(Console.ReadLine());

            Console.Write($"Ход игрока {currentPlayer}. Введите номер столбца (0-2): ");
            col = int.Parse(Console.ReadLine());

            if (row < 0 || row >= 3 || col < 0 || col >= 3 || board[row, col] != ' ')
            {
                Console.WriteLine("Некорректный ход. Попробуйте еще раз.");
            }
            else
            {
                board[row, col] = currentPlayer;
                break;
            }
        } while (true);
    }

    static void CheckForWinner()
    {
        if (CheckForWinningCondition())
        {
            isGameOver = true;
        }
    }

    static void SwitchPlayer()
    {
        if (!isGameOver)
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
    }

    static void CheckForTie()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (board[i, j] == ' ')
                    return;

        if (!CheckForWinningCondition())
        {
            isGameOver = true;
        }
    }

    static void DisplayResult()
    {
        DisplayBoard();

        if (isGameOver)
        {
            Console.WriteLine("Игра завершена.");

            if (CheckForWinningCondition())
            {
                string имяПобедителя = (currentPlayer == 'X') ? имяИгрокаX : имяИгрокаO;
                Console.WriteLine($"Игрок {имяПобедителя} победил!");
            }
            else
            {
                Console.WriteLine("Ничья!");
            }
        }
    }

    static bool PlayAgain()
    {
        Console.Write("Хотите начать новую игру? (да/нет): ");
        string response = Console.ReadLine().ToLower();
        return response == "да";
    }

    static bool CheckForWinningCondition()
    {
        /*
         * X - -
         * X - -
         * X - -
         */
        if (board[0, 0] == currentPlayer && board[1, 0] == currentPlayer && board[2, 0] == currentPlayer)
        {
            return true;
        }
        /*
         * - X -
         * - X -
         * - X -
         */
        if (board[0, 1] == currentPlayer && board[1, 1] == currentPlayer && board[2, 1] == currentPlayer)
        {
            return true;
        }
        /*
         * - - X
         * - - X
         * - - X
         */
        if (board[0, 2] == currentPlayer && board[1, 2] == currentPlayer && board[2, 2] == currentPlayer)
        {
            return true;
        }
        /*
         * X X X
         * - - -
         * - - -
         */
        if (board[0, 0] == currentPlayer && board[0, 1] == currentPlayer && board[0, 2] == currentPlayer)
        {
            return true;
        }
        /*
         * - - -
         * X X X
         * - - -
         */
        if (board[1, 0] == currentPlayer && board[1, 1] == currentPlayer && board[1, 2] == currentPlayer)
        {
            return true;
        }
        /*
         * - - -
         * - - -
         * X X X
         */
        if (board[2, 0] == currentPlayer && board[2, 1] == currentPlayer && board[2, 2] == currentPlayer)
        {
            return true;
        }
        /*
         * X - -
         * - X -
         * - - X
         */
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
        {
            return true;
        }
        /*
         * - - X
         * - X -
         * X - -
         */
        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
        {
            return true;
        }

        return false;
    }
}