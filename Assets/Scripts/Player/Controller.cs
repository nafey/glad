using UnityEngine;

public class Controller : MonoBehaviour {
	public Character mon;
	public MyTime time;

	private bool initFlag = false;
	private float moveRatio;
	private Vector2 moveStart;
	private Vector2 moveTarget;

	void Update () {
		if (this.mon.isMoving) {
			//initialize if first iteration
			if (!this.initFlag) {
				this.moveStart = this.transform.position;
				this.moveTarget = this.mon.enemy.transform.position;
			}

			// Move this closer to target
			float _dist = Vector2.Distance(moveTarget, moveStart);
			float _travelTime = _dist / this.mon.speed;
			float _distRemaining = Vector2.Distance(moveTarget, this.transform.position);

			this.moveRatio = moveRatio + time.GetDeltaTime() / _travelTime;
			this.transform.position = Vector2.Lerp(moveStart, moveTarget, moveRatio);

			// if enemy is in range stop moving and use move
			if (_distRemaining < this.mon.selectedMove.range) {
				this.mon.isMoving = false;
				this.moveTarget = new Vector2();
				this.moveStart = new Vector2();
				this.moveRatio = 0;
				this.initFlag = false;
				
				Move m = this.mon.selectedMove;
				m.DoMove();
			}
		}
	}
}
