using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public StatCollection stats = new StatCollection();
    public Sprite[] tileSet;

    public EnemyController enable()
    {
        gameObject.SetActive(true);
        return this;
    }

    public EnemyController disable()
    {
        gameObject.SetActive(false);
        return this;
    }

    public void die()
    {
        EnemyCollection.removeEnemy(this);
        gameObject.SetActive(false);
        GetComponent<ExperienceSpawnerController>().spawn(gameObject.transform.position);
    }
}
