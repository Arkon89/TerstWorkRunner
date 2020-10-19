using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody))]
public class FrontMotor : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _acceleration = 1f;
    private Rigidbody _body;
    private Animator _animator;

    private bool _letRun = true;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
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
        newPosition.z += _moveSpeed / 10f;

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

    // private void Move()
    // {
    //     Vector3 newPosition = transform.position;
    //     newPosition = Vector3.Lerp(transform.position, transform.position + transform.forward, _moveSpeed);
    //     transform.position = newPosition;

    // }

    private void RigidbodyMove()
    {
        Vector3 targetVelocity = _body.velocity;
        targetVelocity.z = _moveSpeed;
        _body.velocity = Vector3.Lerp(_body.velocity, targetVelocity, _acceleration);
        _animator.SetFloat("runSpeed", _body.velocity.z);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<TurnTrigger>(out TurnTrigger turnTrigger))
        {
            _letRun = false;
            // _body.AddForce(transform.forward * _moveSpeed / 20f, ForceMode.VelocityChange);
        }

        if (other.TryGetComponent<StrateEnterTrigger>(out StrateEnterTrigger strateEnterTrigger))
        {
            _letRun = true;
        }
    }




}
