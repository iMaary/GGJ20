using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairManBehaviour : MonoBehaviour
{
    private string[] setas = new string[4] { "up", "right", "down", "left" };
    private int[] setasPuzzle = new int[4];
    [SerializeField]private GameObject[] instantArrows = new GameObject[4];
    private string seta;
    private GameObject oPuzzle;
    private GameObject fixing;

    public bool leftRep, rightRep, upRep, downRep;

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
        setDir();
    }

    void setDir()
    {
        //set diretions
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            leftRep = false;
            rightRep = false;
            upRep = true;
            downRep = false;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            leftRep = false;
            rightRep = false;
            upRep = false;  
            downRep = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            leftRep = false;
            rightRep = true;
            upRep = false;
            downRep = false;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftRep = true;
            rightRep = false;
            upRep = false;
            downRep = false;
        }
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
        else if (Input.GetKeyDown("right") || Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetKeyDown("left"))
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
        fixing.gameObject.tag = "Chip";
        fixing.GetComponent<ChipsBehaviours>().breaked = false;
        GameObject.FindWithTag("VirusStatic").GetComponent<VirusStaticBehaviours>().ReListar();
        fixing = null;
        for (int i = 0; i < 4; i++)
        {
            print(12);
            Destroy(instantArrows[i].gameObject);
        }
    }

    void TomarDano(int dmg)
    {
        vida = (vida - dmg < 0) ? 0 : vida - dmg;
    }
}
