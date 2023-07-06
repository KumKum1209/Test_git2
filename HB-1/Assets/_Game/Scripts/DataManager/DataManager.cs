using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : GOSingleton<DataManager>
{
    public GameData GD;
    public bool isOnMusic
    {
        get
        {
            return GD.isOnMusic;
        }
        set
        {
            GD.isOnMusic = value;
        }
    }
    public bool isOnSound
    {
        get
        {
            return GD.isOnSound;
        }
        set
        {
            GD.isOnSound = value;
        }
    }
    public bool isOnVibration
    {
        get
        {
            return GD.isOnVibration;
        }
        set
        {
            GD.isOnVibration = value;
        }
    }
}

[Serializable]
public class GameData
{
    //Music, Sound, Vibration
    public bool isOnMusic = false;
    public bool isOnSound = false;
    public bool isOnVibration = false;

    public int totalEnemy = 10;
    public int levelGame = 1;
    public float timeSpawn = 10f;
    public float speedEnemyRun = 10f;
    public int damgeEnemy = 30;
}