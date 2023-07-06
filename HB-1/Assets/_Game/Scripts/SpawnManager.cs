using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<Transform> spawnList = new List<Transform>();
    [SerializeField] List<GameObject> EnemyPrefabs = new List<GameObject>();
    [SerializeField] HealthBar healthBarPrefab;
    public int totalEnemy;
    private GameObject[] Enemies;
    // Update is called once per frame
    void Start()
    {
        totalEnemy = DataManager.GetInstance().GD.totalEnemy;
        Enemies = new GameObject[spawnList.Count];
        for (int i = 0; i < spawnList.Count; i++)
            StartCoroutine(Spawn(i));
    }
    IEnumerator Spawn(int i)
    {
        yield return new WaitForSeconds(DataManager.GetInstance().GD.timeSpawn);

        if (Enemies[i] == null && DataManager.GetInstance().GD.totalEnemy > spawnList.Count)
        {
                GameObject Enemy = Instantiate(EnemyPrefabs[0], spawnList[i].position, EnemyPrefabs[0].transform.rotation);
                Enemy.GetComponent<EnemyController>().HealthBar = Instantiate(healthBarPrefab, spawnList[i].position, healthBarPrefab.transform.rotation);
                Enemies[i]=Enemy;
        }
        StartCoroutine(Spawn(i));
    }
}
