using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {

    public int dyingState;
    public int deadBool;
    public int speedFloat;
    public int isAttackBool;

    void Awake() {
        dyingState   = Animator.StringToHash("Base Layer.Dying");
        deadBool     = Animator.StringToHash("Dead");
        speedFloat   = Animator.StringToHash("Speed");
        isAttackBool = Animator.StringToHash("IsAttack");
    }
}
