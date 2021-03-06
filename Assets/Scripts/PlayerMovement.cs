﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public bool moving; // moviendose?
	public float speed; // velicidad

	public void Start()
	{
		moving = false;
	}
	
	private void Update()
	{
		if (moving)
		{
			Movement();
		}
		
		MovementCheck();
	}

	void Movement() // serie de IFs
	{
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World); //space.World en relacion al mundo... muevete
			moving = true;
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World); //space.World en relacion al mundo... muevete
			moving = true;
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World); //space.World en relacion al mundo... muevete
			moving = true;
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World); //space.World en relacion al mundo... muevete
			moving = true;
		}
		if(!Input.GetKey(KeyCode.W)  && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) )
		{
			moving = false;
		}


        
	}

	void MovementCheck()
	{
		if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) &&
		    !Input.GetKey(KeyCode.D))
		{
			moving = false;
		}
		else
		{
			moving = true;
		}
	}

	// Setter
	public void setMoving(bool movement)
	{
		moving = movement;
	}
}
