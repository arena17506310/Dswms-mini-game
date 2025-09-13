using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManagement : MonoBehaviour
{
    public Transform player;
    private float highestY = 0f;
    public float fallThreshold = -10f; // �ְ������� �󸶳� �������� ���� ����
    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        // �ְ� ���� ���
        if (player == null) return; // ������ġ

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
        if (isGameOver) return; // �ߺ� ����
        isGameOver = true;

        string playerName = PlayerPrefs.GetString("PlayerName", "Unknown");

        // ������ int�� ��ȯ�ؼ� ����
        SaveRecord(playerName, Mathf.RoundToInt(highestY));

        // �ְ� ������ PlayerPrefs�� ���� (GameOver ������ ���)
        PlayerPrefs.SetFloat("Score", highestY);

        // GameOver ������ ��ȯ
        SceneManager.LoadScene("GameOver");
    }
}
