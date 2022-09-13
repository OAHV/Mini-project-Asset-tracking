using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking.IO
{
    public static class FileIO
    {
        public static string JsonAssetsFileName = "assets.json";
        public static string JsonAssetsFileContent = "";

        public static void ReadAssetsFromFile(string filename)
        {
            string JSONdata = File.ReadAllText(filename);
            if (JSONdata != "")
            {
                AssetLists.Assets = JsonSerializer.Deserialize<List<Asset>>(JSONdata);
            }
        }

        public static void WriteAssetsToFile(string filename)
        {
            string JSONdata = JsonSerializer.Serialize(AssetLists.Assets);
            File.WriteAllText(filename, JSONdata);
        }
    }
}
