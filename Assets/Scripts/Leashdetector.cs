using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leashdetector : MonoBehaviour
{
    //private Collider2D myTrigger;

    // Start is called before the first frame update
    void Start()
    {
        //myTrigger = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("TakeLeashDistance"))
        {
            Debug.Log("Laesh detected!");
        }
    }
}
