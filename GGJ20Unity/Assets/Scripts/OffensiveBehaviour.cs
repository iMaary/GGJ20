using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffensiveBehaviour : MonoBehaviour
{
    //[SerializeField]Vector3[] attackPosition; /*0 - Up ; 1 - Right ; 2 - Down ; 3 - Left*/

    public bool left, right, up, down;


    [SerializeField]GameObject[] attackObjects;

    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        SetPositionAttack();
    }

    void SetPositionAttack()
    {
            if (Input.GetAxis("HorizontalOffensive") > 0 && Input.GetAxis("VerticalOffensive") == 0)
            {
                left = false;
                right = true;
                up = false;
                down = false;
            }

            else if (Input.GetAxis("HorizontalOffensive") < 0 && Input.GetAxis("VerticalOffensive") == 0)
            {
                left = true;
                right = false;
                up = false;
                down = false;
            }

            else if (Input.GetAxis("HorizontalOffensive") == 0 && Input.GetAxis("VerticalOffensive") > 0)
            {
                left = false;
                right = false;
                up = true;
                down = false;
            }

            else if (Input.GetAxis("HorizontalOffensive") == 0 && Input.GetAxis("VerticalOffensive") < 0)
            {
                left = false;
                right = false;
                up = false;
                down = true;
            }

            else if (Input.GetAxis("HorizontalOffensive") == 0 && Input.GetAxis("VerticalOffensive") == 0)
            {
                left = false;
                right = false;
                up = false;
                down = true;
            }

            if (left)
            {
                attackObjects[0].SetActive(false);
                attackObjects[1].SetActive(false);
                attackObjects[2].SetActive(false);
                attackObjects[3].SetActive(true);
            }
            else if (right)
            {
                attackObjects[0].SetActive(false);
                attackObjects[1].SetActive(true);
                attackObjects[2].SetActive(false);
                attackObjects[3].SetActive(false);
            }
            else if (up)
            {
                attackObjects[0].SetActive(true);
                attackObjects[1].SetActive(false);
                attackObjects[2].SetActive(false);
                attackObjects[3].SetActive(false);
            }
            else if (down)
            {
                attackObjects[0].SetActive(false);
                attackObjects[1].SetActive(false);
                attackObjects[2].SetActive(true);
                attackObjects[3].SetActive(false);
            }
        }
    }
