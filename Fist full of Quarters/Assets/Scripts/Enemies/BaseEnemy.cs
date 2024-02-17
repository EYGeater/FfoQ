using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour
{
    public EnemyData enemyData;
    private int health;
    private NavMeshAgent navAgent;

    private void Start()
    {
        health = enemyData.maxHealth;
        navAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(FindTargetsRoutine());
    }

    private IEnumerator FindTargetsRoutine()
    {
        while (true)
        {
            float distToOne = 
                Mathf.Abs(Vector3.Distance(PlayerTracker.Main.player1.transform.position, gameObject.transform.position));

            float distToTwo =
                Mathf.Abs(Vector3.Distance(PlayerTracker.Main.player2.transform.position, gameObject.transform.position));

            if (distToOne <= enemyData.distToAttack)
            {
                Attack(PlayerTracker.Main.player1.gameObject);
                yield return new WaitForSeconds(enemyData.attackDuration);
            } else if (distToTwo <= enemyData.distToAttack)
            {
                Attack(PlayerTracker.Main.player2.gameObject);
                yield return new WaitForSeconds(enemyData.attackDuration);
            } else
            {
                if (distToOne < distToTwo)
                {
                    navAgent.SetDestination(PlayerTracker.Main.player1.transform.position);
                }
                else
                {
                    navAgent.SetDestination(PlayerTracker.Main.player2.transform.position);
                }

                yield return new WaitForSeconds(enemyData.rerouteTime);
            }
        }
    }

    public void Attack(GameObject target)
    {
        Debug.Log("Attack");
    }

    public void ChangeHealth(int delta)
    {
        health += delta;
        if(health < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
