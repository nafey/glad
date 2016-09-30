using UnityEngine;
using System.Collections.Generic;

public class ScrollBackground : MonoBehaviour {
	public List<Transform> backgrounds = new List<Transform>();
	public Transform tracker;
	public float backgroundWidth;

	void Update () {
		if (Vector2.Distance(tracker.position, backgrounds[2].position) < backgroundWidth / 2) {
			for (int i = 0; i < backgrounds.Count; i++) {
				backgrounds[i].transform.Translate(new Vector3(backgroundWidth, 0f, 0f));
			}
		} else if (Vector2.Distance(tracker.position, backgrounds[0].position) < backgroundWidth / 2) {
			for (int i = 0; i < backgrounds.Count; i++) {
				backgrounds[i].transform.Translate(new Vector3(backgroundWidth * -1, 0f, 0f));
			}
		}
	}
}
