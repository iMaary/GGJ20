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

        public float speed;

        void Awake()
        {
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

        Vector3 movementPlayer;

        if (typePlayer == 0)
        {
            movementPlayer = new Vector3(Input.GetAxis("HorizontalOffensive"), Input.GetAxis("VerticalOffensive"), 0f);
            anim.SetFloat("Horizontal", Input.GetAxis("HorizontalOffensive"));
            anim.SetFloat("Vertical", Input.GetAxis("VerticalOffensive"));
            if (Input.GetAxis("HorizontalOffensive") == 0 && Input.GetAxis("VerticalOffensive") == 0) inMovement = false;
                else inMovement = true;
        }
        else {
            movementPlayer = new Vector3(Input.GetAxis("HorizontalRepairman"), Input.GetAxis("VerticalRepairman"), 0f);
            //anim.SetFloat("Horizontal", Input.GetAxis("HorizontalRepairman"));
            //anim.SetFloat("Vertical", Input.GetAxis("VerticalRepairman"));
            if (Input.GetAxis("HorizontalRepairman") == 0 && Input.GetAxis("VerticalRepairman") == 0) inMovement = false;
                else inMovement = true; 
        }

        anim.SetBool("inMovement", inMovement);

        //use of getaxisraw? - smooth movement V
        //animation in blend tree V
        //offensive's attack it's a circular atack X -> Cone Attack V

        /*if we manage to finish the 3 phases of the tutorial:
          create arcade mode
          score for the arcade (saved in the game)/

        /if you complete the arcade:
        level editor*/
        transform.position = transform.position + movementPlayer * speed * Time.deltaTime;
        }
    }
