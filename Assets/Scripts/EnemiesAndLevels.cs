using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesAndLevels : MonoBehaviour
{
    public int level;
    public int enemyCount = 0;
    public GameObject GoButton,enemySpawnPoint;
    public GameObject[] Enemies = new GameObject[5];
    public GameObject Market,Controlpanel;
    bool active=false;
    public TextMeshProUGUI yazi;

    private void Start()
    {
         level = 1;
        
    }
    public void Go_Button()
    {
        level++;
        yazi.transform.gameObject.SetActive(false);
        GoButton.SetActive(false);
        while (enemyCount < 2 * level - 1)
        {

            Instantiate(Enemies[Random.Range(0, Enemies.Length)], enemySpawnPoint.transform.position + new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6)), Quaternion.identity);
            enemyCount++;
        }
    }

    public void Update()
    {

        yazi.text = "WAWE" + level;
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0 )
        {
           yazi.transform.gameObject.SetActive(true);
           GoButton.SetActive(true);
        }
        
    }
    public void MarketSwitch()
    {
        active = !active;
        Market.SetActive(active);
        Controlpanel.SetActive(!active);
    }
}
