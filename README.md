# 2D_maze_project
This is a 2D maze game developed in C#, Microsoft Visual Studio.
Everything is written in hungarian, as the committee that evaluated this project asked.

The main .exe file can be reached on szakvizsgauj\szakvizsga uj\bin\Debug\szakvizsga uj.exe
The first button starts the actual game, the second button is for game settings: music selection, difficulty, volume and character selection.

In the game the player has to reach the right bottom corner to enter the next level. The character can be moved with WASD or with the arrows.
The only option to leave the game before reaching the right bottom is pressing Alt+F4 (In the case of some Lenovo products, Alt+Fn+F4).

The third button is for the map editor. A new map can be made by clicking on the boxes where, later on, the player can move (marked by orange) or dragging the mouse in any direction. There is an option to undo a mistake in the path by right clicking/dragging with the mouse on/over the boxes we wish to undo. Inside that there are options to Save the map into the game directory, Refresh the editor (deleting the progress made) and Exit. On the bottom of the window, the user can switch between different colours for the editor (deleting the progress made).

If the map is not okay (cannot reach the righ bottom corner from the top left corner), the editor will show in red all the paths that can be reached and ask for changing the map in order to make it ready to be saved.
