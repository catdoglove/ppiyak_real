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

	//처음시작
	string str;

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


	// Use this for initialization
	void Start () {
		//게임을처음시작했을때고유아이디를준다.
		//처음할때 자신만의 코드를 만들어줌
		int c=0;
		if (c == PlayerPrefs.GetInt ("first", 0)) {
			for (int i = 0; i < 16; i++) {
				int a = Random.Range (0, 16);//0~15

				switch (a) {
				case 0:
					str = str + "0";
					break;
				case 1:
					str = str + "1";
					break;
				case 2:
					str = str + "2";
					break;
				case 3:
					str = str + "3";
					break;
				case 4:
					str = str + "4";
					break;
				case 5:
					str = str + "5";
					break;
				case 6:
					str = str + "6";
					break;
				case 7:
					str = str + "7";
					break;
				case 8:
					str = str + "8";
					break;
				case 9:
					str = str + "9";
					break;
				case 10:
					str = str + "a";
					break;
				case 11:
					str = str + "b";
					break;
				case 12:
					str = str + "c";
					break;
				case 13:
					str = str + "d";
					break;
				case 14:
					str = str + "e";
					break;
				case 15:
					str = str + "f";
					break;
				default:
					break;
				}

				//코인이 저장되는 이름을 자기의 코드로해줌
			}

			PlayerPrefs.SetString ("code", str);
			PlayerPrefs.SetInt ("first", 1);
			PlayerPrefs.Save ();
		}//endOfIf

		str = PlayerPrefs.GetString ("code", "");
		gameCoin_i = PlayerPrefs.GetInt (str, 0);
		//PlayerPrefs.SetInt (str, 0);

		//게임시작_화면의 배경,부화기,바닥을 저장된값으로변경
		int cash_i = PlayerPrefs.GetInt ("backset",-1);
		gameBack_obj.GetComponent<Image> ().sprite = back_spr [cash_i+1];
		cash_i = PlayerPrefs.GetInt ("bottomset",-1);
		gameBottom_obj.GetComponent<Image> ().sprite = bottom_spr [cash_i+1];
		cash_i = PlayerPrefs.GetInt ("incubatorset",-1);
		gameIncubator1_obj.GetComponent<Image> ().sprite = incubator_spr [cash_i+1];
		gameIncubator2_obj.GetComponent<Image> ().sprite = incubator_spr [cash_i+1];

	}

    void Update()
    {
        //나가기
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
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
