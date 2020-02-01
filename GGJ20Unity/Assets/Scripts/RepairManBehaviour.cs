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

    [SerializeField]
    private GameObject telaPuzzle;
    private bool onPuzzle = false;
    private int seq;
    public GameObject[] arrowsSr;

    void Start()
    {
         
    }

    void Update()
    {
        if (onPuzzle)
            Puzzle();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Corrompido")
        {
            oPuzzle = Instantiate(telaPuzzle, transform.position, Quaternion.identity);
            this.gameObject.GetComponent<PlayerMovement>().speed = 0;
            for(int i = 0; i < 4; i++)
            {
                setasPuzzle[i] = Random.Range(0,4);
                instantArrows[i] = Instantiate(arrowsSr[setasPuzzle[i]], transform.position - new Vector3(2 - i, 0), Quaternion.identity);
                print(setas[setasPuzzle[i]]);
            }
            onPuzzle = true;
        }
    }
    void Puzzle()
    {
        if (Input.GetKeyDown(setas[setasPuzzle[seq]]))
        {
            //instantArrows[seq].GetComponent<Color>().a = 0.5f;
            seq++;
            if(seq == 4)
            {
                Destroy(oPuzzle.gameObject);
                this.gameObject.GetComponent<PlayerMovement>().speed = 7;
                onPuzzle = false;
                seq = 0;
                for(int i = 0; i < 4; i++)
                {
                    Destroy(instantArrows[i].gameObject);
                }
            }
        }
        else if (Input.anyKeyDown)
        {
            print(1);
            seq = 0;
        }
    }
}
