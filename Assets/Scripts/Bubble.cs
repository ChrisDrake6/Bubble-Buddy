using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey;
    [SerializeField] private DistanceJoint2D distanceJoint;
    [SerializeField] private LineRenderer lineRenderer;

    public bool isGrabbed = true;
    bool isHoveredOver = false;

    void Update()
    {
        if (Input.GetKeyUp(interactionKey))
        {
            if (isGrabbed)
            {
                distanceJoint.enabled = false;
                lineRenderer.gameObject.SetActive(false);
                isGrabbed=false;
            }
            else if (isHoveredOver)
            {
                Grab();
            }
        }
    }

    public void Grab()
    {
        isGrabbed = true;
        distanceJoint.enabled = true;
        lineRenderer.gameObject.SetActive(true);
    }

    private void OnMouseEnter()
    {
        isHoveredOver = true;
    }

    private void OnMouseExit()
    {
        isHoveredOver = false;
    }
}
