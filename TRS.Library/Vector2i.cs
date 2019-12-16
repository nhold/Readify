namespace TRS.Library
{
    public class Vector2i
    {
        public int x;
        public int y;

        public Vector2i()
        {
            x = 0;
            y = 0;
        }

        public Vector2i(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2i operator +(Vector2i a, Vector2i b)
        {
            Vector2i vector = new Vector2i
            {
                x = a.x + b.x,
                y = a.y + b.y
            };

            return vector;
        }
    }
}