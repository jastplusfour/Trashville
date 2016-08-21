using UnityEngine;
using System.Collections;

public class AlienHealth : MonoBehaviour
{

    public int startingHealth = 100;            // The amount of health the Alien starts the game with.
    public int currentHealth;                   // The current health the Alien has.
    public float sinkSpeed = 2.5f;              // The speed at which the Alien sinks through the floor when dead.
    //public AudioClip deathClip;                 // The sound to play when the Alien dies.


    Animator anim;                              // Reference to the animator.
    //AudioSource AlienAudio;                     // Reference to the audio source.
    //ParticleSystem hitParticles;                // Reference to the particle system that plays when the Alien is damaged.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    bool isDead;                                // Whether the Alien is dead.
    bool isSinking;                             // Whether the Alien has started sinking through the floor.
    AlienMovement AlienMovement;
    AlienAttack AlienAttack;


    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        //AlienAudio      = GetComponent<AudioSource>();
        //hitParticles    = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        // Setting the current health when the Alien first spawns.
        currentHealth = startingHealth;

        AlienMovement = GetComponent<AlienMovement>();
        AlienAttack = GetComponent<AlienAttack>();
    }

    void Update()
    {
        // If the Alien should be sinking...
        if (isSinking)
        {
            // ... move the Alien down by the sinkSpeed per second.
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // If the Alien is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

        // Play the hurt sound effect.
        //AlienAudio.Play();

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;

        //// Set the position of the particle system to where the hit was sustained.
        //hitParticles.transform.position = hitPoint;

        //// And play the particles.
        //hitParticles.Play();

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            // ... the Alien is dead.
            Death();
        }
    }


    void Death()
    {
        // The Alien is dead.
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        capsuleCollider.isTrigger = true;

        // Tell the animator that the Alien is dead.
        anim.SetTrigger("Die");


        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        //AlienAudio.clip = deathClip;
        //AlienAudio.Play();


        AlienMovement.enabled = false;
        AlienAttack.enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }


    public void StartSinking()
    {
        // Find and disable the Nav Mesh Agent.


        // Find the rigidbody component and make it kinematic (since we use Translate to sink the Alien).
        GetComponent<Rigidbody>().isKinematic = true;

        // The Alien should no sink.
        isSinking = true;

        // Increase the score by the Alien's score value.
        //ScoreManager.score += scoreValue;

        // After 2 seconds destory the Alien.
        Destroy(gameObject, 2f);
    }


}
