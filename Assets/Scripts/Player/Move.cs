public class Move  {
    public Character user;
    public Character target;
    public string moveName;
    public float damage;
    public MoveType type;
    public float range;

	public Move(Character user, Character target, string moveName, float damage, MoveType type, float range) {
        this.user = user;
        this.target = target;
        this.moveName = moveName;
        this.damage = damage;
        this.type = type;
        this.range = range;
    }

    public void DoMove() {
        this.target.TakeDamage(this);
    }
}


public enum MoveType {Physical, Special, Status};
