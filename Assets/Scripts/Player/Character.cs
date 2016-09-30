using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour {
    public Character enemy;

    public CharacterState state;

	public float speed;
    public float maxHealth;
    public float health;

    public bool isMoving;
    public List<string> moves;
    public Move selectedMove;

    public Character() {
        this.state = CharacterState.Waiting;
    }

    public void TakeDamage(float damage) {
		health = health - damage;
	}

    public void SelectMove(int i) {
        string _moveName = moves[i];
        MoveFactory _factory = new MoveFactory();
        this.selectedMove = _factory.GetMove(this, enemy, _moveName);
        this.isMoving = true;
    }

}

public enum CharacterState {
    Waiting,
    Attacking,
    Knockback
}
