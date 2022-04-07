using UnityEngine;

public class HealthController : MonoBehaviour
{

    public int health;
    public bool isPlayer = false;

    private void Start()
    {
        health = 12; //gameObject.GetComponent<Stats>().health;
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
                Destroy(gameObject);
            }
            //TODO: GAMEOVER
        }
    }

}
