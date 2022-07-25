using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health = 100;
    public float speed;
    [Tooltip("normal 0.05")]
    [Header("Dar dar weapon")]
    public float bulletRate = 0.25f;
    public float bulletSpeed = 100f;
    public float bulletLife = 2f;
    public Rigidbody bullet;
    public Transform muzzle;

    [Header("Mortar weapon")]
    public float bulletRateMortar = 0.25f;
    public float bulletSpeedMortar = 100f;
    public float bulletLifeMortar = 2f;
    public Rigidbody bulletMortar;
    public Transform muzzleMortar;

    [Space]
    public Camera cameraMain;
    public LayerMask groundMask;
    

    private CharacterController charcon;
    private float nextFire;
    private float nextFireMortar;
    private Transform groundCheck;


    // Start is called before the first frame update
    void Start()
    {
        charcon = GetComponent<CharacterController>();
        groundCheck = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Move();
        Look();
        Gravity();
    }

    private void Fire()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + bulletRate;
            Rigidbody bullets = Instantiate(bullet, muzzle.position, muzzle.rotation);
            bullets.velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
            Destroy(bullets.gameObject, bulletLife);
        }

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireMortar)
        {
            nextFireMortar = Time.time + bulletRateMortar;
            Rigidbody bullets = Instantiate(bulletMortar, muzzleMortar.position, muzzleMortar.rotation);
            bullets.AddForce(transform.TransformDirection(new Vector3(0,1,1)* bulletSpeedMortar));
        }
    }

    private void Look()
    {
        GetMousePosition(out bool returnYes, out Vector3 returnPos);
        if(returnYes)
        {
            var direction = returnPos - transform.position;
            direction.y = 0;
            transform.forward = direction;
        }
    }

    private void GetMousePosition(out bool returnYes, out Vector3 returnPos)
    {
        var ray = cameraMain.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out var hitInfo, Mathf.Infinity, groundMask))
        {
            returnYes = true;
            returnPos = hitInfo.point;
        }
        else
        {
            returnYes = false;
            returnPos = hitInfo.point;
        }
    }
    private void Gravity()
    {
        bool onGround = Physics.CheckSphere(groundCheck.position, 0.5f, groundMask);
        if(!onGround)
        {
            charcon.Move(Vector3.down * 6f * Time.deltaTime);
        }
    }
    private void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            charcon.Move(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            charcon.Move(Vector3.left * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            charcon.Move(Vector3.right * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            charcon.Move(Vector3.back * speed * Time.deltaTime);
        }
    }

    private void GetHit()
    {
        if(health <= 0)
        {
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        health -= 1;
        Destroy(other.gameObject);
        GetHit();
    }
}
