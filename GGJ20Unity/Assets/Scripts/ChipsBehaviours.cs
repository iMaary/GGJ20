using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipsBehaviours : MonoBehaviour
{
    private GameObject virus;
    public bool breaked;
    void Awake()
    {
        virus = GameObject.FindGameObjectWithTag("VirusStatic");
        breaked = false;
    }
    
    
}
