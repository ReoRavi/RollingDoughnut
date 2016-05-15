using UnityEngine;
using System.Collections;

// 도넛의 상태들
public enum DoughnutState { Run, Jump, DoubleJump };

//=======================================
// Doughnut_Control : 도넛을 컨트롤한다.
public class Doughnut_Control : MonoBehaviour
{
    // 도넛의 상태들
    public DoughnutState m_State;
    // 점프중인가
    private Doughnut_Jump m_Jump;
    // 도넛의 애니메이션
    private Animator Doughnut_Animation;
    // 도넛의 토핑 상태
    private Doughnut_Trigger m_Doughnut_ToppingState;

    // Use this for initialization
    void Start()
    {
        m_Jump = GetComponent<Doughnut_Jump>();
        m_State = DoughnutState.Run;
        Doughnut_Animation = GetComponent<Animator>();
        m_Doughnut_ToppingState = GetComponent<Doughnut_Trigger>();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 일시정지가 아니고
        if (!GameManager.instance.bIsPause)
        {
            // 게임중이라면
            if (!GameManager.instance.Game)
            {
                // 점수를 더한다.
                GameManager.instance.QualityScore = this.GetComponent<Doughnut_Quality>().QuailtyScore;
            }

            // 게임중이라면
            if (GameManager.instance.Game)
            {
                // 터치 처리
                if (Input.touchCount > 0)
                {
                    // 터치가 됬다면
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        // Run 상태라면
                        if (m_State == DoughnutState.Run)
                        {
                            // 점프한다.
                            if (!m_Jump.bIsJump)
                            {
                                Doughnut_Animation.SetBool("bIsJump", true);
                                m_State = DoughnutState.Jump;
                                m_Jump.Init();
                                m_Jump.bIsJump = true;
                            }
                        }
                        // 점프 상태라면
                        else if (m_State == DoughnutState.Jump)
                        {
                            // 더블 점프를 한다.
                            if (!m_Jump.bIsDoubleJump)
                            {
                                Doughnut_Animation.SetBool("bIsJump", true);
                                m_State = DoughnutState.DoubleJump;
                                m_Jump.Init();
                                m_Jump.bIsDoubleJump = true;
                            }
                        }
                    }
                }

                this.transform.position = new Vector3(-5, this.transform.position.y, -7);

                // 스페이스바 처리 (PC 디버깅용)
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (m_State == DoughnutState.Run)
                    {
                        if (!m_Jump.bIsJump)
                        {
                            Doughnut_Animation.SetBool("bIsJump", true);
                            m_State = DoughnutState.Jump;
                            m_Jump.Init();
                            m_Jump.bIsJump = true;
                        }
                    }
                    else if (m_State == DoughnutState.Jump)
                    {
                        if (!m_Jump.bIsDoubleJump)
                        {
                            Doughnut_Animation.SetBool("bIsJump", true);
                            m_State = DoughnutState.DoubleJump;
                            m_Jump.Init();
                            m_Jump.bIsDoubleJump = true;
                        }
                    }
                }

                // 토핑 상태에 따라 애니메이션 처리
                switch (GameManager.instance.ToppingType)
                {
                    case 0:
                        Doughnut_Animation.SetInteger("Topping_State", 0);
                        break;

                    case 1:
                        Doughnut_Animation.SetInteger("Topping_State", 1);
                        break;

                    case 2:
                        Doughnut_Animation.SetInteger("Topping_State", 2);
                        break;

                    case 3:
                        Doughnut_Animation.SetInteger("Topping_State", 3);
                        break;
                }

                // 토핑에 따라 이미지 처리
                switch (m_Doughnut_ToppingState.ToppingState)
                {
                    case Doughnut_ToppingState.Banila:
                        Doughnut_Animation.SetInteger("Doughnut_State", 0);
                        break;

                    case Doughnut_ToppingState.Choco:
                        Doughnut_Animation.SetInteger("Doughnut_State", 1);
                        break;

                    case Doughnut_ToppingState.Coke:
                        Doughnut_Animation.SetInteger("Doughnut_State", 2);
                        break;

                    case Doughnut_ToppingState.Jam:
                        Doughnut_Animation.SetInteger("Doughnut_State", 3);
                        break;

                    case Doughnut_ToppingState.Mint:
                        Doughnut_Animation.SetInteger("Doughnut_State", 4);
                        break;

                    case Doughnut_ToppingState.Poision:
                        Doughnut_Animation.SetInteger("Doughnut_State", 6);
                        break;

                    case Doughnut_ToppingState.StrawBerry:
                        Doughnut_Animation.SetInteger("Doughnut_State", 7);
                        break;

                    case Doughnut_ToppingState.Wasabi:
                        Doughnut_Animation.SetInteger("Doughnut_State", 8);
                        break;
                }
            }
        }
    }

    // 땅과 충돌 시의 처리
    void OnCollisionEnter2D(Collision2D Col)
    {
        // 점프중이라면 다시 Run 상태로 돌린다.
        if (Col.gameObject.tag == "Ground")
        {
            Doughnut_Animation.SetBool("bIsJump", false);
            m_State = DoughnutState.Run;
            m_Jump.bIsJump = false;
            m_Jump.bIsDoubleJump = false;
            m_Jump.Init();
        }
    }
}
