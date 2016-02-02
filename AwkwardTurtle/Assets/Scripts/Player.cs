using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Player : MonoBehaviour {


    public int jumpHeight = 1000;
    public bool isFalling = false;

    //Set the initial direction to 'normal' physics, downward gravity and moving right
    private  static Vector2 playerDirection = new Vector2(Constants.VECTOR_RIGHT, Constants.VECTOR_DOWN);
    private int power = 60;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().AddForce(playerDirection * power);
	}

    /// <summary>
    /// update the direction of the player
    /// </summary>
    /// <param name="x">either VECTOR_RIGHT or VECTOR_LEFT</param>
    /// <param name="y">either VECTOR_DOWN or VECTOR_UP</param>
    public static void UpdateDirection(float x, float y)
    {
        playerDirection.x = x;
        playerDirection.y = y;
    }

    /// <summary>
    /// Update the speed of the player
    /// </summary>
    /// <param name="newPower">new speed </param>

    public void UpdatePower(int newPower)
    {
        power = newPower;
    }

}
