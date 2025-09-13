using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    // 버튼에서 호출할 함수
    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu"); // 스타트 메뉴 씬 이름
    }
}
