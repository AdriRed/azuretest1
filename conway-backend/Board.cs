using System;

namespace conway_backend
{
    public class Board
    {
        public static readonly sbyte[,] Directions =
        {
            {-1, -1},
            {-1,  0},
            {-1,  1},
            { 0, -1},
            { 0,  1},
            { 1, -1},
            { 1,  0},
            { 1,  1}
        };
        public static char Alive = '█', Dead = ' ';

        public Cell[,] Cells { get; private set; }

        public Board(bool[,] states)
        {
            Cells = new Cell[states.GetLength(0), states.GetLength(1)];

            for (int j = 0; j < states.GetLength(1); j++)
            {
                for (int i = 0; i < states.GetLength(0); i++)
                {
                    Cells[i, j] = new Cell(states[i, j]);
                }
            }

            SetAllNeighbours();
        }

        public Board(int x, int y, bool state)
        {
            Cells = new Cell[x, y];

            for (int j = 0; j < Cells.GetLength(1); j++)
            {
                for (int i = 0; i < Cells.GetLength(0); i++)
                {
                    Cells[i, j] = new Cell(state);
                }
            }

            SetAllNeighbours();
        }

        public Board(int x, int y)
        {
            Random rd = new Random();
            Cells = new Cell[x, y];

            for (int j = 0; j < Cells.GetLength(1); j++)
            {
                for (int i = 0; i < Cells.GetLength(0); i++)
                {
                    Cells[i, j] = new Cell(rd.NextDouble() > 0.7 ? true : false);
                }
            }

            SetAllNeighbours();
        }

        private void SetAllNeighbours()
        {
            for (int j = 0; j < Cells.GetLength(1); j++)
            {
                for (int i = 0; i < Cells.GetLength(0); i++)
                {
                    FindNeighbours(Cells[i, j], i, j);
                }
            }
        }

        private void FindNeighbours(Cell cell, int coordX, int coordY)
        {
            sbyte[] direction;

            for (int i = 0; i < Directions.GetLength(0); i++)
            {
                direction = new sbyte[] { Directions[i, 0], Directions[i, 1] };

                int lookingX = coordX + direction[0];
                int lookingY = coordY + direction[1];

                if (lookingX >= 0 && lookingX < Cells.GetLength(0) && lookingY >= 0 && lookingY < Cells.GetLength(1))
                {
                    cell.AddNeighbour(Cells[lookingX, lookingY]);
                }
            }
        }

        public void Print()
        {
            Console.Clear();
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(Cells[i, j].Alive ? Alive : Dead);
                }
            }
        }

        public void NextStep()
        {
            foreach (Cell item in Cells)
            {
                item.NextStep();
            }

            foreach (Cell item in Cells)
            {
                item.Update();
            }
        }
    }
}
