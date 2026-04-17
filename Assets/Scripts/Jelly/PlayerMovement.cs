using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("�̵� ����")]
    public float moveSpeed = 10f;



    [Header("���� ����")]
    public float baseJumpForce = 20f;   // ���� ������
    public float jumpIncreaseStep = 10f; // 200 �������� ������
    public float maxJumpForce = 60f;    // �ִ� ������
    private float jumpForce;


    [Header("�߷� ����")]
    public float baseGravityScale = 2f;   // ���� �߷�
    public float gravityIncreaseStep = 0.2f; // 200 �������� ������
    public float maxGravityScale = 5f;   // �ִ� �߷�

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = baseGravityScale;
        jumpForce = baseJumpForce;
    }

    private void Update()
    {
        // �¿� �̵�
        float moveX = Input.GetAxis("Horizontal");
        Debug.Log(moveX);
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        // ���̿� ���� ���̵� ����
        float heightStep = Mathf.Floor(transform.position.y / 200f);

        // ������ ������ ����
        jumpForce = Mathf.Min(baseJumpForce + heightStep * jumpIncreaseStep, maxJumpForce);

        // �߷� ������ ����
        rb.gravityScale = Mathf.Min(baseGravityScale + heightStep * gravityIncreaseStep, maxGravityScale);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("GeneratedPlatform"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // ������ ����� ���� ����
                if (contact.normal.y > 0.5f)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                }
            }
        }

    }
}

//hello

