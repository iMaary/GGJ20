using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveBehaviour : MonoBehaviour
{
    [SerializeField]Vector3[] attackPosition; /*0 - Up ; 1 - Right ; 2 - Down ; 3 - Left*/

    bool left, right, up, down;
    [SerializeField]bool[] dir;


    [SerializeField]Transform attackObject;

    private void Update()
    {
        Attack();
        left = dir[3]; right = dir[1]; up = dir[0]; down = dir[2];
    }

    void Attack()
    {
        SetPositionAttack();
    }

    void SetPositionAttack()
    {
        if (left) attackObject.position = attackPosition[3];
            else if (right) attackObject.position = attackPosition[1];
                else if (up) attackObject.position = attackPosition[0];
                    else if (down) attackObject.position = attackPosition[2];

        SetRotationAttack();   
    }

    void SetRotationAttack()
    {
        if (left || right) attackObject.rotation = Quaternion.Euler(0, 0, 90);
            else if(up || down) attackObject.rotation = Quaternion.Euler(0, 0, 0);
    }
}
