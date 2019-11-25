using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(StatBars stats)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.binary";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(stats);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadData() {
        string path = Application.persistentDataPath + "/player.binary";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            stream.Position = 0;
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else {
            Debug.Log("save file not found in: " + path);
            return null;
        }
    }
}
