using System;
using System.Collections.Generic;
namespace Unit01
{
    // Author name = Kouadio Dominique N'guessan
    // This is my sample solution of tic tac toe program for 3X3 board size

    class Program
    {
        static void Main(string[] args)
        {
            List<string> board = GetNewBoard();
            string currentPlayer = "x";

            while (!IsGameOver(board))
            {
                DisplayBoard(board);

                int choice = GetMoveChoice(currentPlayer);
                MakeMove(board, choice, currentPlayer);

                currentPlayer = GetNextPlayer(currentPlayer);
            }

            DisplayBoard(board);
            Console.WriteLine("Good game. Thanks for playing!");
        }

        // Gets a new instance   
        static List<string> GetNewBoard()
        {
            List<string> board = new List<string>();

            for (int i = 1; i <= 9; i++)
            {
                board.Add(i.ToString());
            }

            return board;
        }

        // Display the board
        static void DisplayBoard(List<string> board)
        {            
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }        

        // Determines if game is over
        static bool IsGameOver(List<string> board)
        {
            bool isGameOver = false;

            if (IsWinner(board, "x") || IsWinner(board, "o") || IsTie(board))
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        // Determines if the provided player has a tic tac toe.
        static bool IsWinner(List<string> board, string player)
        {
            
            bool isWinner = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
            {
                isWinner = true;
            }

            return isWinner; 
        }
        
        // Determins if the board is full with no more moves possible. 
        static bool IsTie(List<string> board)
        {            
            bool foundDigit = false;

            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }

            return !foundDigit;
        }
 
        static string GetNextPlayer(string currentPlayer)
        {
            string nextPlayer = "x";

            if (currentPlayer == "x")
            {
                nextPlayer = "o";
            }

            return nextPlayer;
        }
 
        static int GetMoveChoice(string currentPlayer)
        {
            Console.Write($"{currentPlayer}'s turn to choose a square (1-9): ");
            string move_string = Console.ReadLine();

            int choice = int.Parse(move_string);
            return choice;
        }
  
        static void MakeMove(List<string> board, int choice, string currentPlayer)
        {
            // Convert the 1-based spot number to a 0-based index.
            int index = choice - 1;

            // It would be good to include an additional check here to ensure that
            // the spot is available.
            board[index] = currentPlayer;


        }
    }
}
