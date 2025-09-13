using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public InputField playerNameInput; // �̸� �Է¿� InputField
    private string playerName = "";

    // ���� ���� ��ư
    public void StartGame()
    {
        if (playerNameInput != null)
        {
            playerName = playerNameInput.text;
            PlayerPrefs.SetString("PlayerName", playerName);
        }
        SceneManager.LoadScene("SampleScene"); // ���� ���� �� �̸�
    }

    // ���� ��� ��ư
    public void ShowRecords()
    {
        SceneManager.LoadScene("RecordScene"); // ��� ��
    }

    // ������ ��� ��ư
    public void ShowDevelopers()
    {
        SceneManager.LoadScene("DeveloperScene"); // ������ ��
    }
}
