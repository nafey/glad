public class ReadyState  : IControllerState {

	private Controller controller;

	private bool finished;

	private bool isPlayerControlled;
	private Character mon;
	private MyTime time;

	public ReadyState(bool isPlayerControlled, MyTime time, Character mon) {
		this.finished = false;
		this.isPlayerControlled = isPlayerControlled;
		this.time = time;
		this.mon = mon;
	}

	public void UpdateState() {
		if (this.isPlayerControlled) {
			this.time.scale = 0f;
		} else {
			this.mon.UseMove(0);
			this.TransitionState(CharacterState.Attacking);
		}
	}

	public void TransitionState(CharacterState state) {
		this.finished = true;

		if (state == CharacterState.Attacking) {
			this.controller.controllerState = this.controller.attackingState;
		}
	}


	public bool isFinished() {
		return finished;
	}
}