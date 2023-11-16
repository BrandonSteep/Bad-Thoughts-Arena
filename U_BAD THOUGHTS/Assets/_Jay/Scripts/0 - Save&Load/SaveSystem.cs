using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(Data data){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.scum";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData myData = new PlayerData(data);

        formatter.Serialize(stream, myData);
        stream.Close();
    }

    public static PlayerData LoadData(){
        string path = Application.persistentDataPath + "/data.scum";

        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData myData = formatter.Deserialize(stream) as PlayerData;
            
            stream.Close();
            return myData;
        }
        else{
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
