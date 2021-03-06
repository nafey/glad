﻿using UnityEngine;

public class Controller : MonoBehaviour {
	public Character mon;
	public MyTime time;

	public bool isPlayerControlled = false;

	private bool stateInitFlag = false;

	private float moveRatio;
	private Vector2 moveStart;
	private Vector2 moveTarget;
	private float moveStopRange;

	public IControllerState controllerState;

	public WaitingState waitingState;
	public ReadyState readyState;
	public KnockbackState knockbackState;
	public AttackingState attackingState;

	public Controller() {
		this.waitingState = new WaitingState(this.mon.maxWaitTime, this.time);
		this.readyState = new ReadyState(this.isPlayerControlled, this.time, this.mon);
		
	}

	public void UseMove(int i) {
		this.mon.UseMove(i);
		this.mon.state = CharacterState.Attacking;
		this.time.scale = 1f;
	} 

	void ReachedTarget() {
		if (this.mon.state == CharacterState.Attacking) {
			Move m = this.mon.selectedMove;
			m.target.TakeDamage(m);
		} else if (this.mon.state == CharacterState.Knockback) {
			// do nothing
		}
	}

	void Update () {
		if (this.mon.state == CharacterState.Waiting) {
			this.mon.waitTime += time.GetDeltaTime();
			
			if (this.mon.waitTime > this.mon.maxWaitTime) {
				this.mon.waitTime = 0;
				this.mon.state = CharacterState.Ready;
			}
		} else if (this.mon.state == CharacterState.Ready) {
			// handle the ai and player stuff here
			if (this.isPlayerControlled) {
				this.time.scale = 0f;
			} else {
				this.mon.UseMove(0);
			}
		} else {
			//initialize if first iteration
			if (!this.stateInitFlag) {
				this.moveStart = this.transform.position;

				if (this.mon.state == CharacterState.Attacking) {
					this.moveTarget = this.mon.enemy.transform.position;
					this.moveStopRange = this.mon.selectedMove.range;
				} else if (this.mon.state == CharacterState.Knockback) {
					int sign = 0;

					if (this.transform.position.x > this.mon.enemy.transform.position.x) {
						sign = 1;
					} else {
						sign = -1;
					}

					this.moveTarget = this.transform.position - (new Vector3(-2.5f, 0f, 0f)) * sign;
					this.moveStopRange = 0.5f;
				}

				this.stateInitFlag = true;
			}

			// Move this closer to target
			float _dist = Vector2.Distance(moveTarget, moveStart);
			float _travelTime = _dist / this.mon.speed;
			float _distRemaining = Vector2.Distance(moveTarget, this.transform.position);

			this.moveRatio = moveRatio + time.GetDeltaTime() / _travelTime;
			this.transform.position = Vector2.Lerp(moveStart, moveTarget, moveRatio);

			// if enemy is in range stop moving and use move
			if (_distRemaining < this.moveStopRange) {
				this.ReachedTarget();

				this.mon.isMoving = false;
				this.moveTarget = new Vector2();
				this.moveStart = new Vector2();
				this.moveRatio = 0;
				this.stateInitFlag = false;
			 	this.mon.state = CharacterState.Waiting;
			}
		}
	}
}
