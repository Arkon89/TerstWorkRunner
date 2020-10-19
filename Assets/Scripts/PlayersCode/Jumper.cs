using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jumper : MonoBehaviour
{

    private Rigidbody _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
    }

    public void Jump(float jumpPower)
    {
        _body.AddForce(transform.up * jumpPower, ForceMode.Force);
        Debug.Log("JUMPING!!!!");
    }
}
