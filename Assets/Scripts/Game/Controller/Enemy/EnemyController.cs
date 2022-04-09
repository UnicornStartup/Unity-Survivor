using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public Stats stats;
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
}
