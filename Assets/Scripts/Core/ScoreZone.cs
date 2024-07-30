using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{

    private void OnEnable()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.AddScore(1);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
