using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingDate : MonoBehaviour {


	public int[] ppiyakOne_i,ppiyakTwo_i,ppiyakThree_i;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}

}
