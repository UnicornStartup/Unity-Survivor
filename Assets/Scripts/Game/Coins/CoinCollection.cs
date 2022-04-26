
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinCollection
{
    public static List<GameObject> coins = new List<GameObject>();
    public static List<GameObject> coinsDisabled = new List<GameObject>();

    public static GameObject getDisabledBullet()
    {
        GameObject bulletController = coinsDisabled.FirstOrDefault();
        if (bulletController != null) coinsDisabled.Remove(bulletController);
        return bulletController;
    }
    public static void addBullet(GameObject bulletController)
    {
        coins.Add(bulletController);
    }
    public static void removeBullet(GameObject bulletController)
    {
        coins.Remove(bulletController);
        coinsDisabled.Add(bulletController);
    }
}
