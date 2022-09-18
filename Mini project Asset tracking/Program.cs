// Mini Project 1
// Asset Tracking

using Mini_project_Asset_tracking;
using Mini_project_Asset_tracking.IO;
using System.ComponentModel.Design;

// Initiate asset list (read from JSON file)
FileIO.ReadAssetsFromFile(FileIO.JsonAssetsFileName);

// Display list and main menu - take user choises
Menues.mainMenu.Display();

// Main loop
while (!ActionMethods.exit)
{
    Menues.mainMenu.Input();
    Menues.mainMenu.Display();
}

// Save assets to file before exit
FileIO.WriteAssetsToFile(FileIO.JsonAssetsFileName);

// By Ole Victor