using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public InputField playerNameInput; // 이름 입력용 InputField
    private string playerName = "";

    // 게임 시작 버튼
    public void StartGame()
    {
        if (playerNameInput != null)
        {
            playerName = playerNameInput.text;
            PlayerPrefs.SetString("PlayerName", playerName);
        }
        SceneManager.LoadScene("SampleScene"); // 실제 게임 씬 이름
    }

    // 게임 기록 버튼
    public void ShowRecords()
    {
        SceneManager.LoadScene("RecordScene"); // 기록 씬
    }

    // 개발자 명단 버튼
    public void ShowDevelopers()
    {
        SceneManager.LoadScene("DeveloperScene"); // 개발자 씬
    }
}
