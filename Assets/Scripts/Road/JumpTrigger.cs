using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    [SerializeField] private float _jumpPower = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.GetComponent<Jumper>().Jump(_jumpPower);
        }
    }
}
