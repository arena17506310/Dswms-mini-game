﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

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

        // 기록 리스트 불러오기
        List<(string name, int score)> records = new List<(string, int)>();

        for (int i = 0; i < recordCount; i++)
        {
            string playerName = PlayerPrefs.GetString("PlayerName" + i, "Unknown");
            int score = PlayerPrefs.GetInt("Record_Score_" + i, 0);

            records.Add((playerName, score));
        }

        // 점수 순으로 내림차순 정렬
        var sortedRecords = records.OrderByDescending(r => r.score).ToList();

        // UI 출력
        for (int i = 0; i < sortedRecords.Count; i++)
        {
            GameObject entry = Instantiate(recordTextPrefab, recordParent);
            entry.GetComponent<TextMeshProUGUI>().text = $"{i + 1}. {sortedRecords[i].name} - {sortedRecords[i].score}";
        }
    }

    public void ClearRecords()
    {
        // 🔹 먼저 기록 개수 가져오기
        int recordCount = PlayerPrefs.GetInt("RecordCount", 0);

        // 🔹 모든 기록 삭제
        for (int i = 0; i < recordCount; i++)
        {
            PlayerPrefs.DeleteKey("PlayerName" + i);
            PlayerPrefs.DeleteKey("Record_Score_" + i);
        }

        // 🔹 RecordCount 도 삭제
        PlayerPrefs.DeleteKey("RecordCount");

        PlayerPrefs.Save();

        LoadRecords(); // UI 갱신
    }


}
