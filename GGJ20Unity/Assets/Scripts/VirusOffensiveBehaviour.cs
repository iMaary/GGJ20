using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusOffensiveBehaviour : MonoBehaviour
{
    public GameObject target;
    private Animator amt;
    private SpriteRenderer sr;
    private bool testDistance;
    [SerializeField]
    private int speed = 5;
    private int dano = 1;
    private string atkp;

    [SerializeField]int life, lifeCurrent;

    // Start is called before the first frame update
    void Start()
    {
        amt = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        lifeCurrent = life;
        target = GameObject.FindWithTag("Player 0");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        testDistance = ((target.transform.position.x > transform.position.x || target.transform.position.x < transform.position.x) &&
            Mathf.Abs(target.transform.position.x) - Mathf.Abs(transform.position.x) > Mathf.Abs(target.transform.position.y) - Mathf.Abs(transform.position.y));
        amt.SetBool("left", testDistance);
        amt.SetBool("behind", target.transform.position.y > transform.position.y && testDistance == false);
        sr.flipX = (target.transform.position.x > transform.position.x) ? true : false;
        if (lifeCurrent < 1)
        {
            StartCoroutine(Die());
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player 0" || col.gameObject.tag == "Player 1")
        {
            print(1);
            speed = 0;
            if (amt.GetBool("left"))
            {
                print(2);
                atkp = "AtaqueLeft";
                amt.SetBool("AtaqueLeft", true);
            }
            else
            {
                print(3);
                atkp = (transform.position.y > col.gameObject.transform.position.y) ? "AtaqueIdle" : "AtaqueBhnd";
                amt.SetBool(atkp, true);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Player 0" || col.gameObject.tag == "Player 1") && life > 0)
        {
            amt.SetBool(atkp, false);
            speed = 5;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "attackOffensive")
        {
            lifeCurrent--;
        }
    }

    IEnumerator Die()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        speed = 0;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    //IEnumerator HurtAgain()
    //{
    //    yield return new WaitForSeconds(.5f);
    //    canWalk = true;
    //    yield return new WaitForSeconds(.5f);
    //    invulnerable = false;
    //}
}
