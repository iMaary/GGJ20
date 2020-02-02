using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusOffensiveBehaviour : MonoBehaviour
{
    public GameObject target;

    [SerializeField]
    private int speed = 5;
    private int dano = 1;

    [SerializeField]int life, lifeCurrent;

    // Start is called before the first frame update
    void Start()
    {
        lifeCurrent = life;
        target = GameObject.FindWithTag("Player 0");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if(lifeCurrent < 1)
        {
            StartCoroutine(Die());
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player 0")
        {
            speed = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player 0" && life > 0)
        {
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
