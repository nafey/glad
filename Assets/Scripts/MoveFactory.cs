public class MoveFactory  {
	public Controller user;
    public Controller target;
    
	public MoveFactory(Controller user, Controller target) {
		this.user = user;
		this.target = target;
	}

	public Move GetMove(string moveName) {
		if (moveName.ToLower() == "tackle") {
			return new Move(user, target, 40);
		}

		return null;
	}
}
