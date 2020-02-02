using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public bool cabô;

    private void Update()
    {
        if (cabô)
        {
            Destroy(this.gameObject);
        }
    }
}
