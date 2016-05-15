using UnityEngine;
using System.Collections;

//=======================================
// Coin_Display : 메인메뉴의 상단 레벨, 코인, 젤리, 도넛 개수 UI
public class Coin_Display : MonoBehaviour
{
    // 레벨 UI 오브젝트
    public Object[] LevelObj;
    // 레벨 UI 활성화 상태
    public bool bIsLevelShow;
    // 숫자들
    public GameObject[] Number;
    // '/' 오브젝트
    public GameObject CountObj;
    // 동전 오브젝트
    public Object[] CoinObj;
    // 동전 좌표
    public float CoinXPos, CoinYPos;
    // 타이쿤 UI 위치
    public float LevelXPos, LevelYPos;
    // 젤리 좌표
    public float JellyXPos, JellyYPos;
    // 갯수 오브젝트
    public Object[] QualityObj;
    // 갯수 좌표
    public float QualityXPos, QualityYPos;

    // 레벨
    int Level;

    // Use this for initialization
    void Start()
    {
        CoinObj = new Object[10];
        QualityObj = new Object[10];
        LevelObj = new Object[2];
        CoinShow();
        JellyShow();
        QualityShow();

        if (bIsLevelShow)
        {
            LevelShow();
        }
    }


    // 레벨 UI 처리
    public void LevelShow()
    {
        int TentLevel = PlayerPrefs.GetInt("TentLevel");
        int ClerkLevel = PlayerPrefs.GetInt("ClerkLevel");

        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                Level = TentLevel;
            }
            if (i == 1)
            {
                Level = ClerkLevel;
            }

            switch (Level + 1)
            {
                case 0:
                    LevelObj[i] = Instantiate(Number[0], new Vector3(LevelXPos, LevelYPos + (i * -0.45F), -5), Quaternion.identity);
                    break;

                case 1:
                    LevelObj[i] = Instantiate(Number[1], new Vector3(LevelXPos, LevelYPos + (i * -0.45F), -5), Quaternion.identity);
                    break;

                case 2:
                    LevelObj[i] = Instantiate(Number[2], new Vector3(LevelXPos, LevelYPos + (i * -0.45F), -5), Quaternion.identity);
                    break;

                case 3:
                    LevelObj[i] = Instantiate(Number[3], new Vector3(LevelXPos, LevelYPos + (i * -0.45F), -5), Quaternion.identity);
                    break;

                case 4:
                    LevelObj[i] = Instantiate(Number[4], new Vector3(LevelXPos, LevelYPos + (i * -0.45F), -5), Quaternion.identity);
                    break;

                case 5:
                    LevelObj[i] = Instantiate(Number[5], new Vector3(LevelXPos, LevelYPos + (i * -0.45F), -5), Quaternion.identity);
                    break;

                case '6':
                    LevelObj[i] = Instantiate(Number[6], new Vector3(LevelXPos, LevelYPos + (i * -0.45F), -5), Quaternion.identity);
                    break;

                case '7':
                    LevelObj[i] = Instantiate(Number[7], new Vector3(LevelXPos, LevelYPos + (i * -0.45F), -5), Quaternion.identity);
                    break;

                case '8':
                    LevelObj[i] = Instantiate(Number[8], new Vector3(LevelXPos, LevelYPos + (i * -0.45F), -5), Quaternion.identity);
                    break;

                case '9':
                    LevelObj[i] = Instantiate(Number[9], new Vector3(LevelXPos, LevelYPos + (i * -0.45F), -5), Quaternion.identity);
                    break;
            }
        }
    }

    // 레벨 UI 초기화
    public void LevelReset()
    {
        for (int i = 0; i < LevelObj.Length; i++)
        {
            Destroy(LevelObj[i]);
        }
    }

    // 코인 UI 초기화
    public void CoinReset()
    {
        for (int i = 0; i < CoinObj.Length; i++)
        {
            Destroy(CoinObj[i]);
        }
    }

    // 코인 UI 처라
    public void CoinShow()
    {
        int Coin = PlayerPrefs.GetInt("Coin");
        string s_Coin;

        s_Coin = Coin.ToString();

        for (int i = 0; i < s_Coin.Length; i++)
        {
            switch (s_Coin[i])
            {
                case '0':

                    CoinObj[i] = Instantiate(Number[0], new Vector3(CoinXPos + (i * 0.25F), CoinYPos, -6), Quaternion.identity);
                    break;

                case '1':

                    CoinObj[i] = Instantiate(Number[1], new Vector3(CoinXPos + (i * 0.25F), CoinYPos, -6), Quaternion.identity);
                    break;

                case '2':

                    CoinObj[i] = Instantiate(Number[2], new Vector3(CoinXPos + (i * 0.25F), CoinYPos, -6), Quaternion.identity);
                    break;

                case '3':

                    CoinObj[i] = Instantiate(Number[3], new Vector3(CoinXPos + (i * 0.25F), CoinYPos, -6), Quaternion.identity);
                    break;

                case '4':

                    CoinObj[i] = Instantiate(Number[4], new Vector3(CoinXPos + (i * 0.25F), CoinYPos, -6), Quaternion.identity);
                    break;

                case '5':

                    CoinObj[i] = Instantiate(Number[5], new Vector3(CoinXPos + (i * 0.25F), CoinYPos, -6), Quaternion.identity);
                    break;

                case '6':

                    CoinObj[i] = Instantiate(Number[6], new Vector3(CoinXPos + (i * 0.25F), CoinYPos, -6), Quaternion.identity);
                    break;

                case '7':

                    CoinObj[i] = Instantiate(Number[7], new Vector3(CoinXPos + (i * 0.25F), CoinYPos, -6), Quaternion.identity);
                    break;

                case '8':

                    CoinObj[i] = Instantiate(Number[8], new Vector3(CoinXPos + (i * 0.25F), CoinYPos, -6), Quaternion.identity);
                    break;

                case '9':

                    CoinObj[i] = Instantiate(Number[9], new Vector3(CoinXPos + (i * 0.25F), CoinYPos, -6), Quaternion.identity);
                    break;
            }
        }
    }

    // 젤리 UI 처리
    public void JellyShow()
    {
        int Jelly = PlayerPrefs.GetInt("Jelly");
        string s_Jelly;

        s_Jelly = Jelly.ToString();

        for (int i = 0; i < s_Jelly.Length; i++)
        {
            switch (s_Jelly[i])
            {
                case '0':

                    Instantiate(Number[0], new Vector3(JellyXPos + (i * 0.25F), JellyYPos, -6), Quaternion.identity);
                    break;

                case '1':

                    Instantiate(Number[1], new Vector3(JellyXPos + (i * 0.25F), JellyYPos, -6), Quaternion.identity);
                    break;

                case '2':

                    Instantiate(Number[2], new Vector3(JellyXPos + (i * 0.25F), JellyYPos, -6), Quaternion.identity);
                    break;

                case '3':

                    Instantiate(Number[3], new Vector3(JellyXPos + (i * 0.25F), JellyYPos, -6), Quaternion.identity);
                    break;

                case '4':

                    Instantiate(Number[4], new Vector3(JellyXPos + (i * 0.25F), JellyYPos, -6), Quaternion.identity);
                    break;

                case '5':

                    Instantiate(Number[5], new Vector3(JellyXPos + (i * 0.25F), JellyYPos, -6), Quaternion.identity);
                    break;

                case '6':

                    Instantiate(Number[6], new Vector3(JellyXPos + (i * 0.25F), JellyYPos, -6), Quaternion.identity);
                    break;

                case '7':

                    Instantiate(Number[7], new Vector3(JellyXPos + (i * 0.25F), JellyYPos, -6), Quaternion.identity);
                    break;

                case '8':

                    Instantiate(Number[8], new Vector3(JellyXPos + (i * 0.25F), JellyYPos, -6), Quaternion.identity);
                    break;

                case '9':

                    Instantiate(Number[9], new Vector3(JellyXPos + (i * 0.25F), JellyYPos, -6), Quaternion.identity);
                    break;
            }
        }
    }

    // 도넛 갯수 UI
    public void QualityShow()
    {
        int Quality = PlayerPrefs.GetInt("Quality");
        string s_Quality;

        s_Quality = Quality.ToString();

        for (int i = 0; i < s_Quality.Length; i++)
        {
            switch (s_Quality[i])
            {
                case '0':
                    QualityObj[i] = Instantiate(Number[0], new Vector3(QualityXPos + (i * 0.3F), QualityYPos, -6), Quaternion.identity);

                    break;

                case '1':
                    QualityObj[i] = Instantiate(Number[1], new Vector3(QualityXPos + (i * 0.3F), QualityYPos, -6), Quaternion.identity);

                    break;

                case '2':
                    QualityObj[i] = Instantiate(Number[2], new Vector3(QualityXPos + (i * 0.3F), QualityYPos, -6), Quaternion.identity);

                    break;

                case '3':
                    QualityObj[i] = Instantiate(Number[3], new Vector3(QualityXPos + (i * 0.3F), QualityYPos, -6), Quaternion.identity);

                    break;

                case '4':
                    QualityObj[i] = Instantiate(Number[4], new Vector3(QualityXPos + (i * 0.3F), QualityYPos, -6), Quaternion.identity);

                    break;

                case '5':
                    QualityObj[i] = Instantiate(Number[5], new Vector3(QualityXPos + (i * 0.3F), QualityYPos, -6), Quaternion.identity);

                    break;

                case '6':
                    QualityObj[i] = Instantiate(Number[6], new Vector3(QualityXPos + (i * 0.3F), QualityYPos, -6), Quaternion.identity);

                    break;

                case '7':
                    QualityObj[i] = Instantiate(Number[7], new Vector3(QualityXPos + (i * 0.3F), QualityYPos, -6), Quaternion.identity);

                    break;

                case '8':
                    QualityObj[i] = Instantiate(Number[8], new Vector3(QualityXPos + (i * 0.3F), QualityYPos, -6), Quaternion.identity);

                    break;

                case '9':
                    QualityObj[i] = Instantiate(Number[9], new Vector3(QualityXPos + (i * 0.3F), QualityYPos, -6), Quaternion.identity);

                    break;
            }
        }


        if (s_Quality == "10")
        {
            QualityObj[2] = Instantiate(CountObj, new Vector3(QualityXPos + 0.5F, QualityYPos, -8), Quaternion.identity);
            QualityObj[3] = Instantiate(Number[1], new Vector3(QualityXPos + 0.8F, QualityYPos, -8), Quaternion.identity);
            QualityObj[4] = Instantiate(Number[0], new Vector3(QualityXPos + 1.1F, QualityYPos, -8), Quaternion.identity);
        }
        else
        {
            QualityObj[1] = Instantiate(CountObj, new Vector3(QualityXPos + s_Quality.Length * 0.3F, QualityYPos, -8), Quaternion.identity);
            QualityObj[2] = Instantiate(Number[1], new Vector3(QualityXPos + s_Quality.Length * 0.6F, QualityYPos, -8), Quaternion.identity);
            QualityObj[3] = Instantiate(Number[0], new Vector3(QualityXPos + s_Quality.Length * 0.9F, QualityYPos, -8), Quaternion.identity);
        }

    }

    // 갯수 UI 초기화
    public void QualityReset()
    {
        for (int i = 0; i < QualityObj.Length; i++)
        {
            Destroy(QualityObj[i]);
        }
    }
}
