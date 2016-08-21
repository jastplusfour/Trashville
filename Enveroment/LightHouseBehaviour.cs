using UnityEngine;
using System.Collections;

public class LightHouseBehaviour : MonoBehaviour {

    public Transform[] checkPoints;
    public float       smoothing = 20f;

    private Transform direction;
    private float timer = 0f;
    private float duration;



    void Awake()
    {
        ChangeDirection();
    }


    void FixedUpdate()
    {
        Moving();
    }


    void Moving()
    {
        duration = Random.Range(3, 5);

        if (timer > duration)
        {
            ChangeDirection();
            timer = 0;
        }
        timer += Time.deltaTime;

        var targetRotation = Quaternion.LookRotation(direction.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothing * Time.deltaTime);
    }


    void ChangeDirection()
    {
        direction = checkPoints[Random.Range(0, checkPoints.Length)];
    }

}
