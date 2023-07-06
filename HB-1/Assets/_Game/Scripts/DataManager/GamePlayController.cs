using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private bool onClick = false;
    [SerializeField] private GameObject btnPlay;
    public void LevelNormal()
    {
        DataManager.GetInstance().GD.levelGame = 1;
        DataManager.GetInstance().GD.totalEnemy = 15;
        DataManager.GetInstance().GD.timeSpawn = 10f;
        DataManager.GetInstance().GD.speedEnemyRun = 10f;
        DataManager.GetInstance().GD.damgeEnemy = 30;
        onClick = true;
    }
    public void LevelMedium()
    {
        DataManager.GetInstance().GD.levelGame = 2;
        DataManager.GetInstance().GD.totalEnemy = 20;
        DataManager.GetInstance().GD.timeSpawn = 8f;
        DataManager.GetInstance().GD.speedEnemyRun = 10f;
        DataManager.GetInstance().GD.damgeEnemy = 35;
        onClick = true;
    }
    public void LevelHard()
    {
        DataManager.GetInstance().GD.levelGame = 3;
        DataManager.GetInstance().GD.totalEnemy = 25;
        DataManager.GetInstance().GD.timeSpawn = 6f;
        DataManager.GetInstance().GD.speedEnemyRun = 10f;
        DataManager.GetInstance().GD.damgeEnemy = 40;
        onClick = true;
    }
    private void Update()
    {
        OnClickEnable(btnPlay);
    }
    public void OnClickEnable(GameObject btnPlay)
    {
        if (onClick)
        {
            btnPlay.SetActive(true);
        }
        else
        {
            btnPlay.SetActive(false);
        }
    } 
}
