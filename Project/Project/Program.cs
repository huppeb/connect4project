using System;

namespace Project
{

    public interface xyz
    {
        void Start();
        void end();
    }
    public abstract class Game:xyz
    {
        public string Name = "4connect Game";
        public void Start()
        {
            Console.WriteLine("Welcome to the 4connect Game! ");
        }

        public void end()
        {
            Console.WriteLine("Thanks for playing! ");
        }


    }
    public class player:Game
    {
        public char PlayerToken { get; set; }
        public string PlayerName { get; set; }

    }



    public class displayBoard
    {

       static  public int win = 0;
        public displayBoard(char[,] board)
        {

            for (int i = 0; i < 6; i++)
            {
                Console.Write("| ");
                for (int ix = 0; ix < 7; ix++)
                {
                    if (board[i, ix] != 'x' && board[i, ix] != 'o')
                    {
                        board[i, ix] = '#';
                        Console.Write(board[i, ix]);
                    }
                }
                Console.WriteLine(" |");
            }
        }
        public void Displaying(char[,] board)
        {
            for (int i = 0; i < 6; i++)
            {
                Console.Write("| ");
                for (int ix = 0; ix < 7; ix++)
                {

                    Console.Write(board[i, ix]);
                }
                Console.WriteLine(" |");
            }
        }


        public void Reset(char[,] board)
        {
            int val;
            Console.WriteLine("Would you like to restart? Yes(1) No(2): ");
            val = Convert.ToInt32(Console.ReadLine());
            do
            {

                for (int i = 0; i < 6; i++)
                {
                    Console.Write("| ");
                    for (int ix = 0; ix < 7; ix++)
                    {
                        if (board[i, ix] != 'x' && board[i, ix] != 'o')
                        {
                            board[i, ix] = '#';
                            Console.Write(board[i, ix]);
                        }
                    }
                    Console.WriteLine(" |");
                }
                Console.WriteLine("Would you like to restart? Yes(1) No(2): ");
                val = Convert.ToInt32(Console.ReadLine());
            } while (val != 2);
            Console.WriteLine("goodbye");
        }



        public int Winner(player someguy, char[,] board)
        {



            char token = someguy.PlayerToken;


            for (int i = 5; i <= 0; i--)
            {
                for (int ix = 6; i <= 0; ix--)
                {
                    if (board[i, ix] == token &&
                     board[i, ix - 1] == token &&
                     board[i, ix - 2] == token &&
                     board[i, ix - 3] == token)
                    {
                        win = 1;

                    }
                    if (board[i, ix - 1] == token &&
                    board[i, ix - 2] == token &&
                    board[i, ix - 3] == token &&
                    board[i, ix - 4] == token)
                    {
                        win = 1;

                    }
                    if (board[i, ix - 2] == token &&
                    board[i, ix - 3] == token &&
                    board[i, ix - 4] == token &&
                    board[i, ix - 5] == token)
                    {
                        win = 1;

                    }
                    if (board[i, ix - 3] == token &&
                    board[i, ix - 4] == token &&
                    board[i, ix - 5] == token &&
                    board[i, ix - 6] == token)
                    {
                        win = 1;

                    }
                }
            }
            for (int i = 6; i <= 0; i--)
            {
                for (int ix = 5; i <= 0; ix--)
                {
                    if (board[ix, i] == token &&
                     board[ix - 1, i] == token &&
                     board[ix - 2, i] == token &&
                     board[i - 3, i] == token)
                    {
                        win = 1;

                    }
                    if (board[ix - 1, i] == token &&
                     board[ix - 2, i] == token &&
                     board[ix - 3, i] == token &&
                     board[i - 4, i] == token)
                    {
                        win = 1;

                    }
                    if (board[ix - 2, i] == token &&
                     board[ix - 3, i] == token &&
                     board[ix - 4, i] == token &&
                     board[i - 5, i] == token)
                    {
                        win = 1;

                    }

                }
            }




            if (win == 1)
            {
                Console.WriteLine("{0} wins!", someguy);

            }
            return win;
        }



        public void checkboard(player excelsior, int choice, char[,] board)
        {
            int length;
            int turn;

            length = 5;
            turn = 0;

            do
            {
                if (board[length, choice] != 'x' && board[length, choice] != 'o')
                {
                    board[length, choice] = excelsior.PlayerToken;

                    turn = 1;
                }
                else
                {
                    length--;
                }
            } while (turn != 1);
        }



        //
        public int DropBoard(player morebullshit, char[,] board)
        {
            int choice;

            Console.WriteLine(morebullshit.PlayerName + "'s turn");
            do
            {
                Console.WriteLine("Choose a number between 1 to 7");
                int x = Convert.ToInt32(Console.ReadLine());
                choice = x - 1;
                break;
            } while (choice < 0 || choice > 6);



            while (board[1, choice] == 'x' || board[1, choice] == 'o')
            {
                Console.WriteLine("That row is full, please enter a new row: ");
                int x = Convert.ToInt32(Console.ReadLine());
                choice = x - 1;

            }
            return choice;
        }



    }

    class Program
    {
        static void Main(string[] args)
        {
            player p = new player();
            player player1 = new player();
            player player2 = new player();

            player1.Start();

            Console.WriteLine("please enter your name");

            player1.PlayerName = Console.ReadLine();
            player1.PlayerToken = 'x';

            Console.WriteLine("please enter your name");

            player2.PlayerName = Console.ReadLine();
            player2.PlayerToken = 'o';

            char[,] board = new char[6, 7];

            displayBoard newBoard = new displayBoard(board);
            int x;
            int win;

            for (; ; )
            {

                x = newBoard.DropBoard(player1, board);
                newBoard.checkboard(player1, x, board);
                win = newBoard.Winner(player1, board);

                newBoard.Displaying(board);

                if (win == 1)
                {
                    newBoard.Reset(board);
                }

                x = newBoard.DropBoard(player2, board);
                newBoard.checkboard(player2, x, board);
                win = newBoard.Winner(player2, board);

                newBoard.Displaying(board);
                if (win == 1)
                {
                    newBoard.Reset(board);
                }
            }


            





        }
        
    }
}


