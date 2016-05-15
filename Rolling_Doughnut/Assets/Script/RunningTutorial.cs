using UnityEngine;
using System.Collections;

//=======================================
// RunningTutorial : 러닝게임 튜토리얼 처리
public class RunningTutorial : MonoBehaviour
{
    // 이미지 객체
    public SpriteRenderer Image;
    // 튜토리얼 이미지들
    public Sprite[] TutorialImage;
    // 이미지 카운트
    public int ImageCount;
    // 도넛 오브젝트들
    public GameObject[] Doughnut;
    // 장애물 포크 오브젝트
    public GameObject[] Fork;
    // 토핑 오브젝트들
    public GameObject[] ToppingObj;
    // 토핑 도넛들
    public GameObject ToppingDoughnut;
    // 구르는 도넛 오브젝트
    public GameObject RollingObj;
    // 토핑 설명 오브젝트
    public GameObject ToppingExplain;
    // 손가락
    public GameObject Finger;
    // 버튼
    public GameObject Button;
    // 도넛 애니메이션
    public Animator DoughnutAnimation;
    // 토핑 애니메이션들
    public Animator[] ToppingAnimation;

    // Use this for initialization
    void Start()
    {
        Image = GetComponent<SpriteRenderer>();
        Doughnut[0].SetActive(false);
        Doughnut[1].SetActive(false);
        ToppingDoughnut.SetActive(false);
        ToppingExplain.SetActive(false);
        RollingObj.SetActive(false);
        Finger.SetActive(false);
        Button.SetActive(false);
        ToppingObj[0].SetActive(false);
        ToppingObj[1].SetActive(false);
        ToppingObj[2].SetActive(false);
        ToppingObj[3].SetActive(false);
    }

    // 클릭시
    void OnMouseDown()
    { 
        // 클릭 할 때 마다 튜토리얼 이미지를 바꾼다.
        ImageCount++;

        // 튜토리얼을 다 봤을 때
        if (ImageCount >= 6)
        {
            Application.LoadLevel("RunningReady");
        }

        if (ImageCount <= 5)
        {
            Image.sprite = TutorialImage[ImageCount];
        }

        // 카운트에 따라 이미지 처리
        switch (ImageCount)
        {
            case 0:
                Fork[0].SetActive(true);
                Fork[1].SetActive(true);

                break;

            case 1:
                Destroy(Fork[0]);
                Destroy(Fork[1]);
                Doughnut[0].SetActive(true);
                Doughnut[1].SetActive(true);

                break;

            case 2:
                Destroy(Doughnut[0]);
                Destroy(Doughnut[1]);
                RollingObj.SetActive(true);


                break;

            case 3:
                Destroy(RollingObj);
                ToppingExplain.SetActive(true);

                break;

            case 4:

                Destroy(ToppingExplain);
                        Finger.SetActive(true);
        Button.SetActive(true);
                ToppingDoughnut.SetActive(true);
                ToppingObj[0].SetActive(true);
                ToppingObj[1].SetActive(true);
                ToppingObj[2].SetActive(true);
                ToppingObj[3].SetActive(true);



                ToppingAnimation[0].SetBool("bIsTopping", true);
                ToppingAnimation[1].SetBool("bIsTopping", true);
                ToppingAnimation[2].SetBool("bIsTopping", true);
                ToppingAnimation[3].SetBool("bIsTopping", true);
                DoughnutAnimation.SetBool("bIsTopping", true);
                break;


            case 5:

                Destroy(Finger);
                Destroy(Button);
                Destroy(ToppingObj[0]);
                Destroy(ToppingObj[1]);
                Destroy(ToppingObj[2]);
                Destroy(ToppingObj[3]);
                Destroy(ToppingDoughnut);

                break;
        }
    }
}
