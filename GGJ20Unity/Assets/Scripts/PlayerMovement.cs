    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RepairManBehaviour : MonoBehaviour
    {
        enum player { Offensive, Repairman }
        [SerializeField] player typePlayer;

        Rigidbody2D rb;
        SpriteRenderer sr;
        Animator anim;

        [SerializeField]
        float speed;

        void Start()
        {
            if (typePlayer == 0) speed *= 1.5f;
            else speed *= 1f;
        }

        void Update()
        {
            Vector3 movementPlayer;
            if (typePlayer == 0) movementPlayer = new Vector3(Input.GetAxis("HorizontalOffensive"), Input.GetAxis("VerticalOffensive"), 0f);
            else movementPlayer = new Vector3(Input.GetAxis("HorizontalRepairman"), Input.GetAxis("VerticalRepairman"), 0f);

            //use of getaxisraw? - smooth movement
            //animation in blend tree
            //offensive's attack it's a circular atack

            /*if we manage to finish the 3 phases of the tutorial:
              create arcade mode
              score for the arcade (saved in the game)/

            /if you complete the arcade:
            level editor*/

            transform.position = transform.position + movementPlayer * speed * Time.deltaTime;
        }
    }
