using System.Collections.Generic;

namespace conway_backend
{
    public class Cell
    {
        private const byte MinStillAlive = 2, MaxStillAlive = 3, Born = 3;

        private bool _LastState;
        private bool _NextState;
        private List<Cell> _Neighbours;

        public Cell(bool isAlive)
        {
            Alive = isAlive;
            Neighbours = new List<Cell>();
        }

        public bool Alive
        {
            get { return _LastState; }
            set { _LastState = value; }
        }

        public List<Cell> Neighbours
        {
            get { return _Neighbours; }
            private set { _Neighbours = value; }
        }

        public int AliveNeighbours
        {
            get
            {
                int aliveneighbours = 0;

                foreach (Cell item in Neighbours)
                {
                    if (item.Alive)
                    {
                        aliveneighbours++;
                    }
                }

                return aliveneighbours;
            }
        }


        public void AddNeighbour(Cell neigh)
        {
            Neighbours.Add(neigh);
        }

        public void NextStep()
        {
            int numberAlive = AliveNeighbours;

            _NextState = !Alive ? numberAlive == Born : (numberAlive >= MinStillAlive && numberAlive <= MaxStillAlive);
        }

        public void Update()
        {
            Alive = _NextState;
        }
    }
}
