using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairManBehaviour : MonoBehaviour
{
    private string[] setas = new string[4] { "up", "right", "down", "left" };
    private int[] setasPuzzle = new int[4];
    private GameObject[] instantArrows = new GameObject[4];
    private string seta;
    private GameObject oPuzzle;
    private GameObject fixing;

    [SerializeField]
    public GameObject telaPuzzle;
    private bool onPuzzle = false;
    private int seq;
    public GameObject[] arrowsSr;
    private int vida = 3;

    void Start()
    {

    }

    void Update()
    {
        if (onPuzzle) Puzzle();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Corrompido")
        {
            fixing = col.gameObject;
            oPuzzle = Instantiate(telaPuzzle, transform.position, Quaternion.identity);
            this.gameObject.GetComponent<PlayerMovement>().speed = 0;
            for (int i = 0; i < 4; i++)
            {
                setasPuzzle[i] = Random.Range(0, 4);
                instantArrows[i] = Instantiate(arrowsSr[setasPuzzle[i]], transform.position - new Vector3(2 - (i * 1.3f), 0), Quaternion.identity);
                print(setas[setasPuzzle[i]]);
            }
            onPuzzle = true;
        }
    }
    void Puzzle()
    {
        if (Input.GetKeyDown(setas[setasPuzzle[seq]]))
        {
            instantArrows[seq].GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.3f);
            seq++;
            if (seq == 4)
            {
                onPuzzle = false;
                StartCoroutine("Repairing");
            }
        }
        else if (Input.anyKeyDown)
        {
            for (int i = 0; i <= seq; i++)
            {
                instantArrows[i].GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
            }
            seq = 0;
        }
    }

    IEnumerator Repairing()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(oPuzzle.gameObject);
        this.gameObject.GetComponent<PlayerMovement>().speed = 7;        
        seq = 0;
        //corsertar();
        fixing.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
        fixing.gameObject.tag = "Chip";
        fixing.GetComponent<ChipsBehaviours>().breaked = false;
        GameObject.FindWithTag("VirusStatic").GetComponent<VirusStaticBehaviours>().ReListar();
        fixing = null;
        for (int i = 0; i < 4; i++)
        {
            Destroy(instantArrows[i].gameObject);
        }
    }

    void TomarDano(int dmg)
    {
        vida = (vida - dmg < 0) ? 0 : vida - dmg;
    }
}
