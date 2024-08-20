using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopScoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI topScoreText;


    void Start()
    {
        HandleTopScoreUI();
    }

    void HandleTopScoreUI()
    {
        int topScore = ScoreManager.Instance.LoadTopScore();
        if (topScore > 0)
        {
            topScoreText.gameObject.SetActive(true);
            topScoreText.text = $"Top Score: {topScore}";
        }
    }
}
