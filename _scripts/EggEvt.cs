using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggEvt : MonoBehaviour {

    public GameObject eggImg,touchArea;
    private Vector3 eggImgPos;
    int rotateInt = 5;


    
    public void shakeEgg() {
        rotateInt = 5;
        StopCoroutine("rotateImg");
        StartCoroutine("rotateImg");
    }

    IEnumerator rotateImg()
    {
        touchArea.SetActive(false);
        while (rotateInt > -6)
        {
            transform.Rotate(0, 0, rotateInt);
            rotateInt = rotateInt - 2;
            yield return new WaitForSeconds(0.001f);
        }

        while (rotateInt < 6)
        {
            transform.Rotate(0, 0, rotateInt);
            rotateInt = rotateInt + 2;
            yield return new WaitForSeconds(0.001f);
        }

        while (rotateInt > -6)
        {
            transform.Rotate(0, 0, rotateInt);
            rotateInt = rotateInt - 2 ;
            yield return new WaitForSeconds(0.001f);
        }

        touchArea.SetActive(true);



    }




    }


