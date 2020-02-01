using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveBehaviour : MonoBehaviour
{ 
    public bool leftOff, rightOff, upOff, downOff, isAttacking;
    [SerializeField] float timeAttack;

    [SerializeField]GameObject[] attackObjects;

    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        SetPositionAttack();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttacking = true;
            StartCoroutine(returnVariable(timeAttack));
        }
    }

    IEnumerator returnVariable(float timeAttack)
    {
        yield return new WaitForSeconds(timeAttack);
        isAttacking = false;
    }

    void SetPositionAttack()
    {
            //set diretions
            if (Input.GetKeyDown(KeyCode.W))
            {
                leftOff = false;
                rightOff = false;
                upOff = true;
                downOff = false;
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                leftOff = false;
                rightOff = false;
                upOff = false;
                downOff = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                leftOff = false;
                rightOff = true;
                upOff = false;
                downOff = false;
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                leftOff = true;
                rightOff = false;
                upOff = false;
                downOff = false;
            }

            //activate gameobject area's attack
            if (!isAttacking)
            {
                if (leftOff)
                {
                    attackObjects[0].SetActive(false);
                    attackObjects[1].SetActive(false);
                    attackObjects[2].SetActive(false);
                    attackObjects[3].SetActive(true);
                }
                if (rightOff)
                {
                    attackObjects[0].SetActive(false);
                    attackObjects[1].SetActive(true);
                    attackObjects[2].SetActive(false);
                    attackObjects[3].SetActive(false);
                }
                if (upOff)
                {
                    attackObjects[0].SetActive(true);
                    attackObjects[1].SetActive(false);
                    attackObjects[2].SetActive(false);
                    attackObjects[3].SetActive(false);
                }
                if (downOff)
                {
                    attackObjects[0].SetActive(false);
                    attackObjects[1].SetActive(false);
                    attackObjects[2].SetActive(true);
                    attackObjects[3].SetActive(false);
                }
            }  
        }
    }
