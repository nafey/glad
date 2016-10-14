using UnityEngine;
using UnityEngine.UI;

public class UpdateTimeBar : MonoBehaviour {

	public Slider Bar;
	public Character mon;

	void Update () {
		this.Bar.value = 100 * (this.mon.waitTime) / (this.mon.maxWaitTime);
	}
}
