using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jumper : MonoBehaviour
{

    private Rigidbody _body;
    private Animator _animator;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Jump(float jumpPower)
    {
        _animator.SetTrigger("Jump");
        _body.AddForce(transform.up * jumpPower, ForceMode.Force);
        Debug.Log("JUMPING!!!!");
    }
}
