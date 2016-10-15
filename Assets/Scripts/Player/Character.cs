using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour {
    public Character enemy;

    public CharacterState state;

	public float speed;
    public float maxHealth;
    public float health;
    public float waitTime;
    public float maxWaitTime;

    public bool isMoving;
    public List<string> moves;
    public Move selectedMove;

    public Character() {
        this.state = CharacterState.Waiting;
    }

    public void TakeDamage(Move m) {
		this.health = this.health - m.damage;
        this.state = CharacterState.Knockback;
	}

    public void UseMove(int i) {
        string _moveName = moves[i];
        MoveFactory _factory = new MoveFactory();
        this.selectedMove = _factory.GetMove(this, enemy, _moveName);
        this.state = CharacterState.Attacking;
    }

}

public enum CharacterState {
    Waiting,
    Attacking,
    Knockback,
    Ready
}
