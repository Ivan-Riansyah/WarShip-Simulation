using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    private float speed = 40f;
    public GameObject impactEffect;
    public float damage = 25f;

    private void Start()
    {
        Destroy(gameObject, 8f);
    }

    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }

        else
        {
            Debug.Log("no speed");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.gameObject.name + " hit " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            return;
        }

        else
        {
            speed = 0f;
            Destroy(gameObject);
            Drowing enemyhealth = collision.transform.GetComponent<Drowing>();

            if (enemyhealth != null)
            {
                enemyhealth.TakeDamage(damage);
            }

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            var hitVFX = Instantiate(impactEffect, pos, rot);
            Destroy(hitVFX, 1f);
        }
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            return;
        }
        else
        {
            Drowing enemyHealth = other.transform.GetComponent<Drowing>();
            Debug.Log(this.gameObject.name + " hit " + other.gameObject.name);

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            speed = 0f;
            Destroy(gameObject);
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, transform.right);
            Vector3 pos = transform.position;
            var hitVFX = Instantiate(impactEffect, pos, rot);
            Destroy(hitVFX, 1f);
        }
    }*/
}
