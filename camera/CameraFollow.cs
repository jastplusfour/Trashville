using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing = 0.5f;

  
    private Vector3 offset;


    void Start()
    {
        //SetupCameraOnPlayer();
        offset = transform.position - target.position;
    }


    void FixedUpdate()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        //func();
        
    }


    void SetupCameraOnPlayer()
    {
        Vector3 offset1 = transform.position - target.position;
        Debug.Log(offset1);


        float newX = transform.position.x - offset1.x;
        float newZ = transform.position.z - offset1.z;
        float newY = offset1.y;
       
        offset1.Set(newX, newY, newZ);
        Debug.Log(offset1);

        transform.position = offset1;
    }

    //void func()
    //{
    //    foreach (var building in GameObject.FindGameObjectsWithTag("HighRise"))
    //    {
    //        if (Vector3.Distance(transform.position, building.transform.position) < 60f)
    //        {
    //            if (Camera.main.orthographicSize < MAX_CAMERA_SUZE)
    //            {
    //                Camera.main.orthographicSize += 0.05f;
    //                break;
    //            }

    //        }
    //        else Camera.main.orthographicSize = 10;
    //    }
    // }


}
