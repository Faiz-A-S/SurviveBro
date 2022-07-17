using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health = 100;
    public float speed;
    [Tooltip("normal 0.05")]
    public float bulletRate = 0.25f;
    public float bulletSpeed = 100f;
    public Camera cameraMain;
    public LayerMask groundMask;
    public Rigidbody bullet;
    public Transform muzzle;

    private CharacterController charcon;
    private float nextFire;


    // Start is called before the first frame update
    void Start()
    {
        charcon = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Move();
        Look();
    }

    private void Fire()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + bulletRate;
            Rigidbody bullets = Instantiate(bullet, muzzle.position, muzzle.rotation);
            bullets.velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
            Destroy(bullets.gameObject, 5f);
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
}
