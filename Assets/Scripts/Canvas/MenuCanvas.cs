using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private Image _gameOwerImage;
    [SerializeField] private Image _finishImage;
    void Start()
    {
        _gameOwerImage.gameObject.SetActive(false);
        _finishImage.gameObject.SetActive(false);
        Barrier[] barriers = FindObjectsOfType<Barrier>();
        foreach (var barrier in barriers)
        {
            barrier.PlayerCatched.AddListener(ShowGameOwerUI);
        }

        FinishTrigger finish = FindObjectOfType<FinishTrigger>();
        finish.Finish.AddListener(ShowFinishUI);
    }

    private void ShowGameOwerUI()
    {
        _gameOwerImage.gameObject.SetActive(true);
    }

    private void ShowFinishUI()
    {
        _finishImage.gameObject.SetActive(true);
    }


}
