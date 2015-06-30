using UnityEngine;
using System.Collections;

public class MainCharacterBehaviour : MonoBehaviour {

	public GameObject gameGround;
	public Vector3 speed;
	protected Animator animator;
	public Vector2 movingForce;
	public Vector2 jumpForce;
	
	// Use this for initialization
	void Start () {
		speed = new Vector3 (3, 0, 0);
		movingForce = new Vector2 (10, 0);
		jumpForce = new Vector2 (0, 50);
		animator = gameObject.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

		//Switch states
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
		{
			Debug.Log("Running...");
			animator.SetBool("isIdle", false);
			animator.SetBool("isRunning", true);
		}
		else
		{
			Debug.Log("Idle...");
			animator.SetBool("isRunning", false);
			animator.SetBool("isIdle", true);
		}


		Vector3 localScale = transform.localScale;
		//Translation$
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			gameObject.transform.Translate (-speed * Time.deltaTime);
			if (localScale.x > 0)
			{
				localScale.x *= -1.0f;
			}
		}
		
		if (Input.GetKey(KeyCode.RightArrow))
		{
			gameObject.transform.Translate (speed * Time.deltaTime);
			if (localScale.x < 0)
			{
				localScale.x *= -1.0f;
			}
		}
		transform.localScale = localScale;

	}

	void FixedUpdate()
	{ 
		Vector3 localScale = transform.localScale;
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			rigidbody2d.AddForce(-movingForce);
			if(localScale.y > 0)
			{
				localScale.y *=-1.0f;
			}
		}
	}
	void OnDestroy()
	{

	}
}
