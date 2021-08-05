using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour {
	// private const float DEADZONE = 10.0f;
	private const float MAXIMUM_PULL = 100.0f;
	private bool isBreakingStuff;
	private Rigidbody2D rigid;
	public float speed = 10.0f;
	public Transform ballsPreview;
	private void Start()
	{
		rigid = GetComponent<Rigidbody2D>();
		ballsPreview.parent.gameObject.SetActive(false);
	}
	private void Update()
	{
		if(!isBreakingStuff){
			PoolInput();
		}
	}
	private void PoolInput()
	{
		// Debug.Log(MobileInput.Instance.swipeDelta);
		Vector3 sd = MobileInput.Instance.swipeDelta;
		if(sd != Vector3.zero)
		{
			if(sd.y < 0)
			{
				ballsPreview.parent.gameObject.SetActive(false);
			}
			else
			{
				ballsPreview.parent.up = sd.normalized;
				ballsPreview.parent.gameObject.SetActive(true);
				ballsPreview.localScale = Vector3.Lerp(new Vector3(0.1f, 1, 1), new Vector3(0.1f, 2, 1), sd.magnitude / MAXIMUM_PULL);

				if(MobileInput.Instance.release)
				{
					isBreakingStuff = true;
					SendBallInDirection(sd.normalized);
					ballsPreview.parent.gameObject.SetActive(false);
				}
			}
		}
	}
	// }
	// private void ShootBall(Vector3 dir)
	// {
	// 	isBreakingStuff = true;
	// 	rigid.velocity = dir * speed;
	// }
	private void SendBallInDirection(Vector3 dir)
	{
		rigid.velocity = dir * speed;
	
	}
	// private void OnCollisionEnter2D(Collision2D wall)
	// {
	// 	Vector3 wallPoint = wall.contacts[0].normal;
	// 	Debug.Log("Wall"+wallPoint);
	// 	Vector3 newDirection = Vector3.Reflect(rigid.velocity.normalized, wallPoint.normalized);
	// 	Debug.Log(newDirection);
	// 	SendBallInDirection(newDirection);
	// }
}
