using conway_backend;
using System;

namespace conway_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);

            Board board = GetBoardFromConsole(Console.WindowWidth, Console.WindowHeight);

            //Board board = new Board(100, 30);

            do
            {
                board.Print();
                board.NextStep();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Console.ReadKey();
        }

        private static Board GetBoardFromConsole(int width, int height)
        {
            Board states = new Board(width, height, false);

            int x = 0, y = 0;
            bool exit = false;
            const ConsoleKey up = ConsoleKey.UpArrow, down = ConsoleKey.DownArrow, left = ConsoleKey.LeftArrow,
                       right = ConsoleKey.RightArrow, change = ConsoleKey.Spacebar, exitKey = ConsoleKey.Enter;
            

            do
            {
                states.Print();
                Console.SetCursorPosition(x, y);
                Console.Write(states.Cells[x, y].Alive ? '0' : 'O');
                ConsoleKey key = Console.ReadKey(false).Key;

                switch (key)
                {
                    case exitKey: exit = true; break;
                    case change: states.Cells[x, y].Alive = !states.Cells[x, y].Alive; break;
                    case down:
                        {
                            if (y + 1 < states.Cells.GetLength(1))
                            {
                                y++;
                            }
                            break;
                        }
                    case up:
                        {
                            if (y - 1 >= 0)
                            {
                                y--;
                            }
                            break;
                        }
                    case right:
                        {
                            if (x + 1 < states.Cells.GetLength(0))
                            {
                                x++;
                            }
                            break;
                        }
                    case left:
                        {
                            if (x - 1 >= 0)
                            {
                                x--;
                            }
                            break;
                        }
                }
            } while (!exit);

            return states;
        }
    }
}
