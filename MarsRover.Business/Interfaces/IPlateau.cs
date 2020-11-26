using System.Collections.Generic;

namespace MarsRover.Business.Interfaces
{
    public interface IPlateau
    {
        List<IRover> Rovers { get; set; }
        int X { get; set; }
        int Y { get; set; }

        bool SetSize(string positions);
        void RunHandle();
    }
}