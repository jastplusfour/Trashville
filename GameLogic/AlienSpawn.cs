using UnityEngine;
using System.Collections;

public class AlienSpawn : MonoBehaviour {

    public GameObject alien;
    public Transform spwanPoint;


    private void Start()
    {
        Invoke("Spawn", 5f);
    }


    private void Spawn()
    {
        Instantiate(alien, spwanPoint.position, spwanPoint.rotation);
    }
}
