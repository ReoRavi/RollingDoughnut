using UnityEngine;
using System.Collections;

//=======================================
// Doughnut_Jump : 도넛의 점프를 처리한다.
public class Doughnut_Jump : MonoBehaviour {

    // 발사 y좌표, 힘
    public  float y, yPower;
    // 점프 확인
    public bool bIsJump;
    // 더블 점프 확인
    public bool bIsDoubleJump;

	// Use this for initialization
	void Start () {
        y = this.transform.position.y;
        yPower = 0.25F;
        bIsJump = false;
        bIsDoubleJump = false;
	}

    // 점프 변수 초기화
    public void Init()
    {
        y = this.transform.position.y;
        yPower = 0.48F;
    }

	// Update is called once per frame
    void Update()
    {
        // 게임 중 이라면
        if (GameManager.instance.Game)
        {
            // 점프중이라면
            if (bIsJump)
            {
                // 더블 점프중이라면
                if (bIsDoubleJump)
                {
                    // 더블 점프 처리
                    yPower -= 0.0375F;
                    y += yPower;

                    transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
                }
                else
                {
                    // 점프 처리
                    yPower -= 0.03F;
                    y += yPower;

                    transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
                }
            }
        }
    }
}
