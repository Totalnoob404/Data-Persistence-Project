using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string hiscoreName;
        public int hiscoreScore;
    }


    public static GameManager Instance;

    public string playerName;

    public int m_Points;

    public string hiscoreName;

    public int hiscoreScore;


    private void Awake()
    {
        LoadHiscore();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void SaveHiscore()
    {
        SaveData data = new SaveData();
        data.hiscoreName = hiscoreName;
        data.hiscoreScore = hiscoreScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHiscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hiscoreName = data.hiscoreName;
            hiscoreScore = data.hiscoreScore;
        }
    }
}
