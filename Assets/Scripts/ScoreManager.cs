using UnityEngine;
using TMPro;   // TextMeshPro 쓰려면 꼭 필요!

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;   // 여기 바뀜

    private float highestY;

    void Update()
    {
        if (player == null || scoreText == null) return;

        if (player.position.y > highestY)
        {
            highestY = player.position.y;
        }

        int score = Mathf.RoundToInt(highestY);
        scoreText.text = "Score: " + score.ToString();
    }
}
