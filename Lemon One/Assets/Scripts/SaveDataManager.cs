using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveDataManager{
    
    public static void CreatePlayerData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Player.dat", FileMode.Create);
        PlayerData player = new PlayerData();
        bf.Serialize(file, player);
        file.Close();
        PlayerDataRef.Initialise(player.BestRecord, player.TotalPrawnsCollected, player.TotalPlayingMins, player.LevelUnlocked);
    }

    public static void SavePlayerData(int[] bestRecord, int totalPrawns, int playingTime, int levelUnlocked)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Player.dat", FileMode.Create);
        PlayerData newData = new PlayerData(bestRecord, totalPrawns, playingTime, levelUnlocked);
        bf.Serialize(file, newData);
        file.Close();
    }
    public static void LoadPlayerData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        PlayerData player = new PlayerData();
        try
        {
            FileStream file = File.Open(Application.persistentDataPath + "/Player.dat", FileMode.Open);
            player = (PlayerData)bf.Deserialize(file);
            PlayerDataRef.Initialise(player.BestRecord, player.TotalPrawnsCollected, player.TotalPlayingMins, player.LevelUnlocked);
            file.Close();
        }
        catch(FileNotFoundException e)
        {
            Debug.LogException(e);
        }
    }

    public static bool IsSaveDataExists()
    {
        string path = Application.persistentDataPath + "/Player.dat";
        if (File.Exists(path))
            return true;
        return false;
    }

    public static void DeleteData()
    {
        string path = Application.persistentDataPath + "/Player.dat";
        if (File.Exists(path))
            File.Delete(path);
    }
}
