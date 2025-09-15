using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManagement : MonoBehaviour
{
    public Transform player;
    private float highestY = 0f;
    public float fallThreshold = -10f;
    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;
        if (player == null) return;

        if (player.position.y > highestY)
            highestY = player.position.y;

        if (player.position.y < highestY - 40f)
            GameOver();
    }

    void SaveRecord(string playerName, int score)
    {
        int recordCount = PlayerPrefs.GetInt("RecordCount", 0);

        PlayerPrefs.SetString("PlayerName" + recordCount, playerName);
        PlayerPrefs.SetInt("Record_Score_" + recordCount, score);

        PlayerPrefs.SetInt("RecordCount", recordCount + 1);
        PlayerPrefs.Save();
    }

    void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        string playerName = PlayerPrefs.GetString("PlayerName", "Unknown");
        SaveRecord(playerName, Mathf.RoundToInt(highestY));

        // 최고 점수 저장 (옵션)
        PlayerPrefs.SetFloat("Score", highestY);

        SceneManager.LoadScene("GameOver");
    }
}
