using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float movePower = 4f;
	public float jumpPower = 4f;

	Rigidbody2D rigid;

	Vector3 movement;
	bool isJumping = false;
	bool canJump = true;

	//---------------------------------------------------[Override Function]
	//Initialization
	void Start()
	{
		rigid = gameObject.GetComponent<Rigidbody2D>();
	}

	//Graphic & Input Updates	
	void Update()
	{
		if (Input.GetAxisRaw("Vertical")>0 && canJump == true)
		{
			isJumping = true;
			canJump = false;
		}
	}

	//Physics engine Updates
	void FixedUpdate()
	{
		Move();
		Jump();

	}

	//---------------------------------------------------[Movement Function]

	void Move()
	{
		Vector3 moveVelocity = Vector3.zero;

		if (Input.GetAxisRaw("Horizontal") < 0)
		{
			moveVelocity = Vector3.left;
		}

		else if (Input.GetAxisRaw("Horizontal") > 0)
		{
			moveVelocity = Vector3.right;
		}

		transform.position += moveVelocity * movePower * Time.deltaTime;
	}

	void Jump()
	{
		if (!isJumping)
			return;

		//Prevent Velocity amplification.
		rigid.velocity = Vector2.zero;

		Vector2 jumpVelocity = new Vector2(0, jumpPower);
		rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

		isJumping = false;
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.CompareTag("Killer"))
			SceneManager.LoadScene("test");
		canJump = true;
    }
	
}
