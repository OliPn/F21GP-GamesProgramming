using UnityEngine;
public class Star : MonoBehaviour
{
    public int rotateSpeed = 1; //Set Star Rotation Speed
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);   //Rotate On Y-Axis In World Space
    }
    private void OnCollisionEnter(Collision collision)  //On Any Collision
    {
        if (collision.transform.name == "Player")   //If Collided With Player
        {
            Score.Score_Val += 1;   //Increase Score
            Destroy(gameObject);    //Remove Star Object From Map
        }
    }
}
