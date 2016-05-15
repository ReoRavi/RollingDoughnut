using UnityEngine;
using System.Collections;

//=======================================
// Doughnut_Sell : 도넛 판매 처리
public class Doughnut_Sell : MonoBehaviour {

    // 손님 번호
    public int CustomerNumber;
    // 도넛 오브젝트들
    public GameObject[] Doughnuts;

    // 클릭되었을 때
    void OnMouseDown()
    {
        // 손님이 꽉 찻을 때
        if (CustomerCreate.bIsCustomerActive[0] && CustomerCreate.bIsCustomerActive[1] && CustomerCreate.bIsCustomerActive[2])
        {
            CustomerCreate.m_CustomerTime = 0;
        }

        // 도넛 별 처리
        if (PlayerPrefs.GetInt("Doughnut1") != -1)
        {
            int Price = PlayerPrefs.GetInt("Doughnut1Price");
            int Money = PlayerPrefs.GetInt("Coin");
            int Number = PlayerPrefs.GetInt("Quality");

            Money += Price;

            PlayerPrefs.SetInt("Coin", Money);

            Instantiate(Doughnuts[PlayerPrefs.GetInt("Doughnut1")], this.transform.position, Quaternion.identity);

            PlayerPrefs.SetInt("Doughnut1", -1);
            PlayerPrefs.SetInt("Doughnut1Price", 0);
            PlayerPrefs.SetInt("Quality", Number - 1);

            CustomerCreate.bIsCustomerActive[CustomerNumber] = false;

            Destroy(this.gameObject);
            Destroy(TycoonManager.instance.DoughnutSell[CustomerNumber]);

            TycoonManager.instance.Display.CoinReset();
            TycoonManager.instance.Display.CoinShow();
            TycoonManager.instance.Display.QualityReset();
            TycoonManager.instance.Display.QualityShow();

            return;
        }

        if (PlayerPrefs.GetInt("Doughnut2") != -1)
        {
            int Price = PlayerPrefs.GetInt("Doughnut2Price");
            int Money = PlayerPrefs.GetInt("Coin");
            int Number = PlayerPrefs.GetInt("Quality");

            Money += Price;

            PlayerPrefs.SetInt("Coin", Money);

            Instantiate(Doughnuts[PlayerPrefs.GetInt("Doughnut2")], this.transform.position, Quaternion.identity);

            PlayerPrefs.SetInt("Doughnut2", -1);
            PlayerPrefs.SetInt("Doughnut2Price", 0);
            PlayerPrefs.SetInt("Quality", Number - 1);

            CustomerCreate.bIsCustomerActive[CustomerNumber] = false;

            Destroy(this.gameObject);
            Destroy(TycoonManager.instance.DoughnutSell[CustomerNumber]);

            TycoonManager.instance.Display.CoinReset();
            TycoonManager.instance.Display.CoinShow();
            TycoonManager.instance.Display.QualityReset();
            TycoonManager.instance.Display.QualityShow();

            return;
        }

        if (PlayerPrefs.GetInt("Doughnut3") != -1)
        {
            int Price = PlayerPrefs.GetInt("Doughnut3Price");
            int Money = PlayerPrefs.GetInt("Coin");

            Money += Price;

            PlayerPrefs.SetInt("Coin", Money);

            Instantiate(Doughnuts[PlayerPrefs.GetInt("Doughnut3")], this.transform.position, Quaternion.identity);

            PlayerPrefs.SetInt("Doughnut3", -1);
            PlayerPrefs.SetInt("Doughnut3Price", 0);
            int Number = PlayerPrefs.GetInt("Quality");
            PlayerPrefs.SetInt("Quality", Number - 1);

            CustomerCreate.bIsCustomerActive[CustomerNumber] = false;

            Destroy(this.gameObject);
            Destroy(TycoonManager.instance.DoughnutSell[CustomerNumber]);

            TycoonManager.instance.Display.CoinReset();
            TycoonManager.instance.Display.CoinShow();
            TycoonManager.instance.Display.QualityReset();
            TycoonManager.instance.Display.QualityShow();

            return;
        }

        if (PlayerPrefs.GetInt("Doughnut4") != -1)
        {
            int Price = PlayerPrefs.GetInt("Doughnut4Price");
            int Money = PlayerPrefs.GetInt("Coin");

            Money += Price;

            PlayerPrefs.SetInt("Coin", Money);

            Instantiate(Doughnuts[PlayerPrefs.GetInt("Doughnut4")], this.transform.position, Quaternion.identity);

            PlayerPrefs.SetInt("Doughnut4", -1);
            PlayerPrefs.SetInt("Doughnut4Price", 0);
            int Number = PlayerPrefs.GetInt("Quality");
            PlayerPrefs.SetInt("Quality", Number - 1);

            CustomerCreate.bIsCustomerActive[CustomerNumber] = false;

            Destroy(this.gameObject);
            Destroy(TycoonManager.instance.DoughnutSell[CustomerNumber]);

            TycoonManager.instance.Display.CoinReset();
            TycoonManager.instance.Display.CoinShow();
            TycoonManager.instance.Display.QualityReset();
            TycoonManager.instance.Display.QualityShow();

            return;
        }

        if (PlayerPrefs.GetInt("Doughnut5") != -1)
        {
            int Price = PlayerPrefs.GetInt("Doughnut5Price");
            int Money = PlayerPrefs.GetInt("Coin");

            Money += Price;

            PlayerPrefs.SetInt("Coin", Money);

            Instantiate(Doughnuts[PlayerPrefs.GetInt("Doughnut5")], this.transform.position, Quaternion.identity);

            PlayerPrefs.SetInt("Doughnut5", -1);
            PlayerPrefs.SetInt("Doughnut5Price", 0);
            int Number = PlayerPrefs.GetInt("Quality");
            PlayerPrefs.SetInt("Quality", Number - 1);

            CustomerCreate.bIsCustomerActive[CustomerNumber] = false;

            Destroy(this.gameObject);
            Destroy(TycoonManager.instance.DoughnutSell[CustomerNumber]);

            TycoonManager.instance.Display.CoinReset();
            TycoonManager.instance.Display.CoinShow();
            TycoonManager.instance.Display.QualityReset();
            TycoonManager.instance.Display.QualityShow();

            return;
        }

        if (PlayerPrefs.GetInt("Doughnut6") != -1)
        {
            int Price = PlayerPrefs.GetInt("Doughnut6Price");
            int Money = PlayerPrefs.GetInt("Coin");

            Money += Price;

            PlayerPrefs.SetInt("Coin", Money);

            Instantiate(Doughnuts[PlayerPrefs.GetInt("Doughnut6")], this.transform.position, Quaternion.identity);

            PlayerPrefs.SetInt("Doughnut6", -1);
            PlayerPrefs.SetInt("Doughnut6Price", 0);
            int Number = PlayerPrefs.GetInt("Quality");
            PlayerPrefs.SetInt("Quality", Number - 1);

            CustomerCreate.bIsCustomerActive[CustomerNumber] = false;

            Destroy(this.gameObject);
            Destroy(TycoonManager.instance.DoughnutSell[CustomerNumber]);

            TycoonManager.instance.Display.CoinReset();
            TycoonManager.instance.Display.CoinShow();
            TycoonManager.instance.Display.QualityReset();
            TycoonManager.instance.Display.QualityShow();

            return;
        }

        if (PlayerPrefs.GetInt("Doughnut7") != -1)
        {
            int Price = PlayerPrefs.GetInt("Doughnut7Price");
            int Money = PlayerPrefs.GetInt("Coin");

            Money += Price;

            PlayerPrefs.SetInt("Coin", Money);

            PlayerPrefs.SetInt("Doughnut7", -1);
            PlayerPrefs.SetInt("Doughnut7Price", 0);
            int Number = PlayerPrefs.GetInt("Quality");
            PlayerPrefs.SetInt("Quality", Number - 1);

            Instantiate(Doughnuts[PlayerPrefs.GetInt("Doughnut7")], this.transform.position, Quaternion.identity);

            CustomerCreate.bIsCustomerActive[CustomerNumber] = false;

            Destroy(this.gameObject);
            Destroy(TycoonManager.instance.DoughnutSell[CustomerNumber]);

            TycoonManager.instance.Display.CoinReset();
            TycoonManager.instance.Display.CoinShow();
            TycoonManager.instance.Display.QualityReset();
            TycoonManager.instance.Display.QualityShow();

            return;
        }

        if (PlayerPrefs.GetInt("Doughnut8") != -1)
        {
            int Price = PlayerPrefs.GetInt("Doughnut8Price");
            int Money = PlayerPrefs.GetInt("Coin");

            Money += Price;

            PlayerPrefs.SetInt("Coin", Money);

            Instantiate(Doughnuts[PlayerPrefs.GetInt("Doughnut8")], this.transform.position, Quaternion.identity);

            PlayerPrefs.SetInt("Doughnut8", -1);
            PlayerPrefs.SetInt("Doughnut8Price", 0);
            int Number = PlayerPrefs.GetInt("Quality");
            PlayerPrefs.SetInt("Quality", Number - 1);

            CustomerCreate.bIsCustomerActive[CustomerNumber] = false;

            Destroy(this.gameObject);
            Destroy(TycoonManager.instance.DoughnutSell[CustomerNumber]);

            TycoonManager.instance.Display.CoinReset();
            TycoonManager.instance.Display.CoinShow();
            TycoonManager.instance.Display.QualityReset();
            TycoonManager.instance.Display.QualityShow();

            return;
        }

        if (PlayerPrefs.GetInt("Doughnut9") != -1)
        {
            int Price = PlayerPrefs.GetInt("Doughnut9Price");
            int Money = PlayerPrefs.GetInt("Coin");

            Money += Price;

            PlayerPrefs.SetInt("Coin", Money);

            Instantiate(Doughnuts[PlayerPrefs.GetInt("Doughnut9")], this.transform.position, Quaternion.identity);

            PlayerPrefs.SetInt("Doughnut9", -1);
            PlayerPrefs.SetInt("Doughnut9Price", 0);
            int Number = PlayerPrefs.GetInt("Quality");
            PlayerPrefs.SetInt("Quality", Number - 1);

            CustomerCreate.bIsCustomerActive[CustomerNumber] = false;

            Destroy(this.gameObject);
            Destroy(TycoonManager.instance.DoughnutSell[CustomerNumber]);

            TycoonManager.instance.Display.CoinReset();
            TycoonManager.instance.Display.CoinShow();
            TycoonManager.instance.Display.QualityReset();
            TycoonManager.instance.Display.QualityShow();

            return;
        }

        if (PlayerPrefs.GetInt("Doughnut10") != -1)
        {
            int Price = PlayerPrefs.GetInt("Doughnut10Price");
            int Money = PlayerPrefs.GetInt("Coin");

            Money += Price;

            PlayerPrefs.SetInt("Coin", Money);

            Instantiate(Doughnuts[PlayerPrefs.GetInt("Doughnut10")], this.transform.position, Quaternion.identity);

            PlayerPrefs.SetInt("Doughnut10", -1);
            PlayerPrefs.SetInt("Doughnut10Price", 0);
            int Number = PlayerPrefs.GetInt("Quality") - 1;
            PlayerPrefs.SetInt("Quality", Number);

            CustomerCreate.bIsCustomerActive[CustomerNumber] = false;

            Destroy(this.gameObject);
            Destroy(TycoonManager.instance.DoughnutSell[CustomerNumber]);

            TycoonManager.instance.Display.CoinReset();
            TycoonManager.instance.Display.CoinShow();
            TycoonManager.instance.Display.QualityReset();
            TycoonManager.instance.Display.QualityShow();

            return;
        }

    }
}
