using UnityEngine;

public class HealthController : MonoBehaviour
{

    public int health;
    public bool isPlayer = false;

    public void build(int health, bool isPlayer)
    {
        this.health = health;
        this.isPlayer = isPlayer;
    }

    public void damage(int dmg)
    {
        health -= dmg;
    }

    private void Update()
    {
        if (health <= 0)
        {
            if (!isPlayer)
            {
                GetComponent<EnemyController>().die();
            }
            //TODO: GAMEOVER
        }
    }

}
