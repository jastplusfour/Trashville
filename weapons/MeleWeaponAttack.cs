using UnityEngine;
using System.Collections;

public class MeleWeaponAttack : MonoBehaviour {

    //public float timeBetweenAttacks = 2f;    
    //public int   attackDamage       = 100;


    //private GameObject  player;
    //private Animator    playerAnimator;

    //private GameObject  enemy;
    //private EnemyHealth enemyHealth;

    //private bool        isAttack;
    //private bool        enemyInRange;

    //private float       timer;



    //void Awake()
    //{
    //    //enemy  = GameObject.FindGameObjectWithTag(Tags.enemy);
    //    player = GameObject.FindGameObjectWithTag(Tags.player);
    //    playerAnimator = player.GetComponent<Animator>();
    //}


    //void FixedUpdate()
    //{
    //    timer += Time.deltaTime;

    //    // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
    //    if (timer >= timeBetweenAttacks && enemyInRange && enemyHealth.currentHealth > 0)
    //    {
    //        // ... attack.
    //        //Attack();
    //    }

    //    if (!enemyInRange)
    //    {
    //        playerAnimator.SetBool("IsAttack", false);
    //    }

    //    //// If the player has zero or less health...
    //    //if (enemyHealth.currentHealth <= 0)
    //    //{
    //    //    // ... tell the animator the player is dead.
    //    //    playerAnimator.SetTrigger("PlayerDead");
    //    //}
    //}




    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject == enemy)
    //    {
    //        enemyInRange = true;

    //        enemy       = other.gameObject;
    //        enemyHealth = enemy.GetComponent<EnemyHealth>();

    //        Debug.Log(enemyHealth.currentHealth);
    //    }
    //}


    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject == enemy)
    //        enemyInRange = false;
    //}


    //void Attack()
    //{
    //    timer = 0f;

    //    if (enemyHealth.currentHealth > 0)
    //    {
    //        // ... damage the player.
    //        playerAnimator.SetBool("IsAttack", true);
    //        enemyHealth.TakeDamage(attackDamage, Vector3.zero);
    //    }
    //}


    public int   damage = 100;
    public float attackDistance = 0.05f;

    //private EnemyHealth enemyHealth;
    private Ray         attackRay;
    private RaycastHit  attackHit;

    GameObject weaponSlot;
    //private int shootableMask;



    void Awake()
    {
        weaponSlot = GameObject.FindGameObjectWithTag(Tags.weaponSlot);
    }


    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Attack();
        }
    }



    void Attack()
    {
        attackRay.origin    = weaponSlot.transform.position;
        attackRay.direction = weaponSlot.transform.forward;

        if (Physics.Raycast(attackRay, out attackHit, attackDistance))//, shootableMask))
        {
            EnemyHealth enemyHealth = attackHit.collider.GetComponent<EnemyHealth>();


            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage, attackHit.point);
            }
        }
        Debug.Log("Attack");
    }


}
