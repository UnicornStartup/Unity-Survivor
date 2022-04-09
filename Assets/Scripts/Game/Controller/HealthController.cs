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
        Debug.Log(gameObject.name + " hp: " + health);
        health -= dmg;
    }

    private void Update()
    {
        if (health <= 0)
        {
            if (!isPlayer)
            {
                //Destroy(gameObject);
                EnemyCollection.removeEnemy(GetComponent<EnemyController>());
                gameObject.SetActive(false);
            }
            //TODO: GAMEOVER
        }
    }

}
