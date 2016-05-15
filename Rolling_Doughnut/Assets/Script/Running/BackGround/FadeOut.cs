using UnityEngine;
using System.Collections;

//=======================================
// FadeOut : 스테이지가 바뀔 때 화면이 어두워졌다가 밝아지면서 바뀌는 처리를 한다.
public class FadeOut : MonoBehaviour
{
    // 투명도
    private float Transparency;
    // 흐른 시간
    private float TimeCount;
    // 방향
    private float Direction;
    // 투명도가 바뀌는 속도
    public float FadeOutSpeed;
    // 활성화 상태인지
    public bool bIsActive;
    // 레벨이 바뀌고있는지
    public bool bIsLevelChanged;
    // 좌표
    public float X, Y;

    // Use this for initialization
    void Start()
    {
        Transparency = 0.0F;
        TimeCount = 0.0F;
        Direction = 1;
        bIsActive = false;
        bIsLevelChanged = false;
        this.GetComponent<Renderer>().material.color = new Color(this.GetComponent<Renderer>().material.color.r, this.GetComponent<Renderer>().material.color.g, this.GetComponent<Renderer>().material.color.b, 0);
        this.transform.position = new Vector3(X, Y, -8);
    }

    // Update is called once per frame
    void Update()
    {
        // 게임이 진행중이라면
        if (GameManager.instance.Game)
        {
            // 활성화 상태라면
            if (bIsActive)
            {
                // 시간이 흐른만큼 
                TimeCount += Time.deltaTime;

                // 밝기를 조절할만한 시간이 흐름
                if (TimeCount >= 0.1F)
                {
                    Transparency += FadeOutSpeed * Direction;
                    TimeCount = 0;
                    this.GetComponent<Renderer>().material.color = new Color(this.GetComponent<Renderer>().material.color.r, this.GetComponent<Renderer>().material.color.g, this.GetComponent<Renderer>().material.color.b, Transparency);
                }

                // 완전히 투명해졌을 때
                if (Transparency < 0)
                {
                    Transparency = 0F;
                    Direction = 1;
                    bIsActive = false;
                }

                // 레벨이 바뀌고 있다면
                if (bIsLevelChanged)
                {
                    // 투명도가 1을 넘는다면
                    if (Transparency >= 1F)
                    {
                        Direction = -1;
                        GameManager.instance.BackGroundReset();
                        GameManager.instance.BackGroundAlter();
                        bIsLevelChanged = false;
                    }
                }
                else
                {
                    if (Transparency >= 0.5F)
                    {
                        Direction = -1;
                    }
                }
            }
        }
    }
}
