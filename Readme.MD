# Toy Robot Simulator

I had a basic thought process going into this:

Input\Output and Business Logic should be seperate!

So the quick version is:

* TRS.Library(.Net Standard) - Contains the ToyRobot and Map logic that contains how the ToyRobot does it's job with the map
* TRS.ConsoleApp(.Net Core) - Contains the I\O for the console, takes input read from the user, translates it to an action on the toyrobot or on the simulation itself (Quit, Report)
* TRS.SFMLApp(.Net Framework) - Contains the I\O for a 2D sfml based version, translates mouse and keyboard into actions for the robot. Seperation of input and output made this simple.

## Getting Started

Try looking at the SFMLSimulator, ConsoleSimulator and ToyRobot classes. Those contain the majority of logic (Although there is some fun in looking at OverloadedCommand\ArgumentCommand!)

Enjoy :-).

## Running

Just open in Visual Studio. Select either SFMLApp or ConsoleApp as the startup app and click run.

The controls for the 2D version:

* Right Click: Initial Place
* Left Click: Place
* Left Arrow: Rotate Left
* Right Arrow: Rotate Right
* Up Arrow: Move

The controls for the Console version:

* Place 0,0,North
* Place 0,1
* Right
* Move
* Report
* Quit