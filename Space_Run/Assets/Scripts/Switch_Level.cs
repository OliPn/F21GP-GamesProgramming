using UnityEngine;
using UnityEngine.SceneManagement;
public class Switch_Level : MonoBehaviour
{
    public GameManager gameManager;     //Inport Game Manager Component
    public int stars_To_Complete = 3;   //Stars To Collect To Finish First Level

    private Score score;    //Used To Get Current Game Score
    private void OnCollisionEnter(Collision collision)  //On Any Collision
    {
        //If Player Has Reached Finish With All Stars
        if (collision.gameObject.tag == "Player" && Score.Score_Val == stars_To_Complete)
        {
            SceneManager.LoadScene("Level002"); //Load Next Level
        }

        //If Player Has Reached Finish Without All Stars
        if (collision.gameObject.tag == "Player" && Score.Score_Val != stars_To_Complete)
        {
            gameManager.collectStars(); //Run collectStars Function From Game Manager
        }
    }
}
