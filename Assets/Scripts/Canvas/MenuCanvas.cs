using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private Image gameOwerImage;
    void Start()
    {
        gameOwerImage.gameObject.SetActive(false);
        Barrier[] barriers = FindObjectsOfType<Barrier>();
        foreach (var barrier in barriers)
        {
            barrier.PlayerCatched.AddListener(ShowGameOwerUI);
        }
    }

    private void ShowGameOwerUI()
    {
        gameOwerImage.gameObject.SetActive(true);
    }


}
