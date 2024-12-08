using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText.text = "0";
    }

    private void OnEnable()
    {
        EventBus.Instance.OnChanchedScore += OnChanchedScore;
    }
    
    private void OnDisable()
    {
        EventBus.Instance.OnChanchedScore -= OnChanchedScore;
    }
    
    private void OnChanchedScore()
    {
        scoreText.text = (Convert.ToInt32(scoreText.text) + 1).ToString();
    }
}
