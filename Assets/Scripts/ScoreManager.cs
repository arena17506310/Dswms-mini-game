using UnityEngine;
using TMPro;   // TextMeshPro ������ �� �ʿ�!

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;   // ���� �ٲ�

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
