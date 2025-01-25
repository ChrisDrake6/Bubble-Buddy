using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleBuddy
{
    public class Leash : MonoBehaviour
    {
        [SerializeField] public MonoBehaviour thatWhichHildsTheLeash;
        [SerializeField] public ILeashHoldable thatWhichHoldsMe;

        public Anchorknot MyAnchorknot { get; set; }

        private void Start()
        {
            //that's a bit sad, bur the ILeashHoldable isn't shown in the Inspector
            thatWhichHoldsMe = thatWhichHildsTheLeash as ILeashHoldable;
            MyAnchorknot = GetComponentInChildren<Anchorknot>();
        }
    }
}
