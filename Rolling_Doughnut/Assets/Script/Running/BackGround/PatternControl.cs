using UnityEngine;
using System.Collections;

//=======================================
// PatternControl : 패턴 생성과 삭제를 처리한다.
public class PatternControl : MonoBehaviour {

    // 패턴 움직이는 속도
    public float MoveSpeed;
    // 패턴 생성 좌표, 삭제 좌표
    public float MakePoint, ExitPoint;
    // 패턴이 만들어져야 할 상황일 때 패턴이 만들어졌는가
    private bool bIsMaked;

    void Start()
    {
        bIsMaked = false;
    }

    void Update()
    {
        // 일시정지가 아니고
        if (!GameManager.instance.bIsPause)
        {
            // 게임이 진행중이라면
            if (GameManager.instance.Game)
            {
                // 좌표
                float X = this.transform.position.x;
                float Y = this.transform.position.y;
                float Z = this.transform.position.z;

                this.transform.position = new Vector3(X - MoveSpeed, Y, Z);

                // 패턴을 새로 만들어야 하는 상황이고 만들어지지 않았다면
                if (X < MakePoint && !bIsMaked)
                {
                    GameManager.instance.PatternCount++;
                    GameManager.instance.MakePattern();
                    bIsMaked = true;
                }

                // 삭제 좌표를 넘어가면
                if (X < ExitPoint)
                {
                    // 삭제한다.
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
