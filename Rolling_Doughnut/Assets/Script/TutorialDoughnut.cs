using UnityEngine;
using System.Collections;

//=======================================
// TutorialDoughnut : 튜토리얼 도넛
public class TutorialDoughnut : MonoBehaviour
{
    // 도넛 애니메이션
    public Animator Doughnut_Animation;
    // 더블점프를 했는가
    public bool bIsDoubleJumped;
    // 더블점프중인가
    public bool bIsDoubleJump;
    // 점프 좌표, 힘
    public float y, yPower;
    // 흐른 시간
    public float m_Time;

    // Use this for initialization
    void Start()
    {
        Doughnut_Animation = GetComponent<Animator>();
        Init();
        m_Time = 0;
    }

    // 초기화
    void Init()
    {
        y = this.transform.position.y;
        yPower = 0.48F;
    }

    // Update is called once per frame
    void Update()
    {
        // 시간이 흐름
        m_Time += Time.deltaTime;

        // 더블점프중인가
        if (bIsDoubleJump)
        {
            yPower -= 0.045F;
            y += yPower;

            transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
        }
        else
        {
            // 점프중 처리
            yPower -= 0.03F;
            y += yPower;

            transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
        }
        
        // 더블점프를 충분히 보여주었다. 다시 초기화한다.
        if (bIsDoubleJumped && !bIsDoubleJump)
        {
            if (this.transform.position.y > -0.75F)
            {
                bIsDoubleJump = true;
                Init();
            }
        }
    }

    // 충돌 처리
    void OnCollisionEnter2D(Collision2D Col)
    {
        // 땅과 충돌 처리
        if (Col.gameObject.tag == "Ground")
        {
            // 초기화
            Init();
            bIsDoubleJump = false;
        }
    }
}
