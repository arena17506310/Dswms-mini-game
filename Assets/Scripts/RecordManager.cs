using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class RecordManager : MonoBehaviour
{
    public GameObject recordTextPrefab;
    public Transform recordParent;

    private void Start()
    {
        LoadRecords();
    }

    void LoadRecords()
    {
        foreach (Transform child in recordParent)
        {
            Destroy(child.gameObject);
        }

        int recordCount = PlayerPrefs.GetInt("RecordCount", 0);

        // ��� ����Ʈ �ҷ�����
        List<(string name, int score)> records = new List<(string, int)>();

        for (int i = 0; i < recordCount; i++)
        {
            string playerName = PlayerPrefs.GetString("PlayerName" + i, "Unknown");
            int score = PlayerPrefs.GetInt("Record_Score_" + i, 0);

            records.Add((playerName, score));
        }

        // ���� ������ �������� ����
        var sortedRecords = records.OrderByDescending(r => r.score).ToList();

        // UI ���
        for (int i = 0; i < sortedRecords.Count; i++)
        {
            GameObject entry = Instantiate(recordTextPrefab, recordParent);
            entry.GetComponent<TextMeshProUGUI>().text = $"{i + 1}. {sortedRecords[i].name} - {sortedRecords[i].score}";
        }
    }
}
