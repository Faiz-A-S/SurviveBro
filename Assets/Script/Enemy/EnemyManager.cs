using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform player;
    public int health = 10;
    public float speed = 3.5f;
    public Spawner spawn;
    public int Cost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var followSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, followSpeed);
        transform.LookAt(player);
        if(health <= 0)
        {
            EnemyDie();
        }
    }

    private void EnemyDie()
    {
        Destroy(gameObject);
        spawn.enemyOnField -= 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            health -= other.gameObject.GetComponent<Damage>().damage;
            Destroy(other.gameObject);
        }
    }
}
