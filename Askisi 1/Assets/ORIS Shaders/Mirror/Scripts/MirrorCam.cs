using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCam : MonoBehaviour {
	
    [SerializeField]
    Transform mirrorCam, playerCam;

	void Update(){
		Vector3 dir = (playerCam.position - transform.position).normalized;
		Quaternion rot = Quaternion.LookRotation (dir);
		rot.eulerAngles = transform.eulerAngles - rot.eulerAngles;
		mirrorCam.localRotation = rot;
	}
}
