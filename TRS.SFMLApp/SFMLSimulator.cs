using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using TRS.Library;

namespace TRS.SFMLApp
{
    class SFMLSimulator
    {
        private readonly RenderWindow window;
        private readonly ToyRobot toyRobot;
        private readonly Map map;

        private readonly Sprite robot;
        private readonly Sprite[,] grass;
        private readonly int width = 6;
        private readonly int height = 6;
        private readonly int size = 16;
        private readonly int halfSize = 8;

        public SFMLSimulator()
        {
            window = new RenderWindow(new VideoMode(800, 600), "SFML Simulator");
            window.SetView(new View(new FloatRect(0, 0, size * width, size * height)));
            window.Closed += Window_Closed;
            window.MouseButtonReleased += Window_MouseButtonReleased;
            window.KeyReleased += Window_KeyReleased;
            toyRobot = new ToyRobot();
            map = new Map(width, height);
            grass = new Sprite[width, height];

            Image grassImage = new Image("./Resources/grass.png");
            Texture grassTexture = new Texture(grassImage);
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grass[x, y] = new Sprite(grassTexture)
                    {
                        Position = new Vector2f((x * size), (y * size))
                    };
                }
            }

            Image robotImage = new Image("./Resources/robot.png");
            Texture robotTexture = new Texture(robotImage);
            robot = new Sprite(robotTexture)
            {
                Origin = new Vector2f(8, 8)
            };
        }

        private void Window_KeyReleased(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Right)
            {
                toyRobot.Right();
            }

            if (e.Code == Keyboard.Key.Left)
            {
                toyRobot.Left();
            }

            if (e.Code == Keyboard.Key.Up)
            {
                toyRobot.Move();
            }
        }

        private void Window_MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            var coords = window.MapPixelToCoords(new SFML.System.Vector2i(e.X, e.Y));

            // Flip the vertical axis.
            var finalPosition = new TRS.Library.Vector2i
            {
                x = (int)coords.X / size,
                y = height-1-(int)coords.Y / size
            };

            if (e.Button == Mouse.Button.Left)
            {
                toyRobot.Place(finalPosition.x, finalPosition.y);
            }

            if (e.Button == Mouse.Button.Right)
            {
                toyRobot.Place(map, finalPosition.x, finalPosition.y, toyRobot.Direction);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }

        public void Run()
        {
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.Black);

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        window.Draw(grass[x, y]);
                    }
                }

                // Map the flipped vertical axis and the 1,1 pixel grid to the 16,16 pixel grid taking into account the origin.
                robot.Position = new Vector2f((toyRobot.Position.x * size)+halfSize,((size*(height-1))-(toyRobot.Position.y * size))+halfSize);
                robot.Rotation = DirectionUtility.DirectionToRotation[toyRobot.Direction];

                window.Draw(robot);

                window.Display();
            }

            robot.Texture.Dispose();
            grass[0, 0].Texture.Dispose();
        }
    }
}
