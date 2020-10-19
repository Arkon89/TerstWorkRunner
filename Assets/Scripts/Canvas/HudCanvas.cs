using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudCanvas : MonoBehaviour
{
    [SerializeField] private Text _scoreCount;

    public void UpdateScore(int score)
    {
        _scoreCount.text = score.ToString();
    }
}
