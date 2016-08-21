using UnityEngine;
using System.Collections;

public class AttachmentWeapon : MonoBehaviour {

    public  GameObject weapon;


    private GameObject player;
    private GameObject weaponSlot;
    private PlayerShooting playerShooting;

    private static Vector3 weaponPosition = new Vector3( 0.0042f,  -0.0527f,  0.1193f);
    private static Vector3 weaponRotation = new Vector3(2.02446f, 260.3135f, 20.6933f);

    private Animator playerAnimator;



    void Awake()
    {
        player     = GameObject.FindGameObjectWithTag(Tags.player);
        weaponSlot = GameObject.FindGameObjectWithTag(Tags.weaponSlot);

        playerAnimator = player.GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            AttachWeapon();
            this.enabled = false;
        }

    }


    void AttachWeapon()
    {
        weapon.transform.parent = weaponSlot.transform;
        weapon.transform.localPosition = weaponPosition;
        weapon.transform.localRotation = Quaternion.Euler(Vector3.zero);

        SetCorrectAnitatorState();
    }



    void EnableShooting()
    {
       playerShooting = GetComponentInChildren<PlayerShooting>();
       playerShooting.enabled = true;
    }


    void DisableShooting()
    {
       playerShooting = GetComponentInChildren<PlayerShooting>();
       playerShooting.enabled = false;     
    }


    void SetCorrectAnitatorState()
    {
        if (weapon.tag.Equals(Tags.rifleWeapon))
        {
            playerAnimator.SetTrigger("RifleMotion");
            EnableShooting();
        }

        if (weapon.tag.Equals(Tags.pistolWeapon))
        {
            playerAnimator.SetTrigger("PistolMotion");
            EnableShooting();
        }

        if (weapon.tag.Equals(Tags.meleWeapon))
        {
            playerAnimator.SetTrigger("MeleMotion");
        }
    }


}
