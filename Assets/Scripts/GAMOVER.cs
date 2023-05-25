using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GAMOVER : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int scoreWeGot;

    private void Awake()
    {
        scoreText = this.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        scoreWeGot = EnemyHealth.score;
        scoreText.text = " " + scoreWeGot;
    }
}
