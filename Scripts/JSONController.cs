using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONController : MonoBehaviour
{
    [SerializeField] private Stats _playerStats;

    private void Awake() {
        GetStats();

        if (_playerStats.TurretLevel == 0)
        {
            _playerStats.TurretLevel = 1;
            _playerStats.MinerLevel = 1;
            
            SaveStats();
        }
    }

    public Stats PlayerStates { get { return _playerStats; }
        set { _playerStats = value; } 
    }

    public void GetStats()
    {
        _playerStats = JsonUtility.FromJson<Stats>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "PlayerStats.json")));
    }

    public void SaveStats()
    {
        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "PlayerStats.json"), JsonUtility.ToJson(_playerStats));
    }
}

[System.Serializable]
public class Stats
{
    [SerializeField] private int unlockedLevelsCount;
    public int UnlockedLevelsCount { get { return unlockedLevelsCount; } 
        set { unlockedLevelsCount = value; }
    }

    [SerializeField] private int coinsAmount;
    public int CoinsAmount { get { return coinsAmount; } 
        set { coinsAmount = value; }
    }

    [SerializeField] private int turretLevel;

    public int TurretLevel { get { return turretLevel; } 
        set { turretLevel = value; }
    }

    [SerializeField] private int minerLevel;
    public int MinerLevel { get { return minerLevel; } 
        set { minerLevel = value; }
    }
}