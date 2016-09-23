﻿using UnityEngine;
using UnityEngine.UI;

public class ShowTime : MonoBehaviour {

	public GameObject timeProvider;

	void Update () {
		 float time = timeProvider.GetComponent<MyTime>().GetTime();
		 this.GetComponent<Text>().text = time.ToString("0.00");
	}
}
