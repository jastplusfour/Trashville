using UnityEngine;
using System.Collections;

public class AlienMovement : MonoBehaviour
{

    GameObject enemy;                // Reference to the enemy's position.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake()
    {
        TargetOnNextEnemy();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the enemy have health left...
        if (enemyHealth.currentHealth > 0)
        {
           //  ... set the destination of the nav mesh agent to the enemy.
            nav.SetDestination(enemy.transform.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            TargetOnNextEnemy();
            //nav.enabled = false;
        }
    }


    void TargetOnNextEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.enemy);
        enemy = enemies[Random.Range(0, enemies.Length)];
        enemyHealth = enemy.GetComponent<EnemyHealth>();

    }

    public GameObject GetTargetEnemy()
    {
        return enemy;
    }

}
