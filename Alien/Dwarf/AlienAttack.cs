using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlienAttack : MonoBehaviour
{
         
    public float timeBetweenAttacks = 5f;       // The time in seconds between each attack.
    public int   attackDamage = 20;               // The amount of health taken away per attack.


    private float timer = 0f;
    private bool  enemyInRange;

    private List<GameObject> enemyList = new List<GameObject>();
    private Animator anim;



    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the enemy is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && enemyInRange)
        {
            // ... attack.
            anim.SetBool("IsAttack", true);
            MassiveAttack();
        }

        //if (!enemyInRange)
        if (enemyList.Capacity <= 0)
            anim.SetBool("IsAttack", false);
    }



    void MassiveAttack()
    {
        timer = 0;
        foreach (var enemy in enemyList)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth.currentHealth > 0)
            enemyHealth.TakeDamage(attackDamage, Vector3.zero);
        }
        enemyList.Clear();
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(Tags.enemy) &&
            !enemyList.Contains(other.gameObject) )
        {
            enemyList.Add(other.gameObject);
            enemyInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals(Tags.enemy) &&
            !enemyList.Contains(other.gameObject) )
        {
            enemyList.Remove(other.gameObject);
            //enemyInRange = false;
        }
    }

}
