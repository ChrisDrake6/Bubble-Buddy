using UnityEngine;

public class CheckpointUser : MonoBehaviour
{
    Vector2 lastCheckpoint;

    public KeyCode resetKey;
    public float offsetBubbleToPlayer;
    public GameObject bubble;
    public LineRenderer lineRenderer;
    public DistanceJoint2D distanceJoint;
    

    // Start is called before the first frame update
    void Start()
    {
        lastCheckpoint = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyUp(resetKey))
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = lastCheckpoint;
        bubble.transform.position = new Vector2(transform.position.x, transform.position.y + offsetBubbleToPlayer);
        distanceJoint.GetComponent<Bubble>().Grab();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Checkpoint"))
        {
            lastCheckpoint = collision.transform.position;
        }
    }
}
