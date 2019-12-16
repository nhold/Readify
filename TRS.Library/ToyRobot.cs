namespace TRS.Library
{
    public class ToyRobot
    {
        public Vector2i Position
        {
            get;
            private set;
        }

        public Direction Direction
        {
            get;
            private set;
        }

        private Vector2i vector;
        private int rotation;

        public bool IsOnMap
        {
            get
            {
                return map != null;
            }
        }

        private Map map;

        public ToyRobot()
        {
            Direction = Direction.NORTH;
            Position = new Vector2i();
            vector = new Vector2i();
        }

        public ToyRobot(int x, int y)
        {
            Direction = Direction.NORTH;
            Position = new Vector2i(x, y);
            vector = new Vector2i();
        }

        public void Left()
        {
            if (!IsOnMap)
                return;

            rotation -= 90;
            if (rotation < 0)
            {
                rotation = 270;
            }

            vector = DirectionUtility.RotationToVector[rotation];
            Direction = DirectionUtility.RotationToDirection[rotation];
        }

        public void Right()
        {
            if (!IsOnMap)
                return;

            rotation += 90;
            if (rotation > 270)
            {
                rotation = 0;
            }

            vector = DirectionUtility.RotationToVector[rotation];
            Direction = DirectionUtility.RotationToDirection[rotation];
        }

        public void Move()
        {
            if (!IsOnMap)
                return;

            var newPosition = Position + vector;
            if (map.IsPositionOutOfBounds(newPosition))
            {
                return;
            }

            Position = newPosition;
        }

        public void Place(int x, int y)
        {
            if (!IsOnMap || !CheckValidNewPosition(x, y))
            {
                return;
            }

            Position.x = x;
            Position.y = y;
        }

        public void Place(Map map, int x, int y, Direction direction)
        {
            this.map = map;

            if (!IsOnMap && !CheckValidNewPosition(x, y))
            {
                return;
            }

            Direction = direction;
            Position.x = x;
            Position.y = y;
            vector = DirectionUtility.DirectionToVector[direction];
            rotation = DirectionUtility.DirectionToRotation[direction];
        }

        private bool CheckValidNewPosition(int x, int y)
        {
            if (map.IsPositionOutOfBounds(x, y))
            {
                return false;
            }

            return true;
        }
    }
}