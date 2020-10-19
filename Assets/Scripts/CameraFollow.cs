using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _lookTarget;
    [SerializeField] private GameObject _positionTarget;
    [SerializeField] private float _speedMoving;

    private void LateUpdate()
    {
        transform.LookAt(_lookTarget.transform.position);
        transform.position = Vector3.Lerp(transform.position, _positionTarget.transform.position, _speedMoving * Time.deltaTime);
    }
}
