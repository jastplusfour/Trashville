using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed = 3f;


    private float timer = 0f;
    


    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
