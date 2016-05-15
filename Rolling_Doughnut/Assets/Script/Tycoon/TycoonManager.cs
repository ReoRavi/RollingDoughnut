using UnityEngine;
using System.Collections;

//=======================================
// TycoonManager : 타이쿤 씬을 관리하는 매니저
public class TycoonManager : MonoBehaviour
{
    // 텐트 업그레이드 가격
    public int[] TentPrice;
    // 점원 업그레이드 가격
    public int[] ClerkPrice;
    // 텐트 업그레이드 스프라이트들
    public Sprite[] Tent_Sprite;
    // 텐트 이미지 객체
    public SpriteRenderer Tent;
    // 점원 업그레이드 스프라이트들
    public Sprite[] Clerk_Sprite;
    // 점원 이미지 객체
    public SpriteRenderer Clerk;
    // 벽 업그레이드 스프라이트들
    public Sprite[] Wall_Sprite;
    // 벽 이미지 객체
    public SpriteRenderer Wall;
    // UI 객체
    public GameObject UI;
    // 버튼 객체
    public GameObject[] Button;
    // 손님 객체
    public GameObject[] Customer;
    // 손님 생성 프리팹
    public GameObject[] Customer_Prefab;
    // 도넛 판매 스크립트
    public Doughnut_Sell[] DoughnutSell;
    // 업그레이드 카운트
    public int UprageCount;
    // 텐트 레벨
    int Tent_Level;
    // 점원 레벨
    int Clerk_Level;
    // 돈
    int Money;
    // 코인 UI
    public Coin_Display Display;

    // Use this for initialization
    void Start()
    {
        TentPrice = new int[3];
        ClerkPrice = new int[4];
        DoughnutSell = new Doughnut_Sell[3];
        Customer = new GameObject[3];

        for (int i = 0; i < TentPrice.Length; i++)
        {
            TentPrice[i] = 1000 + (i * 2000);
        }

        for (int i = 0; i < ClerkPrice.Length; i++)
        {
            ClerkPrice[i] = 1000 + (i * 2000);
        }

        Button[0].SetActive(false);
        Button[1].SetActive(false);
        UprageCount = 0;
        Instance = this;

        Tent_Level = PlayerPrefs.GetInt("TentLevel");
        Clerk_Level = PlayerPrefs.GetInt("ClerkLevel");

        if (Tent_Level < Tent_Sprite.Length)
        {
            Tent.sprite = Tent_Sprite[Tent_Level];
        }

        if (Clerk_Level < Clerk_Sprite.Length)
        {
            Clerk.sprite = Clerk_Sprite[Clerk_Level];
        }

        if (Tent_Level == 3)
        {
            Wall.sprite = Wall_Sprite[1];
        }
        else
        {
            Wall.sprite = Wall_Sprite[0];
        }

        for (int i = 0; i < CustomerCreate.bIsCustomerActive.Length; i++)
        {
            if (CustomerCreate.bIsCustomerActive[i])
            {
                int CreateNum = Random.Range(0, 4);

                Customer[i] = (GameObject)Instantiate(Customer_Prefab[CreateNum], new Vector3(-5.5F + (i * 5), -3.5F, -6), Quaternion.identity);
                DoughnutSell[i] = Customer[i].GetComponent<Doughnut_Sell>();
                DoughnutSell[i].CustomerNumber = i;
            }
        }

            UI.gameObject.SetActive(false);

    }

    // 루프
    void Update()
    {
        // 손님이 꽉 차지 않았다면
        if (!CustomerCreate.bIsCustomerActive[0] || !CustomerCreate.bIsCustomerActive[1] || !CustomerCreate.bIsCustomerActive[2])
        { 
            CustomerCreate.m_CustomerTime += Time.deltaTime;

            // 손님이 올 시간이 다 됬다면
            if (CustomerCreate.m_CustomerTime > 40)
            {
                CustomerCreate.m_CustomerTime -= 40;

                // 빈 공간을 찾아서 생성한다.
                for (int i = 0; i < 3; i++)
                {
                    if (!CustomerCreate.bIsCustomerActive[i])
                    {
                        int CreateNum = Random.Range(0, 4);

                        CustomerCreate.bIsCustomerActive[i] = true;
                        Customer[i] = (GameObject)Instantiate(Customer_Prefab[CreateNum], new Vector3(-5.5F + (i * 5), -3.5F, -4), Quaternion.identity);
                        DoughnutSell[i] = Customer[i].GetComponent<Doughnut_Sell>();
                        DoughnutSell[i].CustomerNumber = i;

                        break;
                    }
                }
            }
        }
    }

    // 업그레이드 요청
    public void LevelUpRequest()
    {
        // 업그레이드 카운트에 따라
        switch (UprageCount)
        {
            // 코인과 레벨을 받고, 업그레이드가 가능한지 체크한다.
            case 0:
                Tent_Level = PlayerPrefs.GetInt("TentLevel");
                 Money = PlayerPrefs.GetInt("Coin");

                if (TentPrice[Tent_Level] <= Money)
                {
                    Money -= TentPrice[Tent_Level];

                    PlayerPrefs.SetInt("Coin", Money);

                    Tent_Level++;

                    if (Tent_Level < Tent_Sprite.Length)
                    {
                        Tent.sprite = Tent_Sprite[Tent_Level];

                        if (Tent_Level == 3)
                        {
                            Wall.sprite = Wall_Sprite[1];
                        }

                        PlayerPrefs.SetInt("TentLevel", Tent_Level);

                        Display.CoinReset();
                        Display.CoinShow();
                    }
                }

                break;

            case 1:
                Clerk_Level = PlayerPrefs.GetInt("ClerkLevel");
                Money = PlayerPrefs.GetInt("Coin");

                if (ClerkPrice[Clerk_Level] <= Money)
                {
                    Money -= ClerkPrice[Clerk_Level];

                    PlayerPrefs.SetInt("Coin", Money);

                    Clerk_Level++;

                    if (Clerk_Level < Clerk_Sprite.Length)
                    {
                        Clerk.sprite = Clerk_Sprite[Clerk_Level];

                        PlayerPrefs.SetInt("ClerkLevel", Clerk_Level);

                        Display.CoinReset();
                        Display.CoinShow();
                    }
                }

                break;
        }


        UIHide();
    }

    // UI 숨김
    public void UIHide()
    {
        UI.SetActive(false);
        Button[0].SetActive(false);
        Button[1].SetActive(false);
    }

    //======================================================================================
    // 싱글톤
    private static TycoonManager Instance;

    public static TycoonManager instance
    {
        get
        {
            //if (Instance == null)
            //{
            //    Instance = new GameObject("TycoonManager").AddComponent<TycoonManager>();
            //}

            return Instance;
        }
    }
    //======================================================================================
}
