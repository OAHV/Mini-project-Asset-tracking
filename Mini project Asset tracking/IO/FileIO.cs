using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace Mini_project_Asset_tracking.IO
{
    // Read initial asset state from JSON file or save it to JSON file
    public static class FileIO
    {
        public static string JsonAssetsFileName = "assets.json";    // Default filename

        // Read assets from JSON file at program start
        public static void ReadAssetsFromFile(string filename)
        {
            string JSONdata = "";

            // Set dir to repository
            Environment.CurrentDirectory = "../../..";

            try
            {
                // Read all data to buffer string
                JSONdata = File.ReadAllText(filename);
            }
            catch
            {
                // ConsoleScreen.errorDisplay("Error reading file");
            }
            if (JSONdata != "")
            {
                // If string not empty - deserialize it to assets in asset list
                AssetLists.Assets = JsonSerializer.Deserialize<List<Asset>>(JSONdata);
            }
        }

        // Save all assets to JSON file
        public static void WriteAssetsToFile(string filename)
        {
            // Options for pretty/readable JSON file
            var options = new JsonSerializerOptions { WriteIndented = true };
            // Serialize entire asset list
            string JSONdata = JsonSerializer.Serialize(AssetLists.Assets, options);
            // Write ie to JSON file
            File.WriteAllText(filename, JSONdata);
        }
    }
}

// By Ole Victor