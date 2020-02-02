using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusOffensiveBehaviour : MonoBehaviour
{
    public GameObject target;

    [SerializeField]
    private int speed = 5;
    private int dano = 1;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player 0");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player 0")
        {
            speed = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player 0")
        {
            speed = 5;
        }
    }
}
