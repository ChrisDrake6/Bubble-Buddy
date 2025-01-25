using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BubbleBuddy
{
    public class Hand : MonoBehaviour, ILeashHoldable
    {
        [SerializeField] private Leashanchor leashanchor;

        /// <summary>
        /// it's the position, where the hand normally is, when it isn't doing something
        /// </summary>
        private DefaultHandPosition defaultPosition;
        private float tLerpTimeConstant;
        /// <summary>
        /// a vaue between 0 and 1
        /// </summary>
        [SerializeField] private float lerpSpeedBackToPosition = 0.05f;
        private bool alreadyLerping = false;

        private void Start()
        {
            //GetComponentInSiblings<DefaultHandPosition>;)
            defaultPosition = GetComponentInParent<Player>().GetComponentInChildren<DefaultHandPosition>();
            leashanchor = GetComponentInChildren<Leashanchor>();
        }

        private void FixedUpdate()
        {
            MoveBackToDefaultPosition();
        }

        /// <summary>
        /// moves the hand back to it's normal position, where it is, when it has'nt anything to do
        /// </summary>
        private void MoveBackToDefaultPosition()
        {
            if (transform.position != defaultPosition.transform.position && !alreadyLerping)
            {
                tLerpTimeConstant = 0;
                alreadyLerping = true;
            }
            else if (alreadyLerping)
            {
                transform.position = Vector3.Lerp(transform.position, defaultPosition.transform.position, tLerpTimeConstant += lerpSpeedBackToPosition);
                if (tLerpTimeConstant >= 1)
                {
                    alreadyLerping = false;
                }
            }
        }

        public Leashanchor getLeashanchor()
        {
            return leashanchor;
        }

        public void TurnOffLeashAnchor()
        {
            leashanchor.transform.localScale = Vector3.zero;
        }

        public void TurnOnLeashAnchor()
        {
            leashanchor.transform.localScale = Vector3.one;
        }
    }
}
