using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody))]
public class FrontMotor : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Rigidbody _body;

    private bool _letRun = true;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (CheckGround() && _letRun)
            // Move();
            RigidbodyMove();

    }
    private bool CheckGround()
    {
        Vector3 newPosition = transform.position;
        newPosition.z += _moveSpeed;

        if (Physics.Raycast(newPosition, Vector3.down, out RaycastHit hitInfo))
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

    private void Move()
    {
        Vector3 newPosition = transform.position;
        newPosition = Vector3.Lerp(transform.position, transform.position + transform.forward, _moveSpeed);
        transform.position = newPosition;
    }

    private void RigidbodyMove()
    {
        Debug.Log("RigidbodyMove()");
        _body.AddForce(transform.forward * _moveSpeed, ForceMode.VelocityChange);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<TurnTrigger>(out TurnTrigger turnTrigger))
        {
            _letRun = false;
            _body.AddForce(transform.forward * _moveSpeed / 20f, ForceMode.VelocityChange);
        }

        if (other.TryGetComponent<StrateEnterTrigger>(out StrateEnterTrigger strateEnterTrigger))
        {
            _letRun = true;
        }
    }




}
