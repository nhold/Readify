namespace TRS.Library
{
    public class Map
    {
        private readonly int width;
        private readonly int height;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public bool IsPositionOutOfBounds(int x, int y)
        {
            return (x < 0 || y < 0 || x >= width || y >= height);
        }

        public bool IsPositionOutOfBounds(Vector2i position)
        {
            return IsPositionOutOfBounds(position.x, position.y);
        }
    }
}