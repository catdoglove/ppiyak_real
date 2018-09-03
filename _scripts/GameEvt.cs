using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEvt : MonoBehaviour
{
    //이전씬에서로드된데이터가져오기
    public GameObject GM, GM_fever;
    public int eggRare_i, touchNum_i, maxNum_i, eggIndex_i;
    public GameObject[] ppiyak_obj;
    public Sprite[] ppiyakBasic_spr, ppiyakGood_spr, ppiyakAwesome_spr;
    public Sprite[] egg_spr;
    public GameObject eggPopup_obj;

    public int c_Num;
    int addCoin;

    //피버타임
    public int fever;
    public GameObject fever_obj;


    //광고시간
    System.DateTime nowAdTime;
    System.DateTime lastDateAdTime;
    System.TimeSpan compareAdTime;
    string lastAdTime;
    public Text AdTime_txt;
    public GameObject AdTime_obj;

    public GameObject adTimeBackImg_obj;


    //광고시청불가
    public GameObject noADS_popup;

    void Awake()
    {
        //스프라이트동적할당
        ppiyakBasic_spr = Resources.LoadAll<Sprite>("ppiyak/ppiyak_01(170x130)");
        ppiyakGood_spr = Resources.LoadAll<Sprite>("ppiyak/ppiyak_02(170x130)");
        ppiyakAwesome_spr = Resources.LoadAll<Sprite>("ppiyak/ppiyak_03(170x130)");
        egg_spr = Resources.LoadAll<Sprite>("ppiyak/egg(110x120)");

    }

    // Use this for initialization
    void Start()
    {
        //화면 해상도
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        float screenNum = (float)Screen.width / (float)Screen.height;
        if (screenNum < 0.57f)
        {
            Screen.SetResolution(Screen.height / 16 * 9, Screen.height, true);
        }
        else if (screenNum >= 0.57f && screenNum < 0.62f)
        {
            Screen.SetResolution(Screen.height / 5 * 3, Screen.height, true);
        }
        else if (screenNum >= 0.62f && screenNum < 0.65f)
        {
            Screen.SetResolution(Screen.height / 16 * 10, Screen.height, true);
        }
        else if (screenNum >= 0.65f && screenNum < 0.7f)
        {
            Screen.SetResolution(Screen.height / 3 * 2, Screen.height , true);
        }
        else if (screenNum >= 0.7f)
        {
            Screen.SetResolution(Screen.height / 4 * 3, Screen.height, true);
        }
        else
        {
            Screen.SetResolution(Screen.height / 3 * 2, Screen.height, true);
        }





        //GM = GameObject.FindGameObjectWithTag ("GameObject");
        //각각병아리별로이름을 받아오기
        //자신의 이름을 불러옴
        string str = this.gameObject.name;
        //자신의 이름에 달린 번호를 불러옴
        if (str.Length > 3)
        {
            c_Num = int.Parse(str.Substring(5)) - 1;
            //번호별로 저장된값 불러옴
            eggRare_i = PlayerPrefs.GetInt("rare" + c_Num, 0);
            maxNum_i = PlayerPrefs.GetInt("max" + c_Num, 100);
            touchNum_i = PlayerPrefs.GetInt("touch" + c_Num, 0);
            eggIndex_i = PlayerPrefs.GetInt("index" + c_Num, 0);
            //병아리이미지 바꾸기
            if (touchNum_i == -1)
            {

                ppiyakChange();
                addCoin = 0;
            }
            else
            {
                ppiyakChangeEgg();
            }
        }

    }

    public void eggNum1()
    {
        c_Num = 0;
    }
    public void eggNum3()
    {
        c_Num = 2;
    }

    public void touchEgg()
    {
        touchNum_i = PlayerPrefs.GetInt("touch" + c_Num, 0);
        //-1일때알이부화되어있다 이때터치하면새로운랜덤변수들을정해준다
        if (touchNum_i == -1)
        {
            touchNum_i++;
            PlayerPrefs.SetInt("touch" + c_Num, touchNum_i);
            PlayerPrefs.Save();
            eggPopup_obj.SetActive(true);
        }
        else
        {

            //번호별로 저장된값 불러옴
            eggRare_i = PlayerPrefs.GetInt("rare" + c_Num, 0);
            maxNum_i = PlayerPrefs.GetInt("max" + c_Num, 100);
            touchNum_i = PlayerPrefs.GetInt("touch" + c_Num, 0);
            eggIndex_i = PlayerPrefs.GetInt("index" + c_Num, 1);


            touchNum_i++;

            if (GM.GetComponent<GameEvt>().fever > 0)
            { //피버타임
                touchNum_i++;
                GM.GetComponent<GameEvt>().fever = GM.GetComponent<GameEvt>().fever - 2;
            }
            else
            {//★피버타임 fever
                //뭘 변수를 만들어서 피버타임이 발동 될 때만 실행이 되도록
                if (PlayerPrefs.GetInt("popupstart", 0) == 9)
                {
                    PlayerPrefs.SetInt("popuptouch", 9); //팝업 줌때문에
                    GM_fever.GetComponent<PopupZoom>().fadeouttt();
                    PlayerPrefs.SetInt("popupstart", 1);

                }
            }


            PlayerPrefs.SetInt("touch" + c_Num, touchNum_i);



            //터치수가채워지면부화
            if (touchNum_i >= maxNum_i)
            {
                //부화됨터치횟수초기화하고다음알의희귀도를지정
                PlayerPrefs.SetInt("bornppiyak", 99);

                touchNum_i = -1;
                PlayerPrefs.SetInt("touch" + c_Num, touchNum_i);
                //병아리이미지변경
                ppiyakChange();
                string str = PlayerPrefs.GetString("code", "");
                GM.GetComponent<GameBtnEvt>().gameCoin_i = PlayerPrefs.GetInt(str, 0);
                //효과

                int bb = PlayerPrefs.GetInt("bottomset", 0) + 1;
                if (bb >= 3)
                {
                    addCoin = addCoin + 10;
                    if (bb >= 6)
                    {
                        addCoin = addCoin + 15;
                        if (bb >= 9)
                        {
                            addCoin = addCoin + 25;
                            if (bb >= 13)
                            {
                                addCoin = addCoin + 25;
                                if (bb >= 16)
                                {
                                    addCoin = addCoin + 25;
                                }
                            }
                        }
                    }
                    if (maxNum_i < 0)
                    {
                        maxNum_i = 1;
                    }
                }

                GM.GetComponent<GameBtnEvt>().gameCoin_i = GM.GetComponent<GameBtnEvt>().gameCoin_i + addCoin;
                PlayerPrefs.SetInt(str, GM.GetComponent<GameBtnEvt>().gameCoin_i);
                PlayerPrefs.Save();

            }
            else
            {
                ppiyakChangeEgg();
            }
            PlayerPrefs.Save();
        }
    }

    void ppiyakChange()
    {
        //부화 병아리이미지로 변경
        switch (eggRare_i)
        {
            case 0:
                GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite = GM.GetComponent<GameEvt>().ppiyakBasic_spr[eggIndex_i];
                addCoin = 100;
                PlayerPrefs.SetInt("basic_book" + (eggIndex_i - 1), 1);
                break;
            case 1:
                addCoin = 200;
                GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite = GM.GetComponent<GameEvt>().ppiyakGood_spr[eggIndex_i];
                PlayerPrefs.SetInt("good_book" + eggIndex_i, 1);
                break;
            case 2:
                addCoin = 500;
                GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite = GM.GetComponent<GameEvt>().ppiyakAwesome_spr[eggIndex_i];
                PlayerPrefs.SetInt("awesome_book" + eggIndex_i, 1);
                break;
            case 3:
                GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite = GM.GetComponent<GameEvt>().ppiyakAwesome_spr[1];
                break;
        }
    }

    void ppiyakChangeEgg()
    {
        int rands = PlayerPrefs.GetInt("eggrare" + c_Num, 0);

        switch (eggRare_i)
        {
            case 0:
                GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite = GM.GetComponent<GameEvt>().egg_spr[rands];
                break;
            case 1:
                GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite = GM.GetComponent<GameEvt>().egg_spr[rands];
                break;
            case 2:
                GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite = GM.GetComponent<GameEvt>().egg_spr[rands];
                break;
            case 3:
                GM.GetComponent<GameEvt>().ppiyak_obj[c_Num].GetComponent<Image>().sprite = GM.GetComponent<GameEvt>().egg_spr[1];
                break;
        }
    }


    public void eggOk()
    {
        eggRare_i = Random.Range(0, 100);
        int rr = 90;
        int nr = 65;
        if (PlayerPrefs.GetInt("backset", 0) < 4)
        {
            rr = 101;
            nr = 99;
        }
        else if (PlayerPrefs.GetInt("backset", 0) < 12)
        {
            rr = 101;
            nr = 65;
        }
        else if (PlayerPrefs.GetInt("backset", 0) >= 12)
        {
            rr = 90;
            nr = 65;
        }
        if (eggRare_i >= rr)
        {
            eggRare_i = 2;

        }
        else if (eggRare_i >= nr)
        {
            eggRare_i = 1;
        }
        else
        {
            eggRare_i = 0;
        }
        //eggRare_i = Random.Range (0, 3);
        //알나오는 확률

        int rand = 1;
        int rands = 0;
        int eff;
        switch (eggRare_i)
        {
            case 0:
                rand = PlayerPrefs.GetInt("basic_unlock", 6);
                eggIndex_i = Random.Range(1, rand);
                //효과
                eff = PlayerPrefs.GetInt("backset", 0) + 2;

                if (eff != eggIndex_i)
                {
                    eggIndex_i = Random.Range(1, rand);
                }
                if (eff != eggIndex_i)
                {
                    eggIndex_i = Random.Range(1, rand);
                }
                if (eff != eggIndex_i)
                {
                    eggIndex_i = Random.Range(1, rand);
                }
                if (eff != eggIndex_i)
                {
                    eggIndex_i = Random.Range(1, rand);
                }
                if (eff != eggIndex_i)
                {
                    eggIndex_i = Random.Range(1, rand);
                }

                rands = Random.Range(0, 2);
                maxNum_i = 100; //★100 <그냥 150에서 100하기로함
                break;
            case 1:
                rand = PlayerPrefs.GetInt("good_unlock", 8);
                eggIndex_i = Random.Range(0, rand);
                //효과
                eff = PlayerPrefs.GetInt("backset", 0) - 4;

                if (eff != eggIndex_i)
                {
                    eggIndex_i = Random.Range(0, rand);
                }
                if (eff != eggIndex_i)
                {
                    eggIndex_i = Random.Range(0, rand);
                }
                if (eff != eggIndex_i)
                {
                    eggIndex_i = Random.Range(0, rand);
                }
                if (eff != eggIndex_i)
                {
                    eggIndex_i = Random.Range(0, rand);
                }
                if (eff != eggIndex_i)
                {
                    eggIndex_i = Random.Range(0, rand);
                }
                if (eff != eggIndex_i)
                {
                    eggIndex_i = Random.Range(0, rand);
                }
                if (eff != eggIndex_i)
                {
                    eggIndex_i = Random.Range(0, rand);
                }
                if (eff != eggIndex_i)
                {
                    eggIndex_i = Random.Range(0, rand);
                }
                rands = Random.Range(2, 4);
                maxNum_i = 250; //★200
                break;
            case 2:
                rand = PlayerPrefs.GetInt("awesome_unlock", 7);
                eggIndex_i = Random.Range(0, rand);
                //효과
                eff = PlayerPrefs.GetInt("backset", 0) - 12;

                if (eff > -1)
                {
                    eggIndex_i = eff;
                }

                rands = Random.Range(4, 6);
                maxNum_i = 500; //★500
                break;
            case 3:
                maxNum_i = Random.Range(11, 21);
                break;
        }
        //효과
        int ii = PlayerPrefs.GetInt("incubatorset", 0) + 1;

        if (ii >= 3)
        {
            maxNum_i = maxNum_i - 1;
            if (ii >= 6)
            {
                maxNum_i = maxNum_i - 4;
                if (ii >= 9)
                {
                    maxNum_i = maxNum_i - 5;
                    if (ii >= 13)
                    {
                        maxNum_i = maxNum_i - 5;
                        if (ii >= 16)
                        {
                            maxNum_i = maxNum_i - 5;
                        }
                    }
                }
            }
            if (maxNum_i < 0)
            {
                maxNum_i = 1;
            }
        }

        PlayerPrefs.SetInt("index" + c_Num, eggIndex_i);
        PlayerPrefs.SetInt("rare" + c_Num, eggRare_i);
        PlayerPrefs.SetInt("max" + c_Num, maxNum_i);
        PlayerPrefs.SetInt("eggrare" + c_Num, rands);
        ppiyakChangeEgg();
        eggPopup_obj.SetActive(false);
    }




    IEnumerator adsNoShow()
    {       
        noADS_popup.SetActive(true);
        yield return new WaitForSeconds(3f);
        noADS_popup.SetActive(false);
    }
}
