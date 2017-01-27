using UnityEngine;
using System.Collections;

public class VampScript : MonoBehaviour {
	bool isFacingRight = true;
	public float maxspeed = 10f;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("speed", Mathf.Abs (move));
		GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxspeed,GetComponent<Rigidbody2D>().velocity.y);
		if (move > 0 && !isFacingRight)
			Flip ();
		else if (move < 0 && isFacingRight)
			Flip ();
	}



	protected void Flip()    
	{
		isFacingRight = !isFacingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
}
