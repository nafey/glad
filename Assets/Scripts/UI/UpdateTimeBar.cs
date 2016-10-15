using UnityEngine;
using UnityEngine.UI;

public class UpdateTimeBar : MonoBehaviour {

	public Slider Bar;
	public Character mon;

	void Update () {
		if (this.mon.state == CharacterState.Ready) {
			this.Bar.value = 100;
		} else {
			this.Bar.value = 100 * (this.mon.waitTime) / (this.mon.maxWaitTime);
		}
	}
}
