using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 100;
    //Animator enemyAnimator;

    void Start()
    {
        //enemyAnimator = GetComponentInChildren<Animator>();
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        
        hitpoints -= damage;
        if (hitpoints <= 0)
        {
            BroadcastMessage("Death");
        }
    }

    //private void Death()
    //{
    //    enemyAnimator.SetTrigger("Death");
    //    GetComponent<Collider>().enabled = false;
    //    Destroy(GetComponent<EnemyAI>());
    //    print("Death");
    //    //Destroy(gameObject);
    //}
}
