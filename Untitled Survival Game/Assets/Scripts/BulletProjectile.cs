using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{

    [SerializeField] private Transform targetHit;
    [SerializeField] private Transform targetMiss;
    [SerializeField] private GameObject enemy;

    private Rigidbody bulletRigidBody;
    
    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 50f;
        bulletRigidBody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BulletTarget>() != null)
        {
            // Hit target
            Instantiate(targetHit, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<BulletTarget>().TakeDamage(20);
            
        }
        else
        {
            // Hit something else
            Instantiate(targetMiss, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

}
