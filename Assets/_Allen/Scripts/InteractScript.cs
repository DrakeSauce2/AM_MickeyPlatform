using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public static InteractScript Instance;

    [SerializeField] private float grabRange;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LineRenderer lineRenderer;

    private GravityButton gravButton;

    Collider2D hit;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

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

        if (Input.GetKeyDown(KeyCode.E) && gravButton != null)
        {
            gravButton.Interact();
        }

    }

    public void SetGravityButton(GravityButton button)
    {
        gravButton = button;
    }

    public void RemoveGravityButton()
    {
        gravButton = null;
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
