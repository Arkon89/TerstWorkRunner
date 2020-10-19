using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    [SerializeField] private float _impulsePower;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.GetComponent<Rigidbody>().AddForce(player.transform.forward * _impulsePower, ForceMode.Impulse);
        }
    }
}
