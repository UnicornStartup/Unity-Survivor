using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyCollection
{
    public static List<EnemyController> enemys = new List<EnemyController>();
    public static List<EnemyController> enemysDisabled = new List<EnemyController>();

    public static EnemyController getDisabledEnemy()
    {
        EnemyController enemyController = enemysDisabled.FirstOrDefault();
        if (enemyController != null) enemysDisabled.Remove(enemyController);
        return enemyController;
    }
    public static void addEnemy(EnemyController enemyController)
    {
        enemys.Add(enemyController);
    }
    public static void removeEnemy(EnemyController enemyController)
    {
        enemys.Remove(enemyController);
        enemysDisabled.Add(enemyController);
    }
}

