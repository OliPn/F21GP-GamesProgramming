using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float message_Delay = 1f;    //Set Time (s) For Game Messages
    public Text winText;    //Used To Change GUI Text

    bool gameEnded = false; //Used So Game Can Only Be Ended Once
    public void gameOver()  //On Game Over Condition
    {
        if(gameEnded == false)  //Only If Game Hasn't Already Ended
        {
            gameEnded = true;   //Set Game Ended
            winText.text = ("You Lose");    //Display Game Message
            Invoke("Restart", message_Delay);   //Restart Game After Defined Delay
        }
    }
    public void completeLevel() //On Winning Game
    {
        winText.text = ("You Win!");    //Display Game Message
        Invoke("Restart", message_Delay);   //Restart Game After Defined Delay
    }

    void Restart()  //On Game Restart
    {
        winText.text = ("");    //Clear Game Message
        Score.Score_Val = 0;    //Reset Score
        SceneManager.LoadScene("Level001"); //Load 1st Level
    }

    public void collectStars()  //On Player Not Collecting All Stars
    {
        winText.text = ("Collect All Stars!");  //Display Game Message
        Invoke("clearTxt", message_Delay);  //Clear Message After Defined Delay
    }

    void clearTxt() //On Needing To Clear Game Message
    {
        winText.text = ("");    //Clear Game Message
    }
}
