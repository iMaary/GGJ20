using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private int cont = 0;
    private int contMin;
    [SerializeField] private Text timer;
    
    void Start()
    {
        InvokeRepeating("Contador", 0f, 1f);
    }
    void Update()
    {
    
    }

    void DesabilitaGamePlay()
    {
        GameObject.FindGameObjectWithTag("DesabilitaGamePlay").gameObject.SetActive(false);
    }

    void Contador()
    {
        cont++;
        if(cont == 60)
        {
            cont = 0;
            contMin++;
        }
        timer.text = (cont < 10) ? contMin + ":0" + cont : contMin + ":" + cont;
    }
    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<Animator>().SetBool("pausa", true);
            Invoke("DesabilitaGamePlay", 1f);
        }
    }
}
