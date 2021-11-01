using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    private Text ScoreText => GetComponent<Text>();
    private int TotalScore;
    private Vector3 DefaultPosition ;

    public int GetScore()
    {
        return TotalScore;
    }

    private void Start()
    {
        DefaultPosition = ScoreText.transform.parent.GetComponent<Text>().rectTransform.localPosition;
        UpdateScore();
    }

    public void AddScore(int value)
    {
        TotalScore += value;
        UpdateScore();
    }

    private void UpdateScore()
    {
        ScoreText.text = TotalScore.ToString();
    }

    public void ShowFinalResult()
    {
        ScoreText.transform.parent.GetComponent<Text>().rectTransform.localPosition = new Vector3(730f, 1080f/2 + 150f, 0f);
    }

    public void RefreshValue()
    {
        TotalScore = 0;
        ScoreText.transform.parent.GetComponent<Text>().rectTransform.localPosition = new Vector3(0f, 1080f, 0f);
    }
}
