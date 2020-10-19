using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public UnityEvent ItemPicked = new UnityEvent();

    private void OnEnable()
    {
        ItemPicked.AddListener(FindObjectOfType<Score>().OnItemPicked);
    }
    private void PickItem()
    {
        ItemPicked.Invoke();
        Destroy(gameObject, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            PickItem();
        }
    }
}
