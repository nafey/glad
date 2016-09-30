using UnityEngine;

public class MyTime : MonoBehaviour {
	private float myTime = 0f;
	private float myDeltaTime = 0f;
	public float scale = 1f;

	public float GetTime() {
		return myTime;
	}

	public float GetDeltaTime() {
		return myDeltaTime;
	}

	void Update () {
		this.myDeltaTime = Time.deltaTime / this.scale;
		this.myTime += this.myDeltaTime;
	}
}
