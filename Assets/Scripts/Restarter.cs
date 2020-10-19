using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    private bool _gameOwer;
    void Start()
    {

        Barrier[] barriers = FindObjectsOfType<Barrier>();
        foreach (var barrier in barriers)
        {
            barrier.PlayerCatched.AddListener(GameOwer);
        }
    }

    public void GameOwer()
    {
        if (!_gameOwer)
        {
            StartCoroutine(RestartLevel());
            _gameOwer = true;
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
