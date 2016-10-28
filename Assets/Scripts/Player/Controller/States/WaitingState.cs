public class WaitingState : IControllerState {

	private Controller controller;
	
	private bool finished;

	private float waitTime;
	private float maxWaitTime;
	private MyTime time;


	public WaitingState(float maxWaitTime, MyTime time) {
		this.maxWaitTime = maxWaitTime;
		this.time = time;
		this.finished = false;
	}
	
	public void UpdateState() {
		
		this.waitTime += time.GetDeltaTime();

		if (this.waitTime > this.maxWaitTime) {
			this.TransitionState(CharacterState.Ready);
		}
	}

	public void TransitionState(CharacterState state) {
		this.finished = true;
		this.waitTime = 0;

		if (state == CharacterState.Ready) {
			this.controller.controllerState = this.controller.readyState;

		}
	}

	public bool isFinished() {
		return finished;
	}
}
