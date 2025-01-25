using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleBuddy
{
    //isnt used anywere

    public class Bubblebehaviour : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private float lineLength;
        [SerializeField] private float lineforce;
        private new Rigidbody2D rigidbody2D;

        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Linestop();
        }

        private void Linestop()
        {
            if ((transform.position - player.transform.position).magnitude > lineLength)
            {
                //transform.position = lineLength * (-player.transform.position + transform.position).normalized;
                rigidbody2D.AddForce(lineforce * -transform.position + player.transform.position, ForceMode2D.Impulse);
            }
        }
    }
}
