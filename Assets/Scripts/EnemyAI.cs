using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float lookSpeed = 5f;

    NavMeshAgent navMeshAgent;
    Animator enemyAnimator;
    Player player;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoke = false;
    public bool isNearToAttack;
    bool isDead = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponentInChildren<Animator>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (isDead) { return; }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoke)
        {
            FaceTarget();
            EngageTarget();
        }else
        {
            enemyAnimator.SetBool("Run", false);
        }

        if (distanceToTarget < chaseRange)
        {
            isProvoke = true;

        }
        //else  
        //{
        //    isProvoke = false; 
        //}

    }

    private void EngageTarget()
    {
        enemyAnimator.SetBool("Run", true);
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
            
            isNearToAttack = false;
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            enemyAnimator.SetTrigger("Attack");
            isNearToAttack = true;
        }

    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
    private void FaceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);
    }
    public void OnDamageTaken()
    {
        isProvoke = true;
    }
    private void Death()
    {
        enemyAnimator.SetTrigger("Death");
        GetComponent<Collider>().enabled = false;
        isDead = true;
        navMeshAgent.isStopped = true;
    }
}
