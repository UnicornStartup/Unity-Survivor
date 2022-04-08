using UnityEngine;

public class HealthController : MonoBehaviour
{

    public int health;
    public bool isPlayer = false;

    private void OnEnable()
    {
        health = gameObject.GetComponent<EnemyController>().stats.health;
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
