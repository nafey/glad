using UnityEngine;

public class Move  {
    public Controller you;
    public Controller them;
    public float damage;
    
	public Move(Controller you, Controller them, float damage) {
        this.you = you;
        this.them = them;
        this.damage = damage;
    }

    public void DoMove() {
        this.them.TakeDamage(this.damage);
    }

}
