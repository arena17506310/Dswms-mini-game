using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    // ��ư���� ȣ���� �Լ�
    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu"); // ��ŸƮ �޴� �� �̸�
    }
}
