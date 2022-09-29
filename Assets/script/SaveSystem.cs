using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
    public static void SavePlayer(PlayerMove player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.doc";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("save");
    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.doc";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            Debug.Log("load");
            stream.Close();
            return data;
            
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
