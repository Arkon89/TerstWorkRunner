using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideRotation : MonoBehaviour
{
    private bool _allowRotation;
    private float _angle;
    [SerializeField] private float _speedOfResetRotation = 1f;
    private Vector3 _centerOfRotation;
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<TurnTrigger>(out TurnTrigger turnTrigger))
        {
            _angle = turnTrigger.GetAngle();
            _allowRotation = true;
            _centerOfRotation = turnTrigger.GetCentrOfRotation();
        }

        if (other.TryGetComponent<StrateEnterTrigger>(out StrateEnterTrigger strateEnterTrigger))
        {
            _angle = 0;
            _allowRotation = false;
            Vector3 newDirection = Vector3.Lerp(transform.forward, strateEnterTrigger.transform.forward, _speedOfResetRotation);
            transform.forward = newDirection;
        }
    }

    private void Rotate()
    {
        // transform.Rotate(transform.up, _angle);
        transform.RotateAround(_centerOfRotation, transform.up, _angle);
        _angle = 0f;
        _allowRotation = false;
    }

    private void FixedUpdate()
    {
        if (_allowRotation)
        {
            if (CheckGround())
            {
                Rotate();
            }
            else
            {
                RotateBack();
            }
        }
    }

    private void RotateBack()
    {
        // transform.Rotate(transform.up, _angle);
        transform.RotateAround(_centerOfRotation, transform.up, -_angle);
        _angle = 0f;
        _allowRotation = false;
    }


    private bool CheckGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.gameObject.TryGetComponent<Road>(out Road road))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

}
