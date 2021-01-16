using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour {

	public float speedH = 2.0f;
	public float speedV = 2.0f;
	public float speed = 10.0f;

	float yaw = 0.0f;
	float pitch = 0.0f;

	void Update () {
		yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");
		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

		if(Input.GetKey("w")) transform.Translate(Vector3.forward * speed * Time.deltaTime);
		if(Input.GetKey("s")) transform.Translate(-Vector3.forward * speed * Time.deltaTime);
		if(Input.GetKey("d")) transform.Translate(Vector3.right * speed * Time.deltaTime);
		if(Input.GetKey("a")) transform.Translate(-Vector3.right * speed * Time.deltaTime);
		if(Input.GetKey("space")) transform.Translate(Vector3.up * speed * Time.deltaTime);
		if(Input.GetKey("c")) transform.Translate(-Vector3.up * speed * Time.deltaTime);

	}
}

