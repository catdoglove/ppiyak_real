using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBtnEvt : MonoBehaviour {
	public GameObject[] gameButtons_obj;
	//페이드
	Color color;
	float fade_f;
	float buttonPos_f;
	int buttonList_i=0;

	public GameObject back_obj, bottom_obj, incubator_obj;


	// Use this for initialization
	void Start () {
		

	}

	public void openButton(){
		if (buttonList_i == 0) {
			StopCoroutine ("btnMoveBack");
			StopCoroutine ("imgFadeOut");
			StartCoroutine ("btnMove");
			StartCoroutine ("imgFadeIn");
			buttonList_i = 1;
		} else {
			StopCoroutine ("btnMove");
			StopCoroutine ("imgFadeIn");
			StartCoroutine ("btnMoveBack");
			StartCoroutine ("imgFadeOut");
			buttonList_i = 0;
		}
	}

	IEnumerator btnMove(){
		while (gameButtons_obj[0].transform.position.x <= 1.99f)
		{
			yield return new WaitForSeconds(0.03f);		

			for (int i = 0; i < 3; i++) {
				switch (i) {
				case 0:
					buttonPos_f = 2f;
					break;
				case 1:
					buttonPos_f = 0.6f;
					break;
				case 2:
					buttonPos_f = -0.8f;
					break;
				}
				gameButtons_obj [i].transform.position = Vector2.Lerp (gameButtons_obj [i].transform.position, new Vector2 (buttonPos_f, gameButtons_obj [i].transform.position.y), 20f * Time.deltaTime);
			}
		}
	}

	IEnumerator imgFadeIn(){
		for (int i = 0; i < 3; i++) {
			color = gameButtons_obj [i].GetComponent<Image> ().color;	
		}
		for (float i = 0f; i < 2f; i += 0.1f) {
			//Debug.Log (i);
			color.a = Mathf.Lerp (0f, 1f, i);
			for (int j = 0; j < 3; j++) {
				gameButtons_obj [j].GetComponent<Image> ().color = color;
			}
			yield return null;
		}
		//infoCardWid.SetActive (false);
	}


	IEnumerator btnMoveBack(){

		while (gameButtons_obj[0].transform.position.x >= -2.19f)
		{
			yield return new WaitForSeconds(0.03f);		
			for (int i = 0; i < 3; i++) {
				gameButtons_obj [i].transform.position = Vector2.Lerp (gameButtons_obj [i].transform.position, new Vector2 (-2.2f, gameButtons_obj [i].transform.position.y), 20f * Time.deltaTime);
			}
		}
	}


	IEnumerator imgFadeOut(){
		for (int i = 0; i < 3; i++) {
			color = gameButtons_obj [i].GetComponent<Image> ().color;	
		}
		for (float i = 1f; i > -1f; i -= 0.1f) {
			//Debug.Log (i);
			color.a = Mathf.Lerp (0f, 1f, i);
			for (int j = 0; j < 3; j++) {
				gameButtons_obj [j].GetComponent<Image> ().color = color;
			}
			yield return null;
		}
		//infoCardWid.SetActive (false);
	}
}
