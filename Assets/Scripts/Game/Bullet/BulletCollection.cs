using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BulletCollection 
{
    public static List<BulletController> bullets = new List<BulletController>();
    public static List<BulletController> bulletsDisabled = new List<BulletController>();

    public static BulletController getDisabledBullet()
    {
        BulletController bulletController = bulletsDisabled.FirstOrDefault();
        if (bulletController != null) bulletsDisabled.Remove(bulletController);
        return bulletController;
    }
    public static void addBullet(BulletController bulletController)
    {
        bullets.Add(bulletController);
    }
    public static void removeBullet(BulletController bulletController)
    {
        bullets.Remove(bulletController);
        bulletsDisabled.Add(bulletController);
    }
}
