using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAndLevels : MonoBehaviour
{
    public int level;
    public int enemyCount = 0;
    public GameObject GoButton,enemySpawnPoint;
    public GameObject[] Enemies = new GameObject[5];
    private void Start()
    {
         level = 3;
    }
    public void Go_Button()
    {
        GoButton.SetActive(false);
        while (enemyCount < 2 * level)
        {
            Instantiate(Enemies[Random.Range(0,Enemies.Length)],enemySpawnPoint.transform.position+new Vector3(Random.Range(-6,6),0,0),Quaternion.identity);
            //Enemies[Random.Range(0, Enemies.Length)].SetActive(true);
            enemyCount++;
        }
    }

  
}
