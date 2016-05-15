using UnityEngine;
using System.Collections;

//=======================================
// GameManager : 러닝게임을 관리하는 매니저
public class GameManager : MonoBehaviour
{
    // 스테이지 1의 패턴 프리팹
    public GameObject[] Stage1_Pattern;
    // 스테이지 2의 패턴 프리팹
    public GameObject[] Stage2_Pattern;
    // 스테이지 3의 패턴 프리팹
    public GameObject[] Stage3_Pattern;
    // 빈 패턴들
    public GameObject[] EmptyPattern;
    // 배경 오브젝트
    public GameObject[] BackGroundObject;
    // 게임의 결과창
    public GameObject Result;
    // 배경 스크롤 
    public SpriteScroll[] SpriteTransform;
    // 스크롤될 이미지들
    public SpriteChange[] SpriteImage;
    // 스테이지 변경 때 밝기 조절
    public FadeOut BlackScreen;
    // 장애물과 충돌했을 때의 처리
    public FadeOut HitScreen;

    // 패턴의 인덱스
    private int PatternNumber;
    // 패턴의 마지막 인덱스
    private int PatternMax;
    // 현재 토핑의 타입
    public int ToppingType;
    // 패턴이 나타나는 좌표
    public float AppearXPos, AppearYPos, AppearZPos;
    // 스테이지의 레벨
    public int StageLevel;
    // 패턴이 나온 횟수
    public int PatternCount;
    // 스테이지의 최대 갯수
    public bool bIsStageMax;
    // 토핑중인가
    public bool bIsTopping;
    // 토핑 상태
    public bool Topping;
    // 일시정지 상태인가
    public bool bIsPause;
    // 점수
    public int Score;
    // 돈
    public int Coin;
    // 토핑 카운트
    public int ToppingCount;
    // 품질 카운트
    public int QualityScore;
    // 게임이 진행중인가
    public bool Game;
    // 배경음악
    public AudioSource BackGroundSound;
    // 게임오브젝트들
    public GameObject[] Number;
    // 플레이어의 목숨
    public int Life;

    //=================================
    // Score
    public Object[] o_Score;
    private string s_Score;
    //=================================

    //=================================
    // Coin
    public Object[] o_Coin;
    private string s_Coin;
    //=================================

        // 초기화
    void Start()
    {
        BackGroundSound = this.GetComponent<AudioSource>();
        StageLevel = 0;
        PatternCount = 0;
        PatternMax = 10;
        Instance = this;
        bIsStageMax = false;
        bIsPause = false;
        Score = 0;
        Coin = 0;
        ToppingType = 0;
        ToppingCount = 1;
        o_Score = new Object[10];
        o_Coin = new Object[10];
        Life = 3;
        ScoreShow();
        CoinShow();
        Game = true;

        if (PlayerPrefs.GetInt("EffectSound") == 1)
            BackGroundSound.Stop();
    }

    // 루프
    void Update()
    {
        // 게임 진행 중에도 계속 손님들이 온다.
        CustomerCreate.m_CustomerTime += Time.deltaTime;

        // 게임이 진행중이라면
        if (Game)
        {
            // 라이프를 모두 잃었다면
            if (Life <= 0)
            {
                Game = false;
                Result.SetActive(true);
            }

            // 스테이지마다 지정된 패턴을 모두 피했고, 마지막 스테이지가 아니라면
            if (PatternCount >= PatternMax && !bIsStageMax)
            {
                StageLevel++;
                PatternCount = 0;
                BlackScreen.bIsActive = true;
                BlackScreen.bIsLevelChanged = true;

                // 스테이지 레벨별로 패턴 갯수 설정
                switch (StageLevel)
                {
                    case 0:
                        PatternMax = 12;
                        break;

                    case 1:
                        PatternMax += 3;
                        break;

                    case 2:
                        bIsStageMax = true;
                        break;
                }
            }
        }
    }

    // 패턴을 만든다
    public void MakePattern()
    {
        // 게임 상황 체크 후 패턴을 만든다.

        // 스테이지가 바뀌어야 함.
        if (PatternCount >= PatternMax - 1 && !bIsStageMax)
        {
            // 빈 패턴 만들기
            Instantiate(EmptyPattern[StageLevel + 1], new Vector3(AppearXPos, AppearYPos, AppearZPos), Quaternion.identity);
        }
        // 패턴을 만들 수 있음
        else
        {
            // 스테이지별로 패턴 만들기
            switch (StageLevel)
            { 
                case 0 :
                    PatternNumber = Random.Range(0, Stage1_Pattern.Length);
                    Instantiate(Stage1_Pattern[PatternNumber], new Vector3(AppearXPos, AppearYPos, AppearZPos), Quaternion.identity);

                    break;

                case 1 :

                    PatternNumber = Random.Range(0, Stage2_Pattern.Length);
                    Instantiate(Stage2_Pattern[PatternNumber], new Vector3(AppearXPos, AppearYPos, AppearZPos), Quaternion.identity);
                    break;

                case 2 :
                    PatternNumber = Random.Range(0, Stage3_Pattern.Length);
                    Instantiate(Stage3_Pattern[PatternNumber], new Vector3(AppearXPos, AppearYPos, AppearZPos), Quaternion.identity);

                    break;
            }
        }
    }

    // 배경을 리셋한다.
    public void BackGroundReset()
    {
        // 배경의 수 만큼
        for (int ObjCount = 0; ObjCount < BackGroundObject.Length; ObjCount++)
        {
            // 총 루프되는 배경은 3개, 좌표를 맞춰준다.
            switch (ObjCount % 3)
            { 
                case 0 :
                    BackGroundObject[ObjCount].transform.position = new Vector3(
                        8,
                        SpriteTransform[ObjCount].RespawnYPos[StageLevel],
                        SpriteTransform[ObjCount].RespawnZPos[StageLevel]);

                    break;
                    
                case 1 :
                    BackGroundObject[ObjCount].transform.position = new Vector3(
                        24,
                        SpriteTransform[ObjCount].RespawnYPos[StageLevel],
                        SpriteTransform[ObjCount].RespawnZPos[StageLevel]);

                    break;

                case 2 :
                    BackGroundObject[ObjCount].transform.position= new Vector3(
                        40,
                        SpriteTransform[ObjCount].RespawnYPos[StageLevel],
                        SpriteTransform[ObjCount].RespawnZPos[StageLevel]);

                    break;
            }
        }
    }

    // 스테이지가 바뀌고 배경도 바꾼다.
    public void BackGroundAlter()
    {
        for (int View = 0; View < 3; View++)
        {
            for (int SpriteCount = 0; SpriteCount < 3; SpriteCount++)
            {
                SpriteImage[View * 3 + SpriteCount].ImageChange(StageLevel);
            }
        }
    }

    // 코인 UI
    public void CoinShow()
    {
        // 코인을 string 으로 바꾸고
        s_Coin = Coin.ToString();

        // string 값에 따라 이미지를 출력한다.
        for (int i = 0; i < s_Coin.Length; i++)
        {
            switch (s_Coin[i])
            {
                case '0':
                    o_Coin[i] = Instantiate(Number[0], new Vector3(-1 + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;                                                              
                                                                                        
                case '1':                                                               
                    o_Coin[i] = Instantiate(Number[1], new Vector3(-1 + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;                                                              
                                                                                        
                case '2':                                                               
                    o_Coin[i] = Instantiate(Number[2], new Vector3(-1 + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;                                                              
                                                                                        
                case '3':                                                               
                    o_Coin[i] = Instantiate(Number[3], new Vector3(-1 + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;                                                              
                                                                                        
                case '4':                                                               
                    o_Coin[i] = Instantiate(Number[4], new Vector3(-1 + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;                                                              
                                                                                        
                case '5':                                                               
                    o_Coin[i] = Instantiate(Number[5], new Vector3(-1 + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;                                                              
                                                                                        
                case '6':                                                               
                    o_Coin[i] = Instantiate(Number[6], new Vector3(-1 + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;                                                              
                                                                                        
                case '7':                                                               
                    o_Coin[i] = Instantiate(Number[7], new Vector3(-1 + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;                                                              
                                                                                        
                case '8':                                                               
                    o_Coin[i] = Instantiate(Number[8], new Vector3(-1 + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;                                                              
                                                                                        
                case '9':                                                               
                    o_Coin[i] = Instantiate(Number[9], new Vector3(-1 + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;
            }
        }
    }

    // 코인 UI 처리
    public void CoinHide()
    {
        s_Coin = Coin.ToString();

        // 코인 UI 오브젝트들을 삭제한다. (코인 값이 변경되었을 때 쓰인다.)
        for (int i = 0; i < s_Coin.Length; i++)
        {
            Destroy(o_Coin[i]);
        }
    }

    // 점수 UI
    public void ScoreShow()
    {
        s_Score = Score.ToString();

        // 점수 표시
        for (int i = 0; i < s_Score.Length; i++)
        {
            switch (s_Score[i])
            {
                case '0':
                    o_Score[i] = Instantiate(Number[0], new Vector3(-6.5F + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;

                case '1':
                    o_Score[i] = Instantiate(Number[1], new Vector3(-6.5F + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;

                case '2':
                    o_Score[i] = Instantiate(Number[2], new Vector3(-6.5F + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;

                case '3':
                    o_Score[i] = Instantiate(Number[3], new Vector3(-6.5F + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;

                case '4':
                    o_Score[i] = Instantiate(Number[4], new Vector3(-6.5F + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;

                case '5':
                    o_Score[i] = Instantiate(Number[5], new Vector3(-6.5F + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;

                case '6':
                    o_Score[i] = Instantiate(Number[6], new Vector3(-6.5F + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;

                case '7':
                    o_Score[i] = Instantiate(Number[7], new Vector3(-6.5F + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;

                case '8':
                    o_Score[i] = Instantiate(Number[8], new Vector3(-6.5F + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;

                case '9':
                    o_Score[i] = Instantiate(Number[9], new Vector3(-6.5F + (i * 0.5F), 4, -6), Quaternion.identity);
                    break;
            }
        }
    }

    // 점수 UI 숨김
    public void ScoreHide()
    {
        s_Score = Score.ToString();

        // 점수 UI를 없앤다. (점수 값이 달라졌을 때 쓰인다.)
        for (int i = 0; i < s_Score.Length; i++)
        {
            Destroy(o_Score[i]);
        }
    }

    //======================================================================================
    // 싱글톤
    private static GameManager Instance;

    public static GameManager instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = new GameObject("GameManager").AddComponent<GameManager>();
            }

            return Instance;
        }
    }
    //======================================================================================
}
