using UnityEngine;
using UnityEngine.UI;

public class ScoreV1 : MonoBehaviour
{
    public static ScoreV1 instance;

    public int score = 0;
    public Text scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString();
    }
}