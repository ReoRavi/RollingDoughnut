using UnityEngine;
using System.Collections;

//=======================================
// Doughnut_Quality : 도넛 품질에 따른 UI 및 이미지 처리 
public class Doughnut_Quality : MonoBehaviour
{
    // 품질 
    public int QuailtyScore;
    // 품질 숫자 오브젝트
    public GameObject[] Number;
    // 기호
    public GameObject Count;
    // 1의 자리 품질
    private Object First_Quality;
    // 10의 자리 품질
    private Object Second_Quality;
    // 100의 자리 품질
    private Object Thrid_Quality;
    // 기호 오브젝트
    private Object QualityCount;
    // 숫자 이미지들
    public Sprite[] QualityNumber;
    // 이미지 객체
    public SpriteRenderer Quality;

    // Use this for initialization
    void Start()
    {
        QuailtyScore = 50;

        QualityShow();
    }

    // Update is called once per frame
    void Update()
    {
        // 게임중이라면
        if (GameManager.instance.Game)
        {
            // 좋은 품질 이미지 처리
            if (QuailtyScore >= 75)
            {
                Quality.sprite = QualityNumber[2];
            }
            // 보통 품질 이미지 처리
            else if (QuailtyScore > 45)
            {
                Quality.sprite = QualityNumber[1];
            }
            // 나쁜 품질 이미지 처리
            else
            {
                Quality.sprite = QualityNumber[0];
            }
        }
    }

    // 품질을 보인다.
    void QualityShow()
    {
        // 100일 경우의 처리
        if (QuailtyScore == 100)
        {
            First_Quality = Instantiate(Number[1], new Vector3(2.2F, 4, -6), Quaternion.identity);
            Second_Quality = Instantiate(Number[0], new Vector3(2.6F, 4, -6), Quaternion.identity);
            Thrid_Quality = Instantiate(Number[0], new Vector3(3F, 4, -6), Quaternion.identity);
            QualityCount = Instantiate(Count, new Vector3(3.4F, 4, -8), Quaternion.identity);
        }
        // 0 일 경우의 처리
        else if (QuailtyScore == 0)
        {
            First_Quality = Instantiate(Number[0], new Vector3(2.3F, 4, -6), Quaternion.identity);
            Second_Quality = Instantiate(Number[0], new Vector3(2.8F, 4, -6), Quaternion.identity);
            QualityCount = Instantiate(Count, new Vector3(3.3F, 4, -6), Quaternion.identity);
        }
        // 품질이 10대일 경우의 처리
        else
        {
            First_Quality = Instantiate(Number[QuailtyScore % 10], new Vector3(2.8F, 4, -6), Quaternion.identity);
            Second_Quality = Instantiate(Number[QuailtyScore / 10], new Vector3(2.3F, 4, -6), Quaternion.identity);
            QualityCount = Instantiate(Count, new Vector3(3.3F, 4, -6), Quaternion.identity);
        }
    }

    // 품질 해제
    void QualityHide()
    {
        // 100일 경우의 처리
        if (QuailtyScore == 100)
        {
            Destroy(Thrid_Quality);
            Destroy(Second_Quality);
            Destroy(First_Quality);
            Destroy(QualityCount);
        }
        // 0 일 경우의 처리
        else if (QuailtyScore == 0)
        {
            Destroy(Second_Quality);
            Destroy(First_Quality);
            Destroy(QualityCount);
        }
        // 품질이 10대일 경우의 처리
        else
        {
            Destroy(Second_Quality);
            Destroy(First_Quality);
            Destroy(QualityCount);
        }
    }

    // 바닐라 토핑 처리
    public void BanilaTopping()
    {
        int OperationValue = Random.Range(8, 11);

        QualityHide();

        if (QuailtyScore + OperationValue < 100)
        {
            QuailtyScore += OperationValue;
        }
        else
        {
            QuailtyScore = 100;
        }

        QualityShow();
    }

    // 초코 토핑 처리
    public void ChocoTopping()
    {
        int OperationValue = Random.Range(8, 11);

        QualityHide();

        if (QuailtyScore + OperationValue < 100)
        {
            QuailtyScore += OperationValue;
        }
        else
        {
            QuailtyScore = 100;
        }

        QualityShow();
    }

    // 딸기 토핑 처리
    public void StrawBerryTopping()
    {
        int OperationValue = Random.Range(8, 11);

        QualityHide();

        if (QuailtyScore + OperationValue < 100)
        {
            QuailtyScore += OperationValue;
        }
        else
        {
            QuailtyScore = 100;
        }

        QualityShow();
    }

    // 잼 토핑 처리
    public void JamTopping()
    {
        int OperationValue = Random.Range(3, 8);

        QualityHide();

        if (QuailtyScore + OperationValue < 100)
        {
            QuailtyScore += OperationValue;
        }
        else
        {
            QuailtyScore = 100;
        }

        QualityShow();
    }

    // 민트 토핑 처리
    public void MintTopping()
    {
        int OperationValue = Random.Range(3, 8);

        QualityHide();

        if (QuailtyScore + OperationValue < 100)
        {
            QuailtyScore += OperationValue;
        }
        else
        {
            QuailtyScore = 100;
        }

        QualityShow();
    }

    // 코크 토핑 처리
    public void CokeTopping()
    {
        int OperationValue = Random.Range(12, 22);

        QualityHide();

        if (QuailtyScore - OperationValue > 0)
        {
            QuailtyScore -= OperationValue;
        }
        else
        {
            QuailtyScore = 0;
        }

        QualityShow();
    }

    // 독 토핑 처리
    public void PoisionTopping()
    {
        int OperationValue = Random.Range(22, 27);

        QualityHide();

        if (QuailtyScore - OperationValue > 0)
        {
            QuailtyScore -= OperationValue;
        }
        else
        {
            QuailtyScore = 0;
        }

        QualityShow();
    }

    // 와사비 토핑 처리
    public void WasabiTopping()
    {
        int OperationValue = Random.Range(22, 27);

        QualityHide();

        if (QuailtyScore - OperationValue > 0)
        {
            QuailtyScore -= OperationValue;
        }
        else
        {
            QuailtyScore = 0;
        }

        QualityShow();
    }
}
