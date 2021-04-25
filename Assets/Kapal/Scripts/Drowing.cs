using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Drowing : MonoBehaviour
{
    bool isDrown;
    bool isDead;
    FloatShip floating;

    public float downTo = 0f;
    public float duration = 0f;
    public float startingHealth = 100;
    public float currentHealth;

    void Start()
    {
        floating = GetComponent<FloatShip>();
        currentHealth = startingHealth;
    }

    public void TakeDamage(float amount)
    {
        if (isDead)
            return;
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            StartCoroutine(Drown(downTo, duration));
        }
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Missile")
        {
            //StartCoroutine(Drown(downTo, duration));
            TakeDamage()
        }
    }*/

    private IEnumerator Drown(float downTo,float duration)
    {
        yield return new WaitForSeconds(0.5f);
        if (!isDrown)
        {
            isDrown = true;
            floating.enabled = false;
            transform.DOLocalMoveY(-downTo, duration);
            Destroy(gameObject, 20f);
        }
    }
}
