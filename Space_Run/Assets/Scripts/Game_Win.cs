using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Win : MonoBehaviour
{
    public GameManager gameManager;         //Reference To Game Manager Object
    public int stars_To_Complete = 8;       //Number Of Stars Collected To Win

    private Score score;    //Used To Obtain Current Game Score
    private void OnCollisionEnter(Collision collision)  //On Any Collision
    {
        //If Player Has Reached Finish And All Stars Collected
        if (collision.gameObject.tag == "Player" && Score.Score_Val == stars_To_Complete)   
        {
            gameManager.completeLevel();    //Run completeLevel Function In Game Manager
        }

        //If Player Has Reached Finish And Not All Stars Are Collected
        if (collision.gameObject.tag == "Player" && Score.Score_Val != stars_To_Complete)
        {
            gameManager.collectStars(); //Run collectStars Function In Game Manager
        }
    }
}
