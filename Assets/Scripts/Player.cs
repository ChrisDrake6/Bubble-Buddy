using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        /// <summary>
        /// a force that helps to don't fall over edges from platforms
        /// </summary>
        [SerializeField] private float dontFallForce;

        //movement
        [SerializeField] private Jumpstate jumpstate = Jumpstate.OnGround;
        [SerializeField] private Movedirection movedirection = Movedirection.None;
        [SerializeField] private float speed = 5;
        [SerializeField] private float jumpforce = 10;
        [SerializeField] private float edgeFindrange = 1;


        // Start is called before the first frame update
        private void Start()
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
        /// helps the Player to don't fall
        /// </summary>
        private void DontFallHelper()
        {
            MakeRaycasts(out Ray edgeDetector1, out Ray edgeDetector2);
        }

        /// <summary>
        /// makes raycasts
        /// </summary>
        /// <param name="ray1"></param>
        /// <param name="ray2"></param>
        private void MakeRaycasts(out Ray ray1, out Ray ray2)
        {
            ray1 = new Ray(transform.position + edgeFindrange * Vector3.left, Vector3.down);
            ray2 = new Ray(transform.position + edgeFindrange * Vector3.right, Vector3.down);

            RaycastHit hitData;


            Debug.DrawRay(ray1.origin, ray1.direction * 10);
            Debug.DrawRay(ray2.origin, ray2.direction * 10);
        }

        /// <summary>
        /// movement incl. jump
        /// </summary>
        private void Move()
        {
            //rigidbody2D.AddForce((int)movedirection * lerpSpeedBackToPosition * Vector2.right, ForceMode2D.Force);
            rigidbody2D.velocity = new Vector2((int)movedirection * speed, rigidbody2D.velocity.y);
            if (movedirection != Movedirection.None)
            {
                transform.localScale = new Vector3((int)movedirection * 1, transform.localScale.y, transform.localScale.z);
            }
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
