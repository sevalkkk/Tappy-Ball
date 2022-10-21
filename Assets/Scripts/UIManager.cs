using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        scoreText.text = ScoreManager.instance.score.ToString();
    }
}
