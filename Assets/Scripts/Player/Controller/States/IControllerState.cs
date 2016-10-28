
public interface IControllerState {

	void UpdateState();

	void TransitionState(CharacterState state);

	bool isFinished();
}
