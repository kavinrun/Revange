using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private int followSpeed = 5;
    [SerializeField]
    private Vector2 offset;
    [SerializeField]
    private GameObject target;

    private void Update()
    {
        Vector3 newPosition = target.transform.position + new Vector3(offset.x, offset.y, -10);
        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
