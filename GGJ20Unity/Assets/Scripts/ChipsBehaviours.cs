using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipsBehaviours : MonoBehaviour
{
    private GameObject virus;
    Animator anim;
    public bool breaked;
    void Awake()
    {
        virus = GameObject.FindGameObjectWithTag("VirusStatic");
        if (this.gameObject.name != "chipset infected_0")
            breaked = false;       

    }

    //Cauê q fez
    private void Update()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Corrompido", breaked);

        if(this.gameObject.name == "chipset infected_0")
        {
            anim.SetBool("Concluido", !breaked);
        }
    }
}
