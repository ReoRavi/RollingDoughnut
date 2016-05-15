using UnityEngine;
using System.Collections;

//=======================================
// Doughnut_Hit : 도넛 충돌 처리
public class Doughnut_Hit : MonoBehaviour {

    // 도넛 이미지 객체
    private Renderer Doughnut;
    // 투명도
    private float Transparency;
    // 투명도 값
    private float TransValue;
    // 투명도 카운트
    private int TransCount;
    // 충돌했는가.
    public bool bIsHit;
    // 카메라 객체
    public GameObject Camera;
    // 화면 흔들림 카운트
    public int VibrationCount;
    // 충돌 처리 후 흐른 시간
    public float m_Time;

	// Use this for initialization
	void Start () {
        Doughnut = GetComponent<Renderer>();
        Transparency = 1.0F;
        TransValue = -0.1F;
        TransCount = 0;
        bIsHit = false;
        VibrationCount = 0;
    }

    // 충돌 변수 초기화
    public void HitInit()
    {
        Transparency = 1.0F;
        TransValue = -0.05F;
        TransCount = 0;
    }

	// Update is called once per frame
	void Update () {
        // 게임중이라면
        if (GameManager.instance.Game)
        {
            // 충돌되었다면
            if (bIsHit)
            {
                m_Time += Time.deltaTime;

                // 화면 흔들림 처리를 한다.
                if (VibrationCount < 10)
                {
                    if (m_Time > 0.02f)
                    {
                        if (VibrationCount % 2 == 0)
                        {
                            VibrationCount++;
                            Camera.transform.position = new Vector3(Camera.transform.position.x + 0.3f, Camera.transform.position.y, Camera.transform.position.z);
                            m_Time = 0;
                        }
                        else
                        {
                            Camera.transform.position = new Vector3(Camera.transform.position.x - 0.3f, Camera.transform.position.y, Camera.transform.position.z);
                            m_Time = 0;
                            VibrationCount++;
                        }
                    }
                }

                // 투명도 처리
                Transparency += TransValue;

                if (Transparency <= 0)
                {
                    TransValue = 0.15F;
                }

                if (Transparency >= 1)
                {
                    TransCount++;
                    TransValue = -0.15F;
                   
                    if (TransCount >= 3)
                    {
                        VibrationCount = 0;
                        bIsHit = false;
                    }
                }

                Doughnut.material.color = new Color(Doughnut.material.color.r, Doughnut.material.color.g, Doughnut.material.color.b, Transparency);
            }
        }
	}
}
