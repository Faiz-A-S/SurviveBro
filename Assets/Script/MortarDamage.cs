using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarDamage : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float radius;

    private void OnCollisionEnter(Collision collision)
    {
        ExplosionDamage(transform.position, radius);
        Destroy(gameObject);
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        var hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            var rb = hitCollider.GetComponent<Rigidbody>();
            rb.AddExplosionForce(500f, transform.position, 5);
        }
    }
}
