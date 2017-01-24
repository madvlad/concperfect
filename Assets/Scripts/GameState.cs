using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameState : MonoBehaviour {

    public Text timer;
	
	// Update is called once per frame
	void FixedUpdate () {
        timer.text = System.DateTime.Now.ToShortTimeString();
	}
}
