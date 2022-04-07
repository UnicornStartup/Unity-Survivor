using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollection
{
    public static List<EnemyController> enemys = new List<EnemyController>();
    public static List<EnemyController> enemysDisabled = new List<EnemyController>();

    public void addEnemy(EnemyController enemyController)
    {
        enemys.Add(enemyController);
    }
    public void removeEnemy(EnemyController enemyController)
    {
        enemys.Remove(enemyController);
        enemysDisabled.Add(enemyController);
    }
}

