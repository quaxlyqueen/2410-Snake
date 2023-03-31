namespace Snake
{
    /// 
    /// <summary>Represents a Console position in Left and Top coordinates, AKA (X, Y).</summary>
    ///
    /// <author>Josh Ashton</author>
    ///
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}

