using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Barrier : MonoBehaviour
{
    public UnityEvent PlayerCatched = new UnityEvent();
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.gameObject.SetActive(false);
            PlayerCatched.Invoke();
        }
    }
}
