using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("플랫폼 프리팹")]
    public GameObject platformPrefab;
    public Sprite[] PlatformSprites;

    [Header("플랫폼 기본 설정")]
    public int initialPlatformCount = 5;   // 초기 플랫폼 개수
    public float levelWidth = 5f;          // 좌우 생성 범위
    public float minYGap = 2f;             // 플랫폼 최소 간격
    public float maxYGap = 4f;             // 플랫폼 최대 간격

    [Header("플랫폼 삭제 설정")]
    public float despawnDistance = -40f;   // 플레이어 기준으로 이 거리 밑에 있으면 삭제

    private float lastY = 0f;
    private float baseScaleX = 5f; // 처음 플랫폼 크기
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // 초기 플랫폼 생성
        for (int i = 0; i < initialPlatformCount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-levelWidth, levelWidth), lastY, 0f);
            SpawnPlatform(spawnPos);
            lastY += Random.Range(minYGap, maxYGap);
        }
    }

    void Update()
    {
        // 플레이어 기준 위로 계속 플랫폼 생성
        while (lastY < player.position.y + 10f)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-levelWidth, levelWidth), lastY, 0f);
            SpawnPlatform(spawnPos);
            lastY += Random.Range(minYGap, maxYGap);
        }

        // 플레이어 기준 아래에 있는 플랫폼 삭제
        foreach (GameObject platform in GameObject.FindGameObjectsWithTag("GeneratedPlatform"))
        {
            if (platform.transform.position.y < player.position.y + despawnDistance)
            {
                Destroy(platform);
            }
        }
    }

    void SpawnPlatform(Vector3 position)
    {
        GameObject platform = Instantiate(platformPrefab, position, Quaternion.identity);

        // 높이에 따라 플랫폼 크기 줄이기
        float shrinkSteps = Mathf.Floor(position.y / 200f); // 200 단위마다 감소
        float scaleX = Mathf.Max(baseScaleX - shrinkSteps, 1f); // 최소 크기 1
        platform.transform.localScale = new Vector3(scaleX, 1f, 1f);

        // 태그 지정
        platform.tag = "GeneratedPlatform";

        int spriteIndex = Mathf.Min((int)shrinkSteps, PlatformSprites.Length - 1);
        SpriteRenderer sr = platform.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = PlatformSprites[spriteIndex];
        }
    }
}
