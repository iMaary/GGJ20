using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusStaticBehaviours : MonoBehaviour
{
    private static List<GameObject> chips;
    [SerializeField] private float speed;
    private int numChip, numChipBefore;
    private Transform target;
    private GameObject corrompendo;

    private void Start()
    {
        chips = new List<GameObject>(GameObject.FindGameObjectsWithTag("Chip"));
        SetVirusToChip();
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void SetVirusToChip()
    {
        numChip = Random.Range(0, chips.Count);
        this.target = chips[numChip].gameObject.GetComponent<Transform>();
        print(numChip);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Chip" && col.gameObject == chips[numChip].gameObject && col.gameObject.GetComponent<ChipsBehaviours>().breaked == false)
        {
            corrompendo = col.gameObject;
            Invoke("Corromper", 1f);  
        }
    }
    void Corromper()
    {
        corrompendo.gameObject.GetComponent<ChipsBehaviours>().breaked = true;
        corrompendo.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);
        corrompendo.tag = "Corrompido";
        ReListar();
    }
    public void ReListar()
    {
        chips = new List<GameObject>(GameObject.FindGameObjectsWithTag("Chip"));
        if (chips.Count != 0)
            SetVirusToChip();
    }
    

}
