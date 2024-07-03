using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public static class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/save.json";

    public static void Save(SaveData saveData)
    {
        string json = JsonConvert.SerializeObject(saveData, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        File.WriteAllText(savePath, json);
    }

    public static SaveData Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonConvert.DeserializeObject<SaveData>(json);
        }
        return null;
    }
}
