using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletCollection
{
    public static List<GameObject> bullets = new List<GameObject>();
    public static List<GameObject> bulletsDisabled = new List<GameObject>();

    public static GameObject getDisabledBullet()
    {
        GameObject bullet = bulletsDisabled.FirstOrDefault();
        if (bullet != null) bulletsDisabled.Remove(bullet);
        return bullet;
    }
    public static void addBullet(GameObject bullet)
    {
        bullets.Add(bullet);
    }
    public static void removeBullet(GameObject bullet)
    {
        bullets.Remove(bullet);
        bulletsDisabled.Add(bullet);
    }
}
