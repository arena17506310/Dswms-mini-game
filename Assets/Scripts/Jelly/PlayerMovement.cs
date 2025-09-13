using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("이동 관련")]
    public float moveSpeed = 5f;



    [Header("점프 관련")]
    public float baseJumpForce = 20f;   // 시작 점프력
    public float jumpIncreaseStep = 2f; // 200 단위마다 증가량
    public float maxJumpForce = 50f;    // 최대 점프력
    private float jumpForce;


    [Header("중력 관련")]
    public float baseGravityScale = 2f;   // 시작 중력
    public float gravityIncreaseStep = 0.2f; // 200 단위마다 증가량
    public float maxGravityScale = 5f;   // 최대 중력

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = baseGravityScale;
        jumpForce = baseJumpForce;
    }

    private void Update()
    {
        // 좌우 이동
        float moveX = Input.GetAxis("Horizontal");
        Debug.Log(moveX);
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        // 높이에 따른 난이도 증가
        float heightStep = Mathf.Floor(transform.position.y / 200f);

        // 점프력 점진적 증가
        jumpForce = Mathf.Min(baseJumpForce + heightStep * jumpIncreaseStep, maxJumpForce);

        // 중력 점진적 증가
        rb.gravityScale = Mathf.Min(baseGravityScale + heightStep * gravityIncreaseStep, maxGravityScale);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("GeneratedPlatform"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // 위에서 밟았을 때만 점프
                if (contact.normal.y > 0.5f)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                }
            }
        }

    }
}
