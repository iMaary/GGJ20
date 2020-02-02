    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        enum player { Offensive, Repairman }
        [SerializeField] player typePlayer;

        Rigidbody2D rb;
        SpriteRenderer sr;
        Animator anim;

        bool inMovement;   
        [SerializeField]float lifeCurrent;

        public float speed, lifeBase;

        void Awake()
        {
            LifeSystem();
            lifeCurrent = lifeBase;
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
        }

        void Start()
        {
            if (typePlayer == 0) speed *= 1.5f;
            else speed *= 1f;
        }

        void Update()
        {
            Movement();
        }

        void LifeSystem()
        {
            if(typePlayer == 0)
            {
                lifeBase *= 2f;
            }
            else
            {
                lifeBase *= 1f;
            }
        }

        void Hurt()
        {
            lifeCurrent--;
        }

        void Movement()
        {

        Vector3 movementPlayer;
        OffensiveBehaviour offensiveScript = GetComponent<OffensiveBehaviour>();

        if (typePlayer == 0)
        {
            movementPlayer = new Vector3(Input.GetAxis("HorizontalOffensive"), Input.GetAxis("VerticalOffensive"), 0f);
            if (Input.GetAxis("HorizontalOffensive") == 0 && Input.GetAxis("VerticalOffensive") == 0) inMovement = false;
            else inMovement = true;

            anim.SetBool("up", offensiveScript.upOff);
            anim.SetBool("right", offensiveScript.rightOff);
            anim.SetBool("down", offensiveScript.downOff);
            anim.SetBool("left", offensiveScript.leftOff);
            anim.SetBool("attack", offensiveScript.isAttacking);
        }

            else
            {
                movementPlayer = new Vector3(Input.GetAxis("HorizontalRepairman"), Input.GetAxis("VerticalRepairman"), 0f);
                if (Input.GetAxis("HorizontalRepairman") == 0 && Input.GetAxis("VerticalRepairman") == 0) inMovement = false;
                else inMovement = true;
            }

        //use of getaxisraw? - smooth movement V
        //animation in blend tree V
        //offensive's attack it's a circular atack X -> Cone Attack V

        /*if we manage to finish the 3 phases of the tutorial:
          create arcade mode
          score for the arcade (saved in the game)/

        /if you complete the arcade:
        level editor*/

        if (typePlayer == 0 && offensiveScript.isAttacking) { }
            else transform.position = transform.position + movementPlayer * speed * Time.deltaTime;
        }
    }
