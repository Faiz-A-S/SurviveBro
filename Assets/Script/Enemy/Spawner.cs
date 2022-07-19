using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemy;
    public Transform player;
    public int maxEnemyOnField;
    public int enemyOnField;
    public int spawnRate;
    public float rotationSpeed;
    public int wave = 1;
    //public List<int> maxCostPerWave;

    private int costThisTime;
    private int oldCostThisTime;
    private float timer = 0;
    private float timerWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        costThisTime = 10;
        oldCostThisTime = costThisTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerWave += Time.deltaTime;
        WaveSpawn();
        transform.RotateAround(player.position,new Vector3(0,1,0), rotationSpeed * Time.deltaTime);
    }

    private void WaveSpawn()
    {
        if(timerWave >= 3)
        {
            if (enemyOnField < maxEnemyOnField && timer >= spawnRate && costThisTime >= 0)
            {
                int random = UnityEngine.Random.Range(0, enemy.Count);
                costThisTime = costThisTime - enemy[random].GetComponent<EnemyManager>().Cost;
                GameObject enemys = Instantiate(enemy[random], transform.position, transform.rotation);
                enemys.SetActive(true);
                timer = 0;
                enemyOnField += 1;
            }
            if (enemyOnField == 0)
            {
                timerWave = 0;
                wave += 1;
                costThisTime = oldCostThisTime * wave;
            }
        }
    }
}
