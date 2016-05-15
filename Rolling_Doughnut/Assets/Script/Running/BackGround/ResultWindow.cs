using UnityEngine;
using System.Collections;

//=======================================
// ResultWindow : 결과창 UI 및 값 처리
public class ResultWindow : MonoBehaviour
{
    // 도넛의 이미지들
    public Sprite[] Doughnut;
    // 도넛의 토핑 상태
    public Animator Doughnut_State;
    // 도넛의 이미지 객체
    public SpriteRenderer Doughnut_Sprite;
    // 도넛 오브젝트
    public GameObject DouthnutObj;
    // 돈 오브젝트
    public GameObject Coin_Object;
    // 점수 오브젝트
    public GameObject Score_Object;
    // 품질 오브젝트
    public GameObject Quality_Object;
    // 도넛 오브젝트
    public GameObject Doughnut_Object;
    // % 기호
    public GameObject Persent;
    // = 기호
    public GameObject Equal;
    // 소리
    public GameObject Sound;
    // 배경 음악
    public AudioSource MainSound;
    // 흐른 시간
    public float m_Time;
    // 도넛의 타입
    public int DoughnutType;
    // 활성화 상태인가
    private bool bIsShow;
    // 씬 바꾸기가 가능한가.
    private bool SceneChangePossible;
    // 결과창 애니메이션의 종료 유무
    private bool[] bIsResultWindowAnimtaionFinished;
    // 도넛 토핑의 상태
    private int[] Topping;

    // Use this for initialization
    void Start()
    {
        Sound = GameObject.Find("Sound(Clone)");
        MainSound = Sound.GetComponent<AudioSource>();
        this.gameObject.SetActive(false);
        Coin_Object.gameObject.SetActive(false);
        Score_Object.gameObject.SetActive(false);
        Quality_Object.gameObject.SetActive(false);
        Doughnut_Object.gameObject.SetActive(false);
        Equal.gameObject.SetActive(false);
        Topping = new int[2];
        bIsShow = false;
        bIsResultWindowAnimtaionFinished = new bool[6];
        SceneChangePossible = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_Time += Time.deltaTime;

        // 결과창이 활성화 상태라면
        if (!GameManager.instance.Game && !bIsShow)
        {
            // 결과창을 보인다.
            ResultWindowShow();
            Doughnut_Object.gameObject.SetActive(true);
            bIsShow = true;

            // 만든 도넛을 저장한다.
            DoughnutSave();

            // 퀄리티 값이 10 이하면
            if (PlayerPrefs.GetInt("Quality") < 10)
            {
                // 저장한다.
                int Number = PlayerPrefs.GetInt("Quality");

                PlayerPrefs.SetInt("Quality", Number + 1);
            }
        }

        // 0.5초 때 이루어질 애니메이션
        if (m_Time > 0.5 && !bIsResultWindowAnimtaionFinished[0])
        {
            if (Doughnut_Object.transform.position.x < -3)
            {
                // 첫번째 애니메이션 끝
                bIsResultWindowAnimtaionFinished[0] = true;
            }
            else
            {
                // 도넛 UI를 보여준다.
                Doughnut_Object.transform.position = new Vector3(Doughnut_Object.transform.position.x + -0.075F, Doughnut_Object.transform.position.y, Doughnut_Object.transform.position.z);
            }
        }

        // 2초가 지났다면
        if (m_Time > 2 && !bIsResultWindowAnimtaionFinished[1])
        {
            // UI들을 보여준다.
            Coin_Object.gameObject.SetActive(true);
            Score_Object.gameObject.SetActive(true);
            Quality_Object.gameObject.SetActive(true);
            bIsResultWindowAnimtaionFinished[1] = true;
        }

        // 2.5초가 지났다면
        if (m_Time > 2.5 && !bIsResultWindowAnimtaionFinished[2])
        {
            // 점수를 보여준다.
            string s_Score = GameManager.instance.Score.ToString();

            float ScoreXPos = Score_Object.transform.position.x + 1F;
            float ScoreYPos = Score_Object.transform.position.y;

            bIsResultWindowAnimtaionFinished[2] = true;

            // 점수 UI 표시
            for (int i = 0; i < s_Score.Length; i++)
            {
                switch (s_Score[i])
                {
                    case '0':
                        Instantiate(GameManager.instance.Number[0], new Vector3(ScoreXPos + (i * 0.5F), ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '1':
                        Instantiate(GameManager.instance.Number[1], new Vector3(ScoreXPos + (i * 0.5F), ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '2':
                        Instantiate(GameManager.instance.Number[2], new Vector3(ScoreXPos + (i * 0.5F), ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '3':
                        Instantiate(GameManager.instance.Number[3], new Vector3(ScoreXPos + (i * 0.5F), ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '4':
                        Instantiate(GameManager.instance.Number[4], new Vector3(ScoreXPos + (i * 0.5F), ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '5':
                        Instantiate(GameManager.instance.Number[5], new Vector3(ScoreXPos + (i * 0.5F), ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '6':
                        Instantiate(GameManager.instance.Number[6], new Vector3(ScoreXPos + (i * 0.5F), ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '7':
                        Instantiate(GameManager.instance.Number[7], new Vector3(ScoreXPos + (i * 0.5F), ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '8':
                        Instantiate(GameManager.instance.Number[8], new Vector3(ScoreXPos + (i * 0.5F), ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '9':
                        Instantiate(GameManager.instance.Number[9], new Vector3(ScoreXPos + (i * 0.5F), ScoreYPos, -8), Quaternion.identity);
                        break;
                }
            }

            int ScoreTemp = PlayerPrefs.GetInt("Jelly") + GameManager.instance.Score / 10000;

            int Scoret = GameManager.instance.Score / 10000;
            string s_ScoreTemp = Scoret.ToString();

            float t_ScoreXPos = Equal.transform.position.x + 1F;
            float t_ScoreYPos = Equal.transform.position.y;

            Equal.gameObject.SetActive(true);

            // 젤리 UI 표시
            for (int i = 0; i < s_ScoreTemp.Length; i++)
            {
                switch (s_ScoreTemp[i])
                {
                    case '0':
                        Instantiate(GameManager.instance.Number[0], new Vector3(t_ScoreXPos + (i * 0.5F), t_ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '1':
                        Instantiate(GameManager.instance.Number[1], new Vector3(t_ScoreXPos + (i * 0.5F), t_ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '2':
                        Instantiate(GameManager.instance.Number[2], new Vector3(t_ScoreXPos + (i * 0.5F), t_ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '3':
                        Instantiate(GameManager.instance.Number[3], new Vector3(t_ScoreXPos + (i * 0.5F), t_ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '4':
                        Instantiate(GameManager.instance.Number[4], new Vector3(t_ScoreXPos + (i * 0.5F), t_ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '5':
                        Instantiate(GameManager.instance.Number[5], new Vector3(t_ScoreXPos + (i * 0.5F), t_ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '6':
                        Instantiate(GameManager.instance.Number[6], new Vector3(t_ScoreXPos + (i * 0.5F), t_ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '7':
                        Instantiate(GameManager.instance.Number[7], new Vector3(t_ScoreXPos + (i * 0.5F), t_ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '8':
                        Instantiate(GameManager.instance.Number[8], new Vector3(t_ScoreXPos + (i * 0.5F), t_ScoreYPos, -8), Quaternion.identity);
                        break;

                    case '9':
                        Instantiate(GameManager.instance.Number[9], new Vector3(t_ScoreXPos + (i * 0.5F), t_ScoreYPos, -8), Quaternion.identity);
                        break;
                }

            }

            // 젤리 값 저장
            PlayerPrefs.SetInt("Jelly", ScoreTemp); 
        }

        // 3초가 지났다면
        if (m_Time > 3 && !bIsResultWindowAnimtaionFinished[3])
        {
            // 코인 UI 처리
            string s_Coin = GameManager.instance.Coin.ToString();

            float CoinXPos = Coin_Object.transform.position.x + 1F;
            float CoinYPos = Coin_Object.transform.position.y;

            bIsResultWindowAnimtaionFinished[3] = true;

            // 코인 UI 표시
            for (int i = 0; i < s_Coin.Length; i++)
            {
                switch (s_Coin[i])
                {
                    case '0':
                        Instantiate(GameManager.instance.Number[0], new Vector3(CoinXPos + (i * 0.5F), CoinYPos, -8), Quaternion.identity);
                        break;

                    case '1':
                        Instantiate(GameManager.instance.Number[1], new Vector3(CoinXPos + (i * 0.5F), CoinYPos, -8), Quaternion.identity);
                        break;

                    case '2':
                        Instantiate(GameManager.instance.Number[2], new Vector3(CoinXPos + (i * 0.5F), CoinYPos, -8), Quaternion.identity);
                        break;

                    case '3':
                        Instantiate(GameManager.instance.Number[3], new Vector3(CoinXPos + (i * 0.5F), CoinYPos, -8), Quaternion.identity);
                        break;

                    case '4':
                        Instantiate(GameManager.instance.Number[4], new Vector3(CoinXPos + (i * 0.5F), CoinYPos, -8), Quaternion.identity);
                        break;

                    case '5':
                        Instantiate(GameManager.instance.Number[5], new Vector3(CoinXPos + (i * 0.5F), CoinYPos, -8), Quaternion.identity);
                        break;

                    case '6':
                        Instantiate(GameManager.instance.Number[6], new Vector3(CoinXPos + (i * 0.5F), CoinYPos, -8), Quaternion.identity);
                        break;

                    case '7':
                        Instantiate(GameManager.instance.Number[7], new Vector3(CoinXPos + (i * 0.5F), CoinYPos, -8), Quaternion.identity);
                        break;

                    case '8':
                        Instantiate(GameManager.instance.Number[8], new Vector3(CoinXPos + (i * 0.5F), CoinYPos, -8), Quaternion.identity);
                        break;

                    case '9':
                        Instantiate(GameManager.instance.Number[9], new Vector3(CoinXPos + (i * 0.5F), CoinYPos, -8), Quaternion.identity);
                        break;
                }
            }

            int CoinTemp = PlayerPrefs.GetInt("Coin") + GameManager.instance.Coin;
            PlayerPrefs.SetInt("Coin", CoinTemp); 
        }

        // 3.5초가 지났다면
        if (m_Time > 3.5 && !bIsResultWindowAnimtaionFinished[4])
        {
            // 품질 UI
            string s_Quality = GameManager.instance.QualityScore.ToString();

            float QualityXPos = Quality_Object.transform.position.x + 1F;
            float QualityYPos = Quality_Object.transform.position.y;

            bIsResultWindowAnimtaionFinished[4] = true;

            // 품질 UI 표시
            for (int i = 0; i < s_Quality.Length; i++)
            {
                switch (s_Quality[i])
                {
                    case '0':
                        Instantiate(GameManager.instance.Number[0], new Vector3(QualityXPos + (i * 0.5F), QualityYPos, -8), Quaternion.identity);
                        break;

                    case '1':
                        Instantiate(GameManager.instance.Number[1], new Vector3(QualityXPos + (i * 0.5F), QualityYPos, -8), Quaternion.identity);
                        break;

                    case '2':
                        Instantiate(GameManager.instance.Number[2], new Vector3(QualityXPos + (i * 0.5F), QualityYPos, -8), Quaternion.identity);
                        break;

                    case '3':
                        Instantiate(GameManager.instance.Number[3], new Vector3(QualityXPos + (i * 0.5F), QualityYPos, -8), Quaternion.identity);
                        break;

                    case '4':
                        Instantiate(GameManager.instance.Number[4], new Vector3(QualityXPos + (i * 0.5F), QualityYPos, -8), Quaternion.identity);
                        break;

                    case '5':
                        Instantiate(GameManager.instance.Number[5], new Vector3(QualityXPos + (i * 0.5F), QualityYPos, -8), Quaternion.identity);
                        break;

                    case '6':
                        Instantiate(GameManager.instance.Number[6], new Vector3(QualityXPos + (i * 0.5F), QualityYPos, -8), Quaternion.identity);
                        break;

                    case '7':
                        Instantiate(GameManager.instance.Number[7], new Vector3(QualityXPos + (i * 0.5F), QualityYPos, -8), Quaternion.identity);
                        break;

                    case '8':
                        Instantiate(GameManager.instance.Number[8], new Vector3(QualityXPos + (i * 0.5F), QualityYPos, -8), Quaternion.identity);
                        break;

                    case '9':
                        Instantiate(GameManager.instance.Number[9], new Vector3(QualityXPos + (i * 0.5F), QualityYPos, -8), Quaternion.identity);
                        break;
                }
            }

            Instantiate(Persent, new Vector3(QualityXPos + 1F, QualityYPos, -8), Quaternion.identity);
        
        SceneChangePossible = true;
        
        }
    }

    // 결과창을 활성화한다.
    void ResultWindowShow()
    {
        Topping[0] = Doughnut_State.GetInteger("Doughnut_State");
        Topping[1] = Doughnut_State.GetInteger("Topping_State");

        DoughnutType = Topping[0] * 4 + Topping[1];

        Doughnut_Sprite.sprite = Doughnut[DoughnutType];

        Destroy(DouthnutObj);
    }

    // 만든 도넛을 저장한다.
    void DoughnutSave()
    {
        if (PlayerPrefs.GetInt("Doughnut1") == -1)
        {
            PlayerPrefs.SetInt("Doughnut1", DoughnutType);
            DoughnutPriceSave("Doughnut1Price");
        }
        else if (PlayerPrefs.GetInt("Doughnut2") == -1)
        {
            PlayerPrefs.SetInt("Doughnut2", DoughnutType);
            DoughnutPriceSave("Doughnut2Price");
        }
        else if (PlayerPrefs.GetInt("Doughnut3") == -1)
        {
            PlayerPrefs.SetInt("Doughnut3", DoughnutType);
            DoughnutPriceSave("Doughnut3Price");
        }
        else if (PlayerPrefs.GetInt("Doughnut4") == -1)
        {
            PlayerPrefs.SetInt("Doughnut4", DoughnutType);
            DoughnutPriceSave("Doughnut4Price");
        }
        else if (PlayerPrefs.GetInt("Doughnut5") == -1)
        {
            PlayerPrefs.SetInt("Doughnut5", DoughnutType);
            DoughnutPriceSave("Doughnut5Price");
        }
        else if (PlayerPrefs.GetInt("Doughnut6") == -1)
        {
            PlayerPrefs.SetInt("Doughnut6", DoughnutType);
            DoughnutPriceSave("Doughnut6Price");
        }
        else if (PlayerPrefs.GetInt("Doughnut7") == -1)
        {
            PlayerPrefs.SetInt("Doughnut7", DoughnutType);
            DoughnutPriceSave("Doughnut7Price");
        }
        else if (PlayerPrefs.GetInt("Doughnut8") == -1)
        {
            PlayerPrefs.SetInt("Doughnut8", DoughnutType);
            DoughnutPriceSave("Doughnut8Price");
        }
        else if (PlayerPrefs.GetInt("Doughnut9") == -1)
        {
            PlayerPrefs.SetInt("Doughnut9", DoughnutType);
            DoughnutPriceSave("Doughnut9Price");
        }
        else if (PlayerPrefs.GetInt("Doughnut10") == -1)
        {
            PlayerPrefs.SetInt("Doughnut10", DoughnutType);
            DoughnutPriceSave("Doughnut10Price");
        }
    }

    // 도넛의 값을 저장한다.
    void DoughnutPriceSave(string DoughnutName)
    {
        int SaveScore = GameManager.instance.QualityScore / 10;
        int ToppingScore;

        if (GameManager.instance.Topping)
        {
            ToppingScore = 150;
        }
        else 
        {
            ToppingScore = 0;
        }

        switch (SaveScore)
        {
            case 0:
                PlayerPrefs.SetInt(DoughnutName, 10 + ToppingScore);
                break;  

            case 1 :
                PlayerPrefs.SetInt(DoughnutName, 50 + ToppingScore);
                break;

            case 2:
                PlayerPrefs.SetInt(DoughnutName, 100 + ToppingScore);
                break;

            case 3:
                PlayerPrefs.SetInt(DoughnutName, 150 + ToppingScore);
                break;

            case 4:
                PlayerPrefs.SetInt(DoughnutName, 200 + ToppingScore);
                break;

            case 5 :
                PlayerPrefs.SetInt(DoughnutName, 250 + ToppingScore);
                break;

            case 6:
                PlayerPrefs.SetInt(DoughnutName, 300 + ToppingScore);
                break;

            case 7:
                PlayerPrefs.SetInt(DoughnutName, 350 + ToppingScore);
                break;

            case 8:
                PlayerPrefs.SetInt(DoughnutName, 400 + ToppingScore);
                break;

            case 9:
                PlayerPrefs.SetInt(DoughnutName, 450 + ToppingScore);
                break;

            case 10 :
                PlayerPrefs.SetInt(DoughnutName, 500 + ToppingScore);
                break;
        }
    }

    // 클릭된다면
    void OnMouseDown()
    {
        // 메인메뉴로 전환한다.
        if (SceneChangePossible)
        {
            MainSound.Play();
            Application.LoadLevel("MainScene");
        }
    }
}
