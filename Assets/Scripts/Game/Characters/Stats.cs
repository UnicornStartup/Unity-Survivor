public class Stats
{
    public int health;
    public int damage;
    public int moveSpeed;
    public float speedAtack;

    public Stats() { }

    public Stats setHealth(int health)
    {
        this.health = health;
        return this;
    }
    public Stats setDamage(int damage)
    {
        this.damage = damage;
        return this;
    }
    public Stats setMoveSpeed(int moveSpeed)
    {
        this.moveSpeed = moveSpeed;
        return this;
    }
    public Stats setSpeedAtack(float speedAtack)
    {
        this.speedAtack = speedAtack;
        return this;
    }
}