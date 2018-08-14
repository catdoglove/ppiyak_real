using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityADS : MonoBehaviour {

    private string gameId = "1486550";//★테스트ID , Window > Services 설정 테스트 바꿀것 test 1486550
	public GameObject GM,adsPopup,goPy;


    // Use this for initialization
    void Start () {
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
			goPy.SetActive (false);
            adsPopup.SetActive(false);
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


}
