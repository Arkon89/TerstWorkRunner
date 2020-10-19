using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishTrigger : MonoBehaviour
{
    public UnityEvent Finish = new UnityEvent();
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            //Time.timeScale = 0f;
            Finish.Invoke();
        }
    }
}
