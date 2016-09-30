using UnityEngine;
using System.Collections;

public class CameraTracking : MonoBehaviour {
	public Transform player;
	public Transform enemy;

	void Update () {
		this.transform.position = new Vector3(((player.position + enemy.position) / 2).x, this.transform.position.y, this.transform.position.z);
	}
}
