﻿using UnityEngine;

public class AttackingState  : IControllerState {

	
	private Controller controller;
	private bool finished;
	private MyTime time;

	private Vector2 moveStart;
	private Vector2 moveTarget;
	private float moveStopRange;
	private float moveRatio;


	public AttackingState(Controller controller, Vector2 enemyPosition, MyTime time) {
		this.controller = controller;
		this.finished = false;
		this.time = time;

		this.moveStart = this.controller.transform.position;

		this.moveTarget = this.controller.transform.position;
		this.moveStopRange = 0.5f;
	}
	
	public void UpdateState() {
		// Move this closer to target
		float _dist = Vector2.Distance(moveTarget, moveStart);
		float _travelTime = _dist / this.controller.mon.speed;
		float _distRemaining = Vector2.Distance(moveTarget, this.controller.transform.position);

		this.moveRatio = moveRatio + time.GetDeltaTime() / _travelTime;
		this.controller.transform.position = Vector2.Lerp(moveStart, moveTarget, moveRatio);

		// if enemy is in range stop moving and use move
		if (_distRemaining < this.moveStopRange) {

			this.controller.mon.isMoving = false;
			this.moveTarget = new Vector2();
			this.moveStart = new Vector2();
			this.moveRatio = 0;

			this.TransitionState(CharacterState.Waiting);
		}
	}

	public void TransitionState(CharacterState state) {
		this.finished = true;

		if (state == CharacterState.Waiting) {
			this.controller.controllerState = this.controller.waitingState;
		}
	}

	public bool isFinished() {
		return finished;
	}
}