using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] string nextLevel;
    [SerializeField] GameObject boss;
    [SerializeField] SpawnManager spawnManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && boss== null && DataManager.GetInstance().GD.totalEnemy <= 0)
        {
            DataManager.GetInstance().GD.totalEnemy = spawnManager.totalEnemy;
            EditorSceneManager.LoadScene("Assets/_Game/Scenes/" + nextLevel + ".unity");
        }
    }
}
