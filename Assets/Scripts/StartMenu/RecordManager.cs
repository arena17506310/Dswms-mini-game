using UnityEngine;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour
{
    public GameObject recordTextPrefab; // 한 줄 표시용 Text 프리팹
    public Transform recordParent;      // Vertical Layout Group이 붙은 Panel

    private void Start()
    {
        LoadRecords();
    }

    void LoadRecords()
    {
        // 기존에 남아있는 UI 제거 (씬을 다시 들어왔을 때 중복 방지)
        foreach (Transform child in recordParent)
        {
            Destroy(child.gameObject);

        // 저장된 기록 개수 불러오기
        }
        int recordCount = PlayerPrefs.GetInt("RecordCount", 0);

        for (int i = 0; i < recordCount; i++)
        {
            string playerName = PlayerPrefs.GetString("Record_Name_" + i, "Unknown");
            int score = PlayerPrefs.GetInt("Score" + i, 0);

            // UI에 표시
            GameObject entry = Instantiate(recordTextPrefab, recordParent);
            entry.GetComponent<Text>().text = $"{i + 1}. {playerName} - {score}";
        }
    }
}
