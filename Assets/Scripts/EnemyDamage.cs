using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float damage = 10;
    [SerializeField] AudioClip damageSFX;

    EnemyAI enemyAI;
    Player player;
    private void Start()
    { 
        player = FindObjectOfType<Player>();
        enemyAI = FindObjectOfType<EnemyAI>();
    }
    private void AttackTarget()
    {
        if (!enemyAI.isNearToAttack) { return; }
        player.TakeDamage(damage);
        if (damageSFX)
        {
            AudioSource.PlayClipAtPoint(damageSFX, player.transform.position);
        }
    }
}
