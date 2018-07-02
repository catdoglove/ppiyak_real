using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEvt : MonoBehaviour {
	//이전씬에서로드된데이터가져오기
	public GameObject GM;
	public int eggRare_i, touchNum_i, maxNum_i,eggIndex_i;
	public GameObject[] ppiyak_obj;
	public Sprite[] ppiyakBasic_spr,ppiyakGood_spr,ppiyakAwesome_spr;
	public Sprite egg_spr;

	int c_Num;

	void Awake(){
		//스프라이트동적할당
		ppiyakBasic_spr = Resources.LoadAll<Sprite> ("ppiyak/ppiyak_01(170x130)");
		ppiyakGood_spr = Resources.LoadAll<Sprite> ("ppiyak/ppiyak_02(170x130)");
		ppiyakAwesome_spr = Resources.LoadAll<Sprite> ("ppiyak/ppiyak_03(170x130)");
	}

	// Use this for initialization
	void Start () {

		//GM = GameObject.FindGameObjectWithTag ("GameObject");
		//각각병아리별로이름을 받아오기
		//자신의 이름을 불러옴
		string str=this.gameObject.name;
		//자신의 이름에 달린 번호를 불러옴
		if (str.Length > 3) {
			c_Num = int.Parse (str.Substring (5)) - 1;
			//번호별로 저장된값 불러옴
			eggRare_i = PlayerPrefs.GetInt ("rare" + c_Num, 0);
			maxNum_i = PlayerPrefs.GetInt ("max"+c_Num,5);
			touchNum_i = PlayerPrefs.GetInt ("touch" + c_Num, 0);
			eggIndex_i = PlayerPrefs.GetInt ("index"+c_Num,0);
			//병아리이미지 바꾸기
			if (touchNum_i == -1) {
				ppiyakChange ();
			}
		}

	}
	


	public void touchEgg (){

		if (touchNum_i == -1) {
			eggRare_i = Random.Range (0, 3);
			int rand = 1;
			switch (eggRare_i) {
			case 0:
				rand = PlayerPrefs.GetInt ("basic_unlock", 6);
				eggIndex_i = Random.Range (0,rand);
				maxNum_i = Random.Range (2, 5);
				break;
			case 1:
				rand = PlayerPrefs.GetInt ("good_unlock",8);
				eggIndex_i = Random.Range (0,rand);
				maxNum_i = Random.Range (5, 7);
				break;
			case 2:
				rand = PlayerPrefs.GetInt ("awesome_unlock",7);
				eggIndex_i = Random.Range (0,rand);
				maxNum_i = Random.Range (8, 10);
				break;
			case 3:
				maxNum_i = Random.Range (11, 21);
				break;
			}
			PlayerPrefs.SetInt ("index" + c_Num, eggIndex_i);
			PlayerPrefs.SetInt ("rare" + c_Num, eggRare_i);
			PlayerPrefs.SetInt ("max"+c_Num,maxNum_i);
		}
		
		//번호별로 저장된값 불러옴
		eggRare_i = PlayerPrefs.GetInt ("rare" + c_Num, 0);
		maxNum_i = PlayerPrefs.GetInt ("max"+c_Num,5);
		touchNum_i = PlayerPrefs.GetInt ("touch" + c_Num, 0);
		eggIndex_i = PlayerPrefs.GetInt ("index"+c_Num,0);
		//누르면알로바뀜
		touchNum_i++;
		PlayerPrefs.SetInt ("touch" + c_Num, touchNum_i);

		GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().egg_spr;

		//터치수가채워지면부화
		if (touchNum_i >= maxNum_i) {
			//부화됨터치횟수초기화하고다음알의희귀도를지정
			touchNum_i =-1;
			PlayerPrefs.SetInt ("touch" + c_Num, touchNum_i);
			//병아리이미지변경
			ppiyakChange ();
			//도감저장
			//PlayerPrefs.SetInt ("books"+eggRare_i,1);

		}
		PlayerPrefs.Save ();

	}

	void ppiyakChange(){
		//부화 병아리이미지로 변경
		switch (eggRare_i) {
		case 0:
			GM.GetComponent<GameEvt> ().ppiyak_obj [c_Num].GetComponent<Image> ().sprite = GM.GetComponent<GameEvt> ().ppiyakBasic_spr [eggIndex_i];
			//PlayerPrefs.SetInt ("basic_book"+eggIndex_i,1);
			break;
		case 1:
			GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().ppiyakGood_spr [eggIndex_i];
			//PlayerPrefs.SetInt ("good_book"+eggIndex_i,1);
			break;
		case 2:
			GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().ppiyakAwesome_spr [eggIndex_i];
			//PlayerPrefs.SetInt ("awesome_book"+eggIndex_i,1);
			break;
		case 3:
			GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().ppiyakAwesome_spr [1];
			break;
		}
	}
		
	void ppiyakChangeEgg(){
		
	}
}
