using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prizrak : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speedMoving = 5f;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, _speedMoving);
    }

}
