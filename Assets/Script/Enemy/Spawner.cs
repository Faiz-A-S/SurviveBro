using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public int maxEnemyOnField;
    public int enemyOnField;
    public int spawnRate;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if(enemyOnField < maxEnemyOnField && timer >= spawnRate )
        {
            Spawn();
            timer = 0;
            enemyOnField += 1;
        }
    }

    private void Spawn()
    {
        GameObject enemys = Instantiate(enemy, transform.position, transform.rotation);
        enemys.SetActive(true);
    }
}
