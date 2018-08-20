using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityADS : MonoBehaviour {

    private string gameId = "1486550";//★테스트ID , Window > Services 설정 테스트 바꿀것 test 1486550
	public GameObject GM,adsPopup,goPy;
    public GameObject GM_fever;
    public int soundck;

	int sG,mG;

    // Use this for initialization
    void Start () {
		StartCoroutine ("adTimeFlow");
          if (Advertisement.isSupported)
          {
              Advertisement.Initialize(gameId, true);
          }
      }
      
    // Update is called once per frame

    public void ShowRewardedAd()
    {		
			if (Advertisement.IsReady("rewardedVideo"))
			{
			goPy.GetComponent<GoPPiyak> ().moveX = 3.5f;
				ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
				Advertisement.Show("rewardedVideo", options);
            }        
    }
    

    private void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            GM.GetComponent<GameEvt>().fever = 2;
			GM.GetComponent<GameEvt>().fever_obj.SetActive (true);
			goPy.GetComponent<GoPPiyak> ().moveX = 3.5f;
			goPy.SetActive (false);
			PlayerPrefs.SetInt("secf",60);
            adsPopup.SetActive(false);
            GM_fever.GetComponent<PopupZoom>().ZoomIn2();
            soundck = 99;
            PlayerPrefs.SetInt("popupstart", 9);
        }
    }



    public void openPopup()
    {
        adsPopup.SetActive(true);
    }

    public void closePopup()
    {
        adsPopup.SetActive(false);
    }

	IEnumerator adTimeFlow(){
		while (mG>-1) {

			sG = PlayerPrefs.GetInt("secf",60);
			mG = (int)(sG / 60);
			sG = sG-(sG / 60)*60;
			if (sG < 0) {
				sG = 0;
				mG = 0;
				goPy.SetActive (true);
			} else {
			}
			sG = PlayerPrefs.GetInt("secf",60);
			sG = sG - 1;
			if (sG < 0) {
				sG = -1;
			}
			PlayerPrefs.SetInt("secf",sG);
			yield return new WaitForSeconds(1f);
		}
	}
}
