using UnityEngine;
public class Player_Movement : MonoBehaviour
{

    public Rigidbody player_rb; //Input Players Rigidbody Component
    public Animator anim;       //Input Players Animation Component

    public float speed = 4;         //Set Player Movement Speed
    public float turnSpeed = 4;     //Set Player Rotation Speed
    public float playerFall = -1;   //Has Player Fallen Off Map

    private bool jumpPressed;       //Holds Jump Button Status
    private bool onGround = true;   //Determines If Player Is Touching The Map
    void OnCollisionEnter(Collision collision)  //On Any Collision
    {
        if (collision.gameObject.name == "Ground")  //If Collision Is With Map
        {
            onGround = true;    //Set Player On Ground
        }
    }
    void Update()
    {

        float x_Axis = Input.GetAxis("Horizontal"); //Read Defined Horizontal Keyboard
        float z_Axis= Input.GetAxis("Vertical");    //Read Defined Vertical Keyboard

        //Move Player To New Coordinates (deltaTime Due To Framerate Variations)
        transform.Translate(new Vector3(x_Axis * speed, 0, z_Axis * speed) * Time.deltaTime);   

        float turn = Input.GetAxis("Mouse X");  //Read Current Mouse X Axis Value

        //Turn Player To Mouse Position (Direction Is Dependent On If Mouse Value Is Positive Or Negative)
        //Slerp Is Used To Interpolate The Values Giving A Smoother Responce
        transform.rotation *= Quaternion.Slerp(Quaternion.identity, Quaternion.LookRotation(turn < 0 ? Vector3.left : Vector3.right), Mathf.Abs(turn) * turnSpeed * Time.deltaTime);

        //Set Animation Perameters
        anim.SetFloat("Forward", z_Axis);   
        anim.SetFloat("Right", x_Axis);     

        if(Input.GetKeyDown(KeyCode.Space)) //If Jump Key (Space) Is Pressed
        {
            jumpPressed = true; //Set Jump Variable True
        }
    }

    private void FixedUpdate()
    {
        if(jumpPressed == true && onGround == true) //If Jump Pressed And Character Is Currently On The Ground
        {
            player_rb.AddForce(Vector3.up * 5, ForceMode.VelocityChange);   //Apply Upwards Force To Lift Player
            jumpPressed = false;    //Reset Jump Status
            onGround = false;   //Player No Longer On Ground
        }

        if (player_rb.position.y < playerFall)  //If Player Falls Off Map
        {
            FindObjectOfType<GameManager>().gameOver(); //Run gameOver Function From Game Manager
        }
    }
}
