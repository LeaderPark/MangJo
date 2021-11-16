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
    
    private static MapSysthem instance;
    public static MapSysthem Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<MapSysthem>();
                if (obj != null)
                {
                    instance = obj;

                }
                else
                {
                    var newSingleton = new GameObject("MapSysthem").AddComponent<MapSysthem>();
                    instance = newSingleton;
                }
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<MapSysthem>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

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

    public void Save()
    {
        MapData mapData = new MapData();

        mapData.progress = mapNumber; 
        string save = JsonUtility.ToJson(mapData);
        save = Encryption.Encrypt(save);
        File.WriteAllText(Application.dataPath + "/MapData.json", save);
        Debug.Log(save);
    }

    public void Load()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/MapData.json");
        jsonData = Encryption.Decrypt(jsonData);
        MapData load = JsonUtility.FromJson<MapData>(jsonData);

        mapNumber = load.progress;
        Debug.Log(jsonData);
    }
}
