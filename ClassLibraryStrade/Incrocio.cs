namespace ClassLibraryStrade
{
    public class Incrocio
    {
        private int x;
        private int y;

        public Incrocio(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}
