using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobADS : MonoBehaviour {

    //배너
    private BannerView bannerView;
    AdRequest request;

    //영상
    private RewardBasedVideoAd rewardBasedVideo;
    string adUnitIdvideo;

    public GameObject GM,adsPopup;
    int rewardCoin;
    

    // Use this for initialization
    void Start () {

     rewardCoin = GM.GetComponent<GameBtnEvt>().gameCoin_i;

#if UNITY_ANDROID
        string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        //this.RequestBanner();
        

        rewardBasedVideo = RewardBasedVideoAd.Instance;
        
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;

        RequestRewardedVideo();
    }


    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }


    

    private void RequestRewardedVideo()
    {
        adUnitIdvideo = "ca-app-pub-3940256099942544/5224354917";
        // Create an empty ad request.
        request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        rewardBasedVideo.LoadAd(request, adUnitIdvideo);
    }

    //시청보상
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {        
        //코인 10분마다 100원 지급
        string str = PlayerPrefs.GetString("code", "");
        rewardCoin = PlayerPrefs.GetInt(str, 0);
        rewardCoin = rewardCoin + 100;
        PlayerPrefs.SetInt(str, rewardCoin);



        str = PlayerPrefs.GetString("code", "");
        GM.GetComponent<GameBtnEvt>().gameCoin_i = PlayerPrefs.GetInt(str, 0);
        GM.GetComponent<ShopEvt>().shopCoin_txt.text = "" + GM.GetComponent<GameBtnEvt>().gameCoin_i;


        //시간타이머
        PlayerPrefs.SetInt("sec",60);
    }

    //동영상닫음
    private void HandleRewardBasedVideoClosed(object sender, System.EventArgs args)
    {
        RequestRewardedVideo();
        adsPopup.SetActive(false);
    }

    public void showAdmobVideo()
    {
		PlayerPrefs.SetInt("sec",60);
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
        else
        {
            //시청안된다는 메세지라도 띄워야하나 허엄
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


    public void callBanner()
    {
        this.RequestBanner();
    }

}
