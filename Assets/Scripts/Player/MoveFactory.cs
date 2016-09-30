using UnityEngine;


public class MoveFactory  {
	private const string path = "MoveDef/";

	public Move GetMove(Character user, Character target, string moveName) {
		GameObject gameObj = (GameObject) Resources.Load(path + moveName);
		MoveDef moveDef = gameObj.GetComponent<MoveDef>();

		return new Move(user, target, moveDef.moveName, moveDef.damage, moveDef.type, moveDef.range);
	}
}
