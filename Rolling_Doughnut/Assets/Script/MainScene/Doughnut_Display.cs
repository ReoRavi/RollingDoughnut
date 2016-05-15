using UnityEngine;
using System.Collections;

//=======================================
// Doughnut_Display : 만든 도넛들을 보여주는 UI
public class Doughnut_Display : MonoBehaviour {

    // 만든 도넛들
    public GameObject[] Doughnut;

	// Use this for initialization
	void Awake () {

        print("Hello");
        float X = -6;
        float Y = -4.5F;
        float Z = -3;
        float GapLength  = 1.25F;

        //==============================================================
        // 도넛들을 읽어온다.
        if (PlayerPrefs.GetInt("Doughnut1") != -1)
        {
            int DoughnutLevel = PlayerPrefs.GetInt("Doughnut1");

            Instantiate(Doughnut[DoughnutLevel], new Vector3(X, Y, Z), Quaternion.identity);
            X += GapLength;                                                          
        }                                                                            
                                                                                     
        if (PlayerPrefs.GetInt("Doughnut2") != -1)                                   
        {                                                                            
            Instantiate(Doughnut[PlayerPrefs.GetInt("Doughnut2")], new Vector3(X, Y, Z), Quaternion.identity);
            X += GapLength;                                                          
        }                                                                            
                                                                                     
        if (PlayerPrefs.GetInt("Doughnut3") != -1)                                   
        {                                                                            
            Instantiate(Doughnut[PlayerPrefs.GetInt("Doughnut3")], new Vector3(X, Y, Z), Quaternion.identity);
            X += GapLength;                                                          
        }                                                                            
                                                                                     
        if (PlayerPrefs.GetInt("Doughnut4") != -1)                                   
        {                                                                            
            Instantiate(Doughnut[PlayerPrefs.GetInt("Doughnut4")], new Vector3(X, Y, Z), Quaternion.identity);
            X += GapLength;                                                          
        }                                                                            
                                                                                     
        if (PlayerPrefs.GetInt("Doughnut5") != -1)                                   
        {                                                                            
            Instantiate(Doughnut[PlayerPrefs.GetInt("Doughnut5")], new Vector3(X, Y, Z), Quaternion.identity);
            X += GapLength;                                                          
        }                                                                            
                                                                                     
        if (PlayerPrefs.GetInt("Doughnut6") != -1)                                   
        {                                                                            
            Instantiate(Doughnut[PlayerPrefs.GetInt("Doughnut6")], new Vector3(X, Y, Z), Quaternion.identity);
            X += GapLength;                                                          
        }                                                                            
                                                                                     
        if (PlayerPrefs.GetInt("Doughnut7") != -1)                                   
        {                                                                            
            Instantiate(Doughnut[PlayerPrefs.GetInt("Doughnut7")], new Vector3(X, Y, Z), Quaternion.identity);
            X += GapLength;                                                          
        }                                                                            
        if (PlayerPrefs.GetInt("Doughnut8") != -1)                                   
        {                                                                            
            Instantiate(Doughnut[PlayerPrefs.GetInt("Doughnut8")], new Vector3(X, Y, Z), Quaternion.identity);
            X += GapLength;                                                          
        }                                                                            
                                                                                     
        if (PlayerPrefs.GetInt("Doughnut9") != -1)                                   
        {                                                                            
            Instantiate(Doughnut[PlayerPrefs.GetInt("Doughnut9")], new Vector3(X, Y, Z), Quaternion.identity);
            X += GapLength;
        }

        if (PlayerPrefs.GetInt("Doughnut10") != -1)
        {
            Instantiate(Doughnut[PlayerPrefs.GetInt("Doughnut10")], new Vector3(X, Y, Z), Quaternion.identity);
            X += GapLength;
        }
        //==============================================================
    }
}
