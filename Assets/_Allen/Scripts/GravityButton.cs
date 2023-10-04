using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityButton : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rBody;
    [Space]
    [SerializeField] private GameObject Icon;

    public void Interact()
    {
        rBody.gravityScale *= -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Icon.SetActive(true);
            InteractScript.Instance.SetGravityButton(this);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Icon.SetActive(false);
            InteractScript.Instance.RemoveGravityButton();
        }
    }

}
