using UnityEngine;
using System.Collections;

//=======================================
// VelbAnimation : 전자레인지 벨브 애니메이션
public class VelbAnimation : MonoBehaviour
{
    // 애니메이션 시간
    private float VelbTime;
    // 활성화 여부
    private bool Active;
    // 벨브 오브젝트
    public GameObject Velb;

    // Use this for initialization
    void Start()
    {
        VelbTime = 0;
        Active = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 게임중이라면
        if (GameManager.instance.Game)
        {
            // 애니메이션 처리
            VelbTime += Time.deltaTime;

            if (VelbTime > 0.5F)
            {
                switch (Active)
                {
                    case true:
                        Velb.gameObject.transform.Rotate(0, 0, 30);
                        Active = false;
                        VelbTime = 0;
                        break;
                    case false:
                        Velb.gameObject.transform.Rotate(0, 0, 330);
                        Active = true;
                        VelbTime = 0;
                        break;
                }
            }
        }
    }
}
