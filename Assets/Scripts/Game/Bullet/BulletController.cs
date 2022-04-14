using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Transform target;
    public Sprite[] tileSet;

    public int damage;
    public int speed;
    public BulletController enable()
    {
        gameObject.SetActive(true);
        return this;
    }

    public BulletController disable()
    {
        gameObject.SetActive(false);
        return this;
    }
}
