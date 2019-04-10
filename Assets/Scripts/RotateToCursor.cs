using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour
{
	Vector3 mousePos;
	Rigidbody2D rid;
	Camera cam;
	
	void Start ()
	{
		rid = this.GetComponent<Rigidbody2D>(); // this = Player object this Script is added to
		cam = Camera.main;
	}
	
	void Update () {
		RotateToCamera();
	}

	void RotateToCamera()
	{
		mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,Input.mousePosition.z - cam.transform.position.z));
		rid.transform.eulerAngles = new Vector3(0,0, Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg);
	}
}
