using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public enum CellStateTypes
    {
        Dead = 0x0,
        Alive = 0x1
    }

    public class Cell
    {
        public CellStateTypes State { get; private set; }
        // what
    }
}
