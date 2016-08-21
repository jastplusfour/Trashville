using UnityEngine;
using System.Collections;

public class PlayerMotion : MonoBehaviour {

    private Vector3    movement;
    private Animator   anim;                     
    private GameObject weaponSlot;
    private Rigidbody  playerRigidBody;


    private int   floorMask;                    // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    private float camRayLength = 100f;          // The length of the ray from the camera into the scene
        

    void Awake()
    {
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask(Tags.floor);

        // Set up references.
        anim            = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody>();
        weaponSlot = GameObject.FindGameObjectWithTag(Tags.weaponSlot);
    }


    void FixedUpdate()
    {
        // Store the input axes.
        float h       = Input.GetAxis("Horizontal");
        float v       = Input.GetAxis("Vertical");
        bool shooting = Input.GetMouseButtonDown(0);

        //Move(h, v);

        // Turn the player to face the mouse cursor.
        Turning();

        // Animate the player.
        Animating(h, v, shooting);
    }


    void Turning()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;
        

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - weaponSlot.transform.position;//transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation
            // Lil velocycle. JUST DEAL WITH IT;            
            weaponSlot.transform.rotation = newRotation;
            //transform.rotation = weaponSlot.transform.rotation;
            transform.rotation = newRotation;
        }
    }


    //void Move(float h, float v)
    //{
    //    // Set the movement vector based on the axis input.
    //    movement.Set(h, 0f, v);

    //    // Normalise the movement vector and make it proportional to the speed per second.
    //    movement = movement.normalized * speed * Time.deltaTime;

    //    // Move the player to it's current position plu s the movement.
    //    transform.position += movement;
    //    //playerRigidBody.MovePosition(transform.position + movement);
    //}


    void Animating(float h, float v, bool shooting)
    {
        anim.SetFloat("HSpeed", h);
        anim.SetFloat("VSpeed", v);
        anim.SetBool ("IsShooting", shooting);
    }
}


