using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float turnSmoothing = 15f;
    public float speedDampTime = 0.1f;


    private Animator anim;
    private HashIDs hash;

    public float speed = 6f;
    private Vector3 movement;


    void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

        //Set the layer of 
        //anim.SetLayerWeight(1, 1f);
    }


    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        MovementManagment(h, v);
        Move(h, v);
    }


    void MovementManagment(float horizontal, float vertical)
    {
        if (horizontal != 0f || vertical != 0f)
        {
            Rotating(horizontal, vertical);
            anim.SetFloat(hash.speedFloat, 5.5f, speedDampTime, Time.deltaTime);
        }
        else
            anim.SetFloat(hash.speedFloat, 0f);
    }


    void Rotating(float horizontal, float vertical)
    {
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);
        transform.rotation = newRotation;
    }


    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        transform.position += movement;
        //transform.position.Set(transform.position + )
    }
}
