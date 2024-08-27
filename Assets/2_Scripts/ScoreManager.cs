using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI scoreTmp;
    [SerializeField] private TextMeshProUGUI bonusTmp;
    [SerializeField] private Score baseScore;

    private int totalScore;
    private float totalBonus;

    public void Init()
    {
        instance = this;
    }

    public void AddScore(int score, Vector2 scorePos)
    {
        Score scoreObject = Instantiate(baseScore);
        scoreObject.transform.position = scorePos;
        scoreObject.Active(score.ToString(), DataBaseManager.Instance.ScoreColor);

        totalScore += score;
        scoreTmp.text = totalScore.ToString();
    }

    internal void AddBonus(float bonus, Vector2 position)
    {
        Score scoreObject = Instantiate(baseScore);
        scoreObject.transform.position = position;
        string str = "Bonus " + bonus.ToPercentString();
        scoreObject.Active(str, DataBaseManager.Instance.ScoreColor);

        totalBonus += bonus;
        bonusTmp.text = totalBonus.ToPercentString();
    }

    internal void ResetBonus()
    {
        totalBonus = 0;
        bonusTmp.text = totalBonus.ToPercentString();
    }
}
