using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform muzzle;
    public float bulletRate = 0.6f;
    public float bulletSpeed = 100f;
    public float range = 20f;
    public Rigidbody bullet;

    private Transform player;

    private float nextFire;
    [SerializeField]
    private float distanteToShoot;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<EnemyManager>().player;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < distanteToShoot)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + bulletRate;
                Rigidbody bullets = Instantiate(bullet, muzzle.position, muzzle.rotation);
                bullets.velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
                Destroy(bullets.gameObject, 5f);
            }
        }
    }
}
