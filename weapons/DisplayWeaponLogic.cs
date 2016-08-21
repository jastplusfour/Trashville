using UnityEngine;
using System.Collections;

public class DisplayWeaponLogic : MonoBehaviour {

    public float smoothing = 20f;


    private float timer = 0f;
    private float duration;
    private Vector3 direction;

    //private enum direction
    //{
    //    Left,
    //    Right,
    //    Up,
    //    Down
    //}

    Vector3 back = new Vector3(346, 193, 138);
    Vector3   up = new Vector3(313, 248, 106);


    void Awake()
    {
        ChangeDirection();
    }
    

    void FixedUpdate()
    {
        RandomRotation();
        //Rotate();
    }


    void Rotate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * smoothing);
    }



    void RandomRotation()
    {
        duration = Random.Range(5, 5);
        int x = Random.Range(0, 1);

        if (timer > duration)
        {
            //ChangeDirection();
            func(x);
            timer = 0;
        }
        transform.Rotate(direction * Time.deltaTime * smoothing);
        timer += Time.deltaTime;
    }


    void ChangeDirection()
    {
        direction.x = Random.Range(288, 346);
        direction.y = Random.Range(193, 255);
        direction.z = Random.Range(101, 138);
    }

    void func(int x)
    {
        if (x == 0)
        {
            direction = back;

        }
        else direction = up;
    }
}
