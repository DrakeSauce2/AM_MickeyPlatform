using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullObject : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rBody;
    private Vector3 startPos = Vector3.zero;

    public void StartPull(Transform connectingTransform)
    {
        if (startPos == Vector3.zero)
        {
            startPos = connectingTransform.position;
        }

        float distance = Vector3.Distance(connectingTransform.position, startPos);

        if (distance > 0 || distance < 0)
        {
            rBody.freezeRotation = false;
        }
    }

}
