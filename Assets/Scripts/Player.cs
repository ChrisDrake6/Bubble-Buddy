using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleBuddy
{
    public enum Jumpstate
    {
        OnGround,
        WantJump,
        InJump,
    }

    public enum Movedirection
    {
        None = 0,
        Right = 1,
        Left = -1,
    }

    public class Player : MonoBehaviour
    {

        //Components
        private new Rigidbody2D rigidbody2D;

        private Collider2D overlapCircle;
        [SerializeField] private float groundcheckRadius = 0.05f;

        //movement
        [SerializeField] private Jumpstate jumpstate = Jumpstate.OnGround;
        [SerializeField] private Movedirection movedirection = Movedirection.None;
        [SerializeField] private float speed = 5;
        [SerializeField] private float jumpforce = 10;


        // Start is called before the first frame update
        void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            GetMovementInput();
        }

        private void FixedUpdate()
        {
            Groundcheck();
            Move();
        }

        /// <summary>
        /// movement incl. jump
        /// </summary>
        private void Move()
        {
            //rigidbody2D.AddForce((int)movedirection * lerpSpeedBackToPosition * Vector2.right, ForceMode2D.Force);
            rigidbody2D.velocity = new Vector2((int)movedirection * speed, rigidbody2D.velocity.y);
            if (jumpstate == Jumpstate.WantJump)
            {
                rigidbody2D.AddForce(jumpforce * Vector2.up, ForceMode2D.Impulse);
                jumpstate = Jumpstate.InJump;
            }
        }

        /// <summary>
        /// checks, if character is on Ground and sets Jumpstate
        /// </summary>
        private void Groundcheck()
        {
            overlapCircle = Physics2D.OverlapCircle(transform.position - new Vector3(0, transform.localScale.y, 0), groundcheckRadius, ~LayerMask.GetMask("Player"));
            if (overlapCircle && !(jumpstate == Jumpstate.WantJump))
            {
                jumpstate = Jumpstate.OnGround;
            }
        }

        /// <summary>
        /// gets Userinput for Movement incl. Jump
        /// </summary>
        private void GetMovementInput()
        {
            int direction = 0;
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                direction += 1;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                direction -= 1;
            }
            switch (direction)
            {
                case 1:
                    movedirection = Movedirection.Right;
                    break;
                case -1:
                    movedirection = Movedirection.Left;
                    break;
                case 0:
                    movedirection = Movedirection.None;
                    break;
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            {
                if (jumpstate == Jumpstate.OnGround)
                {
                    jumpstate = Jumpstate.WantJump;
                }
            }
        }
    }
}
