using System.Collections.Generic;

namespace TRS.Library
{
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public static class DirectionUtility
    {
        public static readonly Dictionary<int, Direction> RotationToDirection = new Dictionary<int, Direction>
        {
            { 0,    Direction.NORTH },
            { 90,   Direction.EAST  },
            { 180,  Direction.SOUTH },
            { 270,  Direction.WEST  }
        };

        public static readonly Dictionary<int, Vector2i> RotationToVector = new Dictionary<int, Vector2i>
        {
            { 0,    new Vector2i() { x = 0, y = 1}  },
            { 90,   new Vector2i() { x = 1, y = 0}  },
            { 180,  new Vector2i() { x = 0, y = -1} },
            { 270,  new Vector2i() { x = -1, y = 0} }
        };

        public static readonly Dictionary<Direction, int> DirectionToRotation = new Dictionary<Direction, int>
        {
            { Direction.NORTH,  0   },
            { Direction.EAST,   90  },
            { Direction.SOUTH,  180 },
            { Direction.WEST,   270 }
        };

        public static readonly Dictionary<Direction, Vector2i> DirectionToVector = new Dictionary<Direction, Vector2i>
        {
            { Direction.NORTH,  new Vector2i() { x = 0, y = 1}  },
            { Direction.EAST,   new Vector2i() { x = 1, y = 0}  },
            { Direction.SOUTH,  new Vector2i() { x = 0, y = -1} },
            { Direction.WEST,   new Vector2i() { x = -1, y = 0} }
        };
    }
}