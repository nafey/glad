using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
	public Controller enemy;
	public MyTime time;
	public float speed = 1;

	public float contactDistance = 0.2f;

	public Slider healthBar;


	private float moveRatio;
	private Vector2 moveStart;
	private Vector2 moveTarget;
	private bool isMoving;

	private MoveFactory moveFactory;

	public void TakeDamage(float damage) {
		healthBar.value = healthBar.value - damage;
	}

	public void MoveToEnemy() {
		moveStart = this.transform.position;
		moveTarget = enemy.transform.position;
		isMoving = true;
	}

	void Awake() {
		this.moveFactory = new MoveFactory(this, this.enemy);
	}

	void Update () {
		if (this.isMoving) {
			float dist = Vector2.Distance(moveTarget, moveStart);
			float travel_time = dist / speed;

			float dist_remaining = Vector2.Distance(moveTarget, this.transform.position);
			Debug.Log(dist_remaining);

			this.moveRatio = moveRatio + time.GetDeltaTime() / travel_time;
			this.transform.position = Vector2.Lerp(moveStart, moveTarget, moveRatio);

			if (dist_remaining < contactDistance) {
				
				this.isMoving = false;
				this.moveTarget = new Vector2();
				this.moveStart = new Vector2();
				this.moveRatio = 0;
				
				Move m = this.moveFactory.GetMove("Tackle");
				m.DoMove();
			}
		}
	}
}
