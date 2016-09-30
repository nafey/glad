using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthBar : MonoBehaviour {
	public Slider Bar;
	public Character mon;

	// Update is called once per frame
	void Update () {
		this.Bar.value = 100 * (this.mon.health) / (this.mon.maxHealth);
	}
}
