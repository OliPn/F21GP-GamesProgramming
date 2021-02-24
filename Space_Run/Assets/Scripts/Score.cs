using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;  //Input GUI Text Component To Modify Score
    public static int Score_Val = 0;    //Set Initial Score To 0

    void Update()
    {
        scoreText.text = Score_Val.ToString();  //Write Score Value To GUI
    }
}
