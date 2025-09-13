using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManagement : MonoBehaviour
{
    public Transform player;
    private float highestY = 0f;
    public float fallThreshold = -10f; // 최고점에서 얼마나 떨어지면 게임 오버
    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        // 최고 높이 기록
        if (player == null) return; // 안전장치

        if (player.position.y > highestY)
            highestY = player.position.y;

        Debug.Log("PlayerY: " + player.position.y + " HighestY: " + highestY);

        if (player.position.y < highestY - 40f)
        {
            Debug.Log("GameOver Triggered");
            GameOver();
        }
    }
    void SaveRecord(string playerName, int score)
    {
        int recordCount = PlayerPrefs.GetInt("RecordCount", 0);

        PlayerPrefs.SetString("Record_Name_" + recordCount, playerName);
        PlayerPrefs.SetInt("Record_Score_" + recordCount, score);

        PlayerPrefs.SetInt("RecordCount", recordCount + 1);
        PlayerPrefs.Save();
    }


    void GameOver()
    {
        if (isGameOver) return; // 중복 방지
        isGameOver = true;

        string playerName = PlayerPrefs.GetString("PlayerName", "Unknown");

        // 점수를 int로 변환해서 저장
        SaveRecord(playerName, Mathf.RoundToInt(highestY));

        // 최고 점수를 PlayerPrefs에 저장 (GameOver 씬에서 사용)
        PlayerPrefs.SetFloat("Score", highestY);

        // GameOver 씬으로 전환
        SceneManager.LoadScene("GameOver");
    }
}
