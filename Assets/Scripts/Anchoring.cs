using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchoring : MonoBehaviour, ILeashHoldable
{
    private Leashanchor leashanchor;

    // Start is called before the first frame update
    private void Start()
    {
        leashanchor = GetComponentInChildren<Leashanchor>();
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
