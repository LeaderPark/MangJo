using System;
using System.IO;
using UnityEngine;

[System.Serializable]
public class MapData
{
    public int progress;
}
public class MapSysthem : MonoBehaviour
{
    public GameObject[] maplock;
    public static int mapNumber;
    
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }

        for (int i = 0; i < mapNumber; i++)
        {
            maplock[i].SetActive(false);
        }
    }

    void Save()
    {
        MapData mapData = new MapData();

        mapData.progress = mapNumber; 
        string save = JsonUtility.ToJson(mapData);
        save = Encryption.Encrypt(save);
        File.WriteAllText(Application.dataPath + "/MapData.json", save);
        Debug.Log(save);
    }

    void Load()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/MapData.json");
        jsonData = Encryption.Decrypt(jsonData);
        MapData load = JsonUtility.FromJson<MapData>(jsonData);

        mapNumber = load.progress;
        Debug.Log(jsonData);
    }
}
