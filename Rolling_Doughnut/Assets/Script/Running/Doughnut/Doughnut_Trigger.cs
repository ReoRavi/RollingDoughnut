using UnityEngine;
using System.Collections;

// 도넛 토핑 상태들
public enum Doughnut_ToppingState { Banila, Choco, Coke, Jam, Mint, Normal, Poision, StrawBerry, Wasabi };

//=======================================
// Doughnut_Trigger : 도넛과 오브젝트들의 충돌 처리
public class Doughnut_Trigger : MonoBehaviour
{
    // 도넛 충돌 스크립트
    private Doughnut_Hit Hit;
    // 도넛 품질 스크립트
    private Doughnut_Quality Quailty;
    // 도넛 토핑 스크립트
    public Doughnut_ToppingState ToppingState;
    // 코인 소리
    public AudioSource CoinSound;
    // 점수 소리
    public AudioSource ScoreSound;

    // 초기화
    void Start()
    {
        Hit = GetComponent<Doughnut_Hit>();
        Quailty = GetComponent<Doughnut_Quality>();
        ToppingState = Doughnut_ToppingState.Normal;
    }

    // 충돌 처리 부분
    void OnTriggerEnter2D(Collider2D Col)
    {
        // 충돌 처리중이 아니라면
        if (!Hit.bIsHit)
        {
            // 장애물에 부딛혔을 경우
            if (Col.gameObject.tag == "Obstacle")
            {
                GameManager.instance.HitScreen.bIsActive = true;
                GameManager.instance.Life--;
                Hit.HitInit();
                Hit.bIsHit = true;
            }
        }

        // 바로 죽는 공간 충돌
        if (Col.gameObject.tag == "DeathZone")
        {
            GameManager.instance.Life = 0;
        }

        // 큰 코인 충돌
        if (Col.gameObject.tag == "BigCoin")
        {
            // 코인 최대치
            if (GameManager.instance.Coin <= 100000)
            {
                GameManager.instance.CoinHide();

                GameManager.instance.Coin += 10;

                GameManager.instance.CoinShow();
            }
            else
            {
                // 최대 범위를 넘어서지 않게
                GameManager.instance.Coin = 99999;
            }

            // 사운드 옵션 검사
            if (PlayerPrefs.GetInt("EffectSound") == 0)
            {
                CoinSound.Play();
            }

            // 동전 삭제
            Destroy(Col.gameObject);
        }

        // 동전
        if (Col.gameObject.tag == "Coin")
        {
            // 코인 최대치
            if (GameManager.instance.Coin <= 100000)
            {
                GameManager.instance.CoinHide();

                GameManager.instance.Coin += 1;

                GameManager.instance.CoinShow();
            }
            else
            {                
                // 최대 범위를 넘어서지 않게
                GameManager.instance.Coin = 99999;
            }

            if (PlayerPrefs.GetInt("EffectSound") == 0)
            {
                CoinSound.Play();
            }

            Destroy(Col.gameObject);
        }

        // 점수 충돌
        if (Col.gameObject.tag == "Score")
        {
            // 점수 최대치
            if ((GameManager.instance.Score <= 100000000))
            {
                // 점수를 랜덤으로 준다.
                int Score = Random.Range(1000, 2000);

                GameManager.instance.ScoreHide();

                GameManager.instance.Score += Score;

                GameManager.instance.ScoreShow();

                if (PlayerPrefs.GetInt("EffectSound") == 0)
                {
                    ScoreSound.Play();
                }

            }
            else
            {
                GameManager.instance.Score = 9999999;
            }

            // 점수 오브젝트 삭제
            Destroy(Col.gameObject);
        }

        // 큰 점수 충돌
        if (Col.gameObject.tag == "BigScore")
        {
            // 점수 최대치
            if ((GameManager.instance.Score <= 100000000))
            {
                int Score = Random.Range(2500, 5000);

                GameManager.instance.ScoreHide();

                GameManager.instance.Score += Score;

                GameManager.instance.ScoreShow();

                if (PlayerPrefs.GetInt("EffectSound") == 0)
                {
                    ScoreSound.Play();
                }
            
            }
            else
            {
                GameManager.instance.Score = 9999999;
            }

            Destroy(Col.gameObject);
        }


        //==================================================================
        // Topping
        if (Col.gameObject.tag == "Banila")
        {
            ToppingState = Doughnut_ToppingState.Banila;
            Quailty.BanilaTopping();
        }

        if (Col.gameObject.tag == "Choco")
        {
            ToppingState = Doughnut_ToppingState.Choco;
            Quailty.ChocoTopping();
        }

        if (Col.gameObject.tag == "Coke")
        {
            ToppingState = Doughnut_ToppingState.Coke;
            Quailty.CokeTopping();
        }

        if (Col.gameObject.tag == "Jam")
        {
            ToppingState = Doughnut_ToppingState.Jam;
            Quailty.JamTopping();
        }

        if (Col.gameObject.tag == "Mint")
        {
            ToppingState = Doughnut_ToppingState.Mint;
            Quailty.MintTopping();
        }

        if (Col.gameObject.tag == "Poision")
        {
            ToppingState = Doughnut_ToppingState.Poision;
            Quailty.PoisionTopping();
        }

        if (Col.gameObject.tag == "StrawBerry")
        {
            ToppingState = Doughnut_ToppingState.StrawBerry;
            Quailty.StrawBerryTopping();
        }

        if (Col.gameObject.tag == "Wasabi")
        {
            ToppingState = Doughnut_ToppingState.Wasabi;
            Quailty.WasabiTopping();
        }

        if (Col.gameObject.tag == "StrawBerryTopping")
        {
            GameManager.instance.bIsTopping = true;
            GameManager.instance.Topping = true;
        }

        if (Col.gameObject.tag == "ChocoTopping")
        {
            GameManager.instance.bIsTopping = true;
            GameManager.instance.Topping = true;
        }

        if (Col.gameObject.tag == "CreamTopping")
        {
            GameManager.instance.bIsTopping = true;
            GameManager.instance.Topping = true;
        }
    }

    // 충돌이 끝날 때
    void OnTriggerExit2D(Collider2D Col)
    {
        // 3단계 토핑 처리        
        if (Col.gameObject.tag == "StrawBerryTopping")
        {
            GameManager.instance.bIsTopping = false;
        }

        if (Col.gameObject.tag == "ChocoTopping")
        {
            GameManager.instance.bIsTopping = false;
        }

        if (Col.gameObject.tag == "CreamTopping")
        {
            GameManager.instance.bIsTopping = false;
        }
    }
}
