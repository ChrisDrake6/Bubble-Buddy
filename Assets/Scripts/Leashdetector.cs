using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleBuddy
{
    public class Leashdetector : MonoBehaviour
    {
        private Hand hand;

        private void Start()
        {
            hand = GetComponentInParent<Hand>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("TakeLeashDistance"))
            {
                if (other.attachedRigidbody.gameObject.TryGetComponent<Leash>(out Leash myLeash))
                {
                    if (myLeash.thatWhichHoldsMe != null)
                    {
                        myLeash.thatWhichHoldsMe.TurnOffLeashAnchor();
                    }
                    hand.transform.position = myLeash.MyAnchorknot.transform.position;
                    hand.TurnOnLeashAnchor();
                }
            }
        }
    }
}
