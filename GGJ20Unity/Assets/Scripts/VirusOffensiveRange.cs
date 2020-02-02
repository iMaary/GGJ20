using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusOffensiveRange : MonoBehaviour
{
    private GameObject vo, rm;
    // Start is called before the first frame update
    void Start()
    {
        vo = GameObject.FindWithTag("VirusOffensive");
        rm = GameObject.FindWithTag("Player 0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player 1")
        {
            vo.GetComponent<VirusOffensiveBehaviour>().target = col.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player 1")
        {
            vo.GetComponent<VirusOffensiveBehaviour>().target = rm;
        }
    }
}
