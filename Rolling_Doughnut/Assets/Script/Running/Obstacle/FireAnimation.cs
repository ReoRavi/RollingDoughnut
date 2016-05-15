using UnityEngine;
using System.Collections;

//=======================================
// FireAnimation : 전자레인지 불 애니메이션
public class FireAnimation : MonoBehaviour
{
    // 애니메이션 시간
    private float FireTime;
    // 활성화 여부
    private bool Active;
    // 오브젝트
    public GameObject Fire;

    // Use this for initialization
    void Start()
    {
        FireTime = 0;
        Active = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 게임중이라면
        if (GameManager.instance.Game)
        {
            // 불 애니메이션 처리
            FireTime += Time.deltaTime;

            if (FireTime > 0.5F)
            {

                switch (Active)
                {
                    case false:
                        Fire.gameObject.SetActive(true);
                        Active = true;
                        FireTime = 0;
                        break;

                    case true:
                        Fire.gameObject.SetActive(false);
                        Active = false;
                        FireTime = 0;
                        break;
                }
            }
        }
    }
}
