using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int power = 60;
    public int jumpHeight = 1000;
    public bool isFalling = false;
    

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * power);
	}
}
