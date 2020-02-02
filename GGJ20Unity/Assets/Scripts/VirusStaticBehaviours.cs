using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusStaticBehaviours : MonoBehaviour
{
    private Animator amt;
    private SpriteRenderer sr;
    private static List<GameObject> chips;
    [SerializeField] private float speed;
    private int numChip, numChipBefore;
    private Transform target;
    private GameObject corrompendo;
    private bool isLoose = false, animChange;
    private string atkp;
    private bool testDistance;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        amt = GetComponent<Animator>();
        chips = new List<GameObject>(GameObject.FindGameObjectsWithTag("Chip"));
        SetVirusToChip();
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //amt.SetBool("left", ((target.transform.position.x > transform.position.x || target.transform.position.x < transform.position.x) && chips.Count != 0) ? true : false);

        testDistance = ((target.transform.position.x > transform.position.x || target.transform.position.x < transform.position.x) &&
            Mathf.Abs(target.transform.position.x) - Mathf.Abs(transform.position.x) > Mathf.Abs(target.transform.position.y) - Mathf.Abs(transform.position.y)) && chips.Count != 0;
        amt.SetBool("left", testDistance);
        amt.SetBool("behind", target.transform.position.y > transform.position.y && testDistance == false);
        //if()

        //amt.SetBool("behind", ((target.transform.position.y > transform.position.y ) && amt.GetBool("left") == false && chips.Count != 0) ? true : false);
        //animChange = (Mathf.Abs(target.transform.position.x) - Mathf.Abs(transform.position.x) > Mathf.Abs(target.transform.position.y) - Mathf.Abs(transform.position.y)) ? true : false;
    }

    public void SetVirusToChip()
    {
        numChip = Random.Range(0, chips.Count);
        this.target = chips[numChip].gameObject.GetComponent<Transform>();
        sr.flipX = (target.transform.position.x > transform.position.x) ? true : false;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Chip" && col.gameObject == chips[numChip].gameObject && col.gameObject.GetComponent<ChipsBehaviours>().breaked == false)
        {
            corrompendo = col.gameObject;
            if (transform.position.x - col.transform.position.x >= 1f || transform.position.x - col.transform.position.x <= -1f)
            {
                atkp = "AtaqueLeft";
                amt.SetBool("AtaqueLeft", true);
            }
            else
            {
                atkp = (transform.position.y > col.gameObject.transform.position.y) ? "AtaqueIdle" : "AtaqueBhnd";
                amt.SetBool(atkp, true);
            }
            Invoke("Corromper", 1.5f);
        }
    }
    void Corromper()
    {
        corrompendo.gameObject.GetComponent<ChipsBehaviours>().breaked = true;
        corrompendo.tag = "Corrompido";
        amt.SetBool(atkp, false);
        ReListar();
    }
    public void ReListar()
    {
        chips = new List<GameObject>(GameObject.FindGameObjectsWithTag("Chip"));
        if (chips.Count != 0)
            SetVirusToChip();
        else
            print("you loose");
    }


}
