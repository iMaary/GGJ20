using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<Animator>().SetBool("pausa", true);
            Invoke("DesabilitaGamePlay", 1f);
        }       
    }
    void DesabilitaGamePlay()
    {
        GameObject.FindGameObjectWithTag("DesabilitaGamePlay").gameObject.SetActive(false);
    }
}
