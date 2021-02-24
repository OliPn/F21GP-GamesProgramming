using UnityEngine;
public class Player_Collision : MonoBehaviour
{
    public Player_Movement movement;    //Access Player Movement Script
    public Animator anim;               //Acess Animator Component
    private void OnCollisionEnter(Collision collision)  //On Any Collision
    {
        if(collision.collider.tag == "Enemy")   //If Collided With An Enemy
        {
            movement.enabled = false;       //Disable All Player Movement
            anim.SetFloat("Forward", 0f);   //Set Animation To Idle
            anim.SetFloat("Right", 0f);     //Set Animation To Idle

            FindObjectOfType<GameManager>().gameOver(); //Run gameOver Function From Game Manager
        }
    }
}
