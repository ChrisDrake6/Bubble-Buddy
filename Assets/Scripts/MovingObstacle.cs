using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed;
    public float rayCastDistance;
    public LayerMask rayCastMask;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 origin = transform.position;
        if (spriteRenderer.flipY)
        {
            origin.x -= spriteRenderer.bounds.size.x / 2;
        }
        else
        {
            origin.x += spriteRenderer.bounds.size.x / 2;
        }
        RaycastHit2D hitDown = Physics2D.Raycast(origin, Vector2.down, rayCastDistance, rayCastMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(origin, transform.forward, rayCastDistance, rayCastMask);

        Debug.DrawRay(origin, Vector2.down);
        Debug.DrawRay(origin, transform.forward);

        if (!hitDown.collider || hitLeft.collider)
        {
            spriteRenderer.flipY = !spriteRenderer.flipY;
        }


        transform.Translate((spriteRenderer.flipY ? Vector2.left : Vector2.right) * speed * Time.deltaTime, Space.Self);
    }
}
