using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        float score = PlayerPrefs.GetFloat("Score", 0);
        scoreText.text = "Game Over!\nScore: " + Mathf.RoundToInt(score);
    }
}
