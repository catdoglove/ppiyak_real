using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoPPiyak : MonoBehaviour {

	public GameObject goPy,goPy_btn;
	public float moveX,moveY;
	int beuk;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (moveX <= -2.4) {
			beuk = 1;
			goPy.transform.rotation = Quaternion.Euler (0,180,0);
		}else if(moveX >= 2.4){
			beuk = 0;
			goPy.transform.rotation = Quaternion.Euler (0,0,0);
		}
		if (beuk == 1) {
			moveX = moveX + 0.01f;
		} else {
			moveX = moveX - 0.01f;
		}
		goPy_btn.transform.position = new Vector3 (moveX, moveY, goPy.transform.position.z);
		
	}
}
