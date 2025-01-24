using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubblebehaviour : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] float lineLength;

    private void Linestop()
    {
        if ((transform.position - player.transform.position).magnitude > lineLength)
        {

        }
    }
}
