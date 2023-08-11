using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float speed;
	private float jumpForce=40f;

	private bool isGrounded;
	private float timer;
	private Rigidbody2D body;
	
	private void Awake(){
		body = GetComponent<Rigidbody2D>();
	}
	
	private void Update(){

		
		if (Input.GetKeyDown(KeyCode.Space)){
			timer = Time.time;
		}
        
		if(Input.GetKeyUp(KeyCode.Space)){
				if (Time.time-timer<1){
					timer = 1;
				}
				else{
					timer = Time.time-timer;
				}
				body.velocity = new Vector2(body.velocity.x, jumpForce*timer);
		}

		if (!Input.GetKey(KeyCode.Space)) {
			float horizontalInput = Input.GetAxisRaw("Horizontal");
			body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
			
			if(horizontalInput> 0.01f){
				transform.localScale = new Vector3(7,7,1);
			}
			else if(horizontalInput< -0.01f){
				transform.localScale = new Vector3(-7,7,1);
			}
		}

		//if (Input.GetKeyUp(KeyCode.Space)){
		//	body.velocity = new Vector2(body.velocity.x, jumpForce);
		//}
		
	}
	
}