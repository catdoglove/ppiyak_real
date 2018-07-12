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

	public GameObject gameBack_obj, gameBottom_obj, gameIncubator1_obj,gameIncubator2_obj, titleImage_obj;
	public Sprite[] back_spr, bottom_spr, incubator_spr;

	//돈
	public int gameCoin_i;

	void Awake(){
		for (int i = 0; i < 20; i++) {
			i++;
			back_spr[i-1]=Resources.Load<Sprite>("thema/bg("+i+")");
			bottom_spr[i-1]=Resources.Load<Sprite>("thema/fl("+i+")");
			incubator_spr[i-1]=Resources.Load<Sprite>("thema/pipe("+i+")");
			i--;
		}
	}

    public void closeTitle()
    {
        titleImage_obj.SetActive(false);
    }

<<<<<<< HEAD
	// Use this for initialization
	void Start () {
		//게임시작_화면의 배경,부화기,바닥을 저장된값으로변경
		int cash_i = PlayerPrefs.GetInt ("backset",-1);
		gameBack_obj.GetComponent<Image> ().sprite = back_spr [cash_i+1];
		cash_i = PlayerPrefs.GetInt ("bottomset",-1);
		gameBottom_obj.GetComponent<Image> ().sprite = bottom_spr [cash_i+1];
		cash_i = PlayerPrefs.GetInt ("incubatorset",-1);
		gameIncubator1_obj.GetComponent<Image> ().sprite = incubator_spr [cash_i+1];
		gameIncubator2_obj.GetComponent<Image> ().sprite = incubator_spr [cash_i+1];

	}
=======
>>>>>>> 807ae8af5f1d9c0cb820bdb3da9e49314ddaf2b2

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

	//코루틴
	#region

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

	#endregion
}
