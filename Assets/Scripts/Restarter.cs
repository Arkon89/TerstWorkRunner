using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    private bool _gameOwer, _finish;
    void Start()
    {

        Barrier[] barriers = FindObjectsOfType<Barrier>();
        foreach (var barrier in barriers)
        {
            barrier.PlayerCatched.AddListener(GameOwer);
        }

        FinishTrigger finish = FindObjectOfType<FinishTrigger>();
        finish.Finish.AddListener(Finish);
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
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Finish()
    {
        if (!_finish)
        {
            StartCoroutine(RestartLevel());
            _finish = true;
        }
    }

}
