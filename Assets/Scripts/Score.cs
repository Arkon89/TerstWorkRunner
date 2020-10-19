using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private IntVolume _levelScoreFile;
    private int _score;
    private HudCanvas _hudCanvas;

    private void OnEnable()
    {
        _hudCanvas = FindObjectOfType<HudCanvas>();
    }
    public void OnItemPicked()
    {
        _score++;
        _hudCanvas.UpdateScore(_score);
        Debug.Log($"Score: {_score}");
    }
}
