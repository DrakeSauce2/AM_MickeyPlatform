using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    [SerializeField] private float grabRange;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LineRenderer lineRenderer;

    private GameObject interactObject;

    bool grabbed = false;
    Collider2D hit;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            GrabObject();
        }
        else
        {
            lineRenderer.SetPosition(1, new Vector2(0, 0));
        }
    }

    private void GrabObject()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.OverlapCircle(transform.position, grabRange, layerMask);

        if (hit)
        {
            lineRenderer.SetPosition(1, hit.transform.position - transform.position);

            hit.GetComponent<PullObject>()?.StartPull(transform);
        }
        else
        {
            lineRenderer.SetPosition(1, new Vector2(0, 0));
        }
    }

}
