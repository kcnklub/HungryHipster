﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	public int score;

	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + score;
	}
}
