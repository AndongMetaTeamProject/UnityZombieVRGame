using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public Text scoreText; // UI 요소(Text 또는 TextMeshPro 등)를 연결할 변수

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScoreUI();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        score++; // 숫자 증가
        UpdateScoreUI(); // UI 업데이트
    }

    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString(); // UI에 숫자를 문자열로 변환하여 업데이트
    }
}
