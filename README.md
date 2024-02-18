# VSquare
This project is a balloon pop-up game which is developed in Unity. 
It is based on port searching which is currently free on the system and listening to those ports via TCP/IP socket between Unity code and Python.
There are 3 stages, Start Stage, where the player can input the name and start the game.
**NOTE: Without entering the name, you can not start the game.**
After entering the game stage, there will be 3 types of balloons appearing on the screen - Yellow, Purple, and Red.
When you touch the Purple and Yellow Balloons, your score will update. The Red is our Enemy, and it will lead to Game Over.
The continuous spawning of balloons is written in Python language, and it is being called by Unity through TCP/IP Socket.
There is a Quit Button that will open the End Screen and we can exit the game.
