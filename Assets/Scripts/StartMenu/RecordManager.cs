using UnityEngine;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour
{
    public GameObject recordTextPrefab; // �� �� ǥ�ÿ� Text ������
    public Transform recordParent;      // Vertical Layout Group�� ���� Panel

    private void Start()
    {
        LoadRecords();
    }

    void LoadRecords()
    {
        // ������ �����ִ� UI ���� (���� �ٽ� ������ �� �ߺ� ����)
        foreach (Transform child in recordParent)
        {
            Destroy(child.gameObject);

        // ����� ��� ���� �ҷ�����
        }
        int recordCount = PlayerPrefs.GetInt("RecordCount", 0);

        for (int i = 0; i < recordCount; i++)
        {
            string playerName = PlayerPrefs.GetString("Record_Name_" + i, "Unknown");
            int score = PlayerPrefs.GetInt("Score" + i, 0);

            // UI�� ǥ��
            GameObject entry = Instantiate(recordTextPrefab, recordParent);
            entry.GetComponent<Text>().text = $"{i + 1}. {playerName} - {score}";
        }
    }
}
