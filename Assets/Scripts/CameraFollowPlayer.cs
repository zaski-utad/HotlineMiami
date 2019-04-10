using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
	GameObject player;
	PlayerMovement pm;

	Vector3 mousePos;
	Camera cam;
	
	public bool followPlayer;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		pm = player.GetComponent<PlayerMovement>();
		cam = Camera.main;
	}
	
	void Update ()
	{
		//camFollowPlayer();
		followCursor();
	}

	void camFollowPlayer()
	{
		Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
		this.transform.position = newPos;
	}

	void followCursor()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			followPlayer = false;
			pm.setMoving(false);
		}
		else
		{
			followPlayer = true;
		}

		if (followPlayer)
		{
			camFollowPlayer();
		}
		else
		{
			lookAhead();
		}
	}

	void lookAhead()
	{
		Vector3 camPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
		camPos.z = -10;
		Vector3 dir = camPos - this.transform.position;
		
		//Condition that determines when the camera stops looking ahead
		if (player.GetComponent<SpriteRenderer>().isVisible)
		{
			transform.Translate(dir * 2 * Time.deltaTime);
		}
	}
}
