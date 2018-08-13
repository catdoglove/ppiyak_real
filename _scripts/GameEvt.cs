﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEvt : MonoBehaviour {
	//이전씬에서로드된데이터가져오기
	public GameObject GM;
	public int eggRare_i, touchNum_i, maxNum_i,eggIndex_i;
	public GameObject[] ppiyak_obj;
	public Sprite[] ppiyakBasic_spr,ppiyakGood_spr,ppiyakAwesome_spr;
	public Sprite[] egg_spr;
	public GameObject eggPopup_obj;

	public int c_Num;
	int addCoin;

	public int fever;

	//광고시간
	System.DateTime nowAdTime;
	System.DateTime lastDateAdTime;
	System.TimeSpan compareAdTime;
	string lastAdTime;
	public Text AdTime_txt;
	public GameObject AdTime_obj;
	int sG,mG;
	public GameObject adTimeBackImg_obj;

	void Awake(){
		//스프라이트동적할당
		ppiyakBasic_spr = Resources.LoadAll<Sprite> ("ppiyak/ppiyak_01(170x130)");
		ppiyakGood_spr = Resources.LoadAll<Sprite> ("ppiyak/ppiyak_02(170x130)");
		ppiyakAwesome_spr = Resources.LoadAll<Sprite> ("ppiyak/ppiyak_03(170x130)");
		egg_spr = Resources.LoadAll<Sprite> ("ppiyak/egg(110x120)");
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
				addCoin = 0;
			} else {
				ppiyakChangeEgg ();
			}
		}

	}


	public void eggNum1(){
		c_Num = 0;
	}
	public void eggNum3(){
		c_Num = 2;
	}


	public void touchEgg (){
		touchNum_i = PlayerPrefs.GetInt ("touch" + c_Num, 0);
		//-1일때알이부화되어있다 이때터치하면새로운랜덤변수들을정해준다
		if (touchNum_i == -1) {
			touchNum_i++;
			PlayerPrefs.SetInt ("touch" + c_Num, touchNum_i);
			PlayerPrefs.Save ();
			eggPopup_obj.SetActive (true);
		} else {
		
			//번호별로 저장된값 불러옴
			eggRare_i = PlayerPrefs.GetInt ("rare" + c_Num, 0);
			maxNum_i = PlayerPrefs.GetInt ("max" + c_Num, 5);
			touchNum_i = PlayerPrefs.GetInt ("touch" + c_Num, 0);
			eggIndex_i = PlayerPrefs.GetInt ("index" + c_Num, 1);


			touchNum_i++;
			if (fever > 0) {
				touchNum_i++;
                fever = fever - 2;
            }

			PlayerPrefs.SetInt ("touch" + c_Num, touchNum_i);



			//터치수가채워지면부화
			if (touchNum_i >= maxNum_i) {
				//부화됨터치횟수초기화하고다음알의희귀도를지정
				touchNum_i = -1;
				PlayerPrefs.SetInt ("touch" + c_Num, touchNum_i);
				//병아리이미지변경
				ppiyakChange ();
				string str = PlayerPrefs.GetString ("code", "");
				GM.GetComponent<GameBtnEvt> ().gameCoin_i = PlayerPrefs.GetInt (str, 0);
				//효과
				if (PlayerPrefs.GetInt ("beffect_set", 0) >= 3) {
					addCoin = addCoin + 1;
					if (PlayerPrefs.GetInt ("beffect_set", 0) >= 6) {
						addCoin = addCoin + 4;
						if (PlayerPrefs.GetInt ("beffect_set", 0) >= 9) {
							addCoin = addCoin + 5;
							if (PlayerPrefs.GetInt ("beffect_set", 0) >= 13) {
								addCoin = addCoin + 5;
								if (PlayerPrefs.GetInt ("beffect_set", 0) >= 16) {
									addCoin = addCoin + 5;
								}
							}
						}
					}
					if (maxNum_i < 0) {
						maxNum_i = 1;
					}
				}

				GM.GetComponent<GameBtnEvt> ().gameCoin_i = GM.GetComponent<GameBtnEvt> ().gameCoin_i + addCoin;
				PlayerPrefs.SetInt (str, GM.GetComponent<GameBtnEvt> ().gameCoin_i);
				PlayerPrefs.Save ();

			} else {
				ppiyakChangeEgg ();
			}
			PlayerPrefs.Save ();
		}
	}

	void ppiyakChange(){
		//부화 병아리이미지로 변경
		switch (eggRare_i) {
		case 0:
			GM.GetComponent<GameEvt> ().ppiyak_obj [c_Num].GetComponent<Image> ().sprite = GM.GetComponent<GameEvt> ().ppiyakBasic_spr [eggIndex_i];
			addCoin = 100;
			PlayerPrefs.SetInt ("basic_book"+(eggIndex_i-1),1);
			break;
		case 1:
			addCoin = 500;
			GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().ppiyakGood_spr [eggIndex_i];
			PlayerPrefs.SetInt ("good_book"+eggIndex_i,1);
			break;
		case 2:
			addCoin = 1000;
			GM.GetComponent<GameEvt> ().ppiyak_obj [c_Num].GetComponent<Image> ().sprite = GM.GetComponent<GameEvt> ().ppiyakAwesome_spr [eggIndex_i];
			PlayerPrefs.SetInt ("awesome_book" + eggIndex_i, 1);
			break;
		case 3:
			GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().ppiyakAwesome_spr [1];
			break;
		}
	}
		
	void ppiyakChangeEgg(){
		int rands = PlayerPrefs.GetInt ("eggrare"+c_Num,0);

		switch (eggRare_i) {
		case 0:
			GM.GetComponent<GameEvt> ().ppiyak_obj [c_Num].GetComponent<Image> ().sprite = GM.GetComponent<GameEvt> ().egg_spr [rands];
			break;
		case 1:
			GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().egg_spr [rands];
			break;
		case 2:
			GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().egg_spr [rands];
			break;
		case 3:
			GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().egg_spr [1];
			break;
		}
	}


	public void eggOk(){
		eggRare_i = Random.Range (0, 100);
		if (eggRare_i >= 90) {
			eggRare_i = 2;

		} else if (eggRare_i >= 65) {
			eggRare_i = 1;
		} else {
			eggRare_i = 0;
		}
		//eggRare_i = Random.Range (0, 3);
		//알나오는 확률

		int rand = 1;
		int rands = 0;
		int eff;
		switch (eggRare_i) {
		case 0:
			rand = PlayerPrefs.GetInt ("basic_unlock", 6);
			eggIndex_i = Random.Range (1, rand);
			//효과
			eff = PlayerPrefs.GetInt ("effect_set", 0) + 1;

			if (eff != eggIndex_i) {
				eggIndex_i = Random.Range (0, rand);
			}
			if (eff != eggIndex_i) {
				eggIndex_i = Random.Range (0, rand);
			}
			if (eff != eggIndex_i) {
				eggIndex_i = Random.Range (0, rand);
			}
			if (eff != eggIndex_i) {
				eggIndex_i = Random.Range (0, rand);
			}
			if (eff != eggIndex_i) {
				eggIndex_i = Random.Range (0, rand);
			}

			rands = Random.Range (0, 2);
			maxNum_i = Random.Range (2, 10); //★100
			break;
		case 1:
			rand = PlayerPrefs.GetInt ("good_unlock",8);
			eggIndex_i = Random.Range (0,rand);
			//효과
			eff = PlayerPrefs.GetInt ("effect_set", 0)-5;

			if (eff != eggIndex_i) {
				eggIndex_i = Random.Range (0, rand);
			}
			if (eff != eggIndex_i) {
				eggIndex_i = Random.Range (0, rand);
			}
			if (eff != eggIndex_i) {
				eggIndex_i = Random.Range (0, rand);
			}
			if (eff != eggIndex_i) {
				eggIndex_i = Random.Range (0, rand);
			}
			if (eff != eggIndex_i) {
				eggIndex_i = Random.Range (0, rand);
			}
			if (eff != eggIndex_i) {
				eggIndex_i = Random.Range (0, rand);
			}
			if (eff != eggIndex_i) {
				eggIndex_i = Random.Range (0, rand);
			}
			if (eff != eggIndex_i) {
				eggIndex_i = Random.Range (0, rand);
			}

			rands = Random.Range (2, 2);
			maxNum_i = Random.Range (5, 10); //★200
			break;
		case 2:
			rand = PlayerPrefs.GetInt ("awesome_unlock",7);
			eggIndex_i = Random.Range (0,rand);
			//효과
			eff = PlayerPrefs.GetInt ("effect_set", 0)-13;

			if(eff>0){
				eggIndex_i = eff;
			}

			rands = Random.Range (4, 2);
			maxNum_i = Random.Range (8, 10); //★500
			break;
		case 3:
			maxNum_i = Random.Range (11, 21);
			break;
		}
		//효과
		if (PlayerPrefs.GetInt ("ieffect_set", 0) >= 3) {
			maxNum_i = maxNum_i - 1;
			if (PlayerPrefs.GetInt ("ieffect_set", 0) >= 6) {
				maxNum_i = maxNum_i - 4;
				if (PlayerPrefs.GetInt ("ieffect_set", 0) >= 9) {
					maxNum_i = maxNum_i - 5;
					if (PlayerPrefs.GetInt ("ieffect_set", 0) >= 13) {
						maxNum_i = maxNum_i - 5;
						if (PlayerPrefs.GetInt ("ieffect_set", 0) >= 16) {
							maxNum_i = maxNum_i - 5;
						}
					}
				}
			}
			if (maxNum_i < 0) {
				maxNum_i = 1;
			}
		}

		PlayerPrefs.SetInt ("index" + c_Num, eggIndex_i);
		PlayerPrefs.SetInt ("rare" + c_Num, eggRare_i);
		PlayerPrefs.SetInt ("max"+c_Num,maxNum_i);
		PlayerPrefs.SetInt ("eggrare"+c_Num,rands);
		ppiyakChangeEgg ();
		eggPopup_obj.SetActive (false);
	}


	IEnumerator adTimeFlow(){
		while (mG>-1) {
			nowAdTime=new System.DateTime(1970,1,1,0,0,0,System.DateTimeKind.Utc);
			lastAdTime = PlayerPrefs.GetString ("saveAdtime",nowAdTime.ToString());
			lastDateAdTime = System.DateTime.Parse(lastAdTime);
			compareAdTime =  System.DateTime.Now - lastDateAdTime;
			sG = (int)compareAdTime.TotalSeconds;
			mG = (int)compareAdTime.TotalMinutes;
			sG = sG-(sG / 60)*60;
			mG = 4 - mG;
			//광고시간 오버플로우 막기위해 5넘으면 4로 변경
			if (mG>=5) { mG = 4;}
			sG = 59- sG;
			if (mG < 0) {
				adTimeBackImg_obj.SetActive (false);
				sG = 0;
				mG = 0;
				AdTime_txt.text = "00:00";
				AdTime_obj.SetActive (false);
			} else {
				adTimeBackImg_obj.SetActive (true);
				string stru= string.Format(@"{0:00}"+":",mG)+string.Format(@"{0:00}",sG);
				AdTime_txt.text = stru;
				AdTime_obj.SetActive (true);
			}
			yield return new WaitForSeconds(1f);
		}
	}

}
