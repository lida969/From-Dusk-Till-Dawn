using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver_Score : MonoBehaviour
{
    private TextMesh scoreTXT;
    private int score;
    void Start()
    {
        scoreTXT=GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        score = EnemyHealth.score;
        scoreTXT.text = " " + score;
    }
}
