using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{

    LineRenderer lineRenderer;
    public Transform[] linePoints;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = linePoints.Length;
    }

    void Update()
    {
        for (int i = 0; i < linePoints.Length; i++)
        {
            lineRenderer.SetPosition(i, linePoints[i].position);
        }
    }
}
