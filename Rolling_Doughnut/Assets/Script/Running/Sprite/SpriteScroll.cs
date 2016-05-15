using UnityEngine;
using System.Collections;

//=======================================
// SpriteScroll : 스프라이트 스크롤 처리
public class SpriteScroll : MonoBehaviour
{
    // 스크롤 속도
    public float MoveSpeed;
    // 리스폰 좌표
    public float[] RespawnXPos, RespawnYPos, RespawnZPos;
    // 리스폰 처리 좌표
    public float[] RespawnPoint;

    // Update is called once per frame
    void Update()
    {
        // 일시정지가 아니라면
        if (!GameManager.instance.bIsPause)
        {
            // 게임중이라면
            if (GameManager.instance.Game)
            {
                float X = this.transform.position.x;
                float Y = this.transform.position.y;
                float Z = this.transform.position.z;

                this.transform.position = new Vector3(X - MoveSpeed, Y, Z);

                if (this.transform.position.x < RespawnPoint[GameManager.instance.StageLevel])
                {
                    this.transform.position = new Vector3(RespawnXPos[GameManager.instance.StageLevel], RespawnYPos[GameManager.instance.StageLevel], RespawnZPos[GameManager.instance.StageLevel]);
                }
            }
        }
    }
}
