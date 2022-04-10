using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = System.Random;

public class EnemyCollection
{
    public static List<EnemyController> enemys = new List<EnemyController>();
    public static List<EnemyController> enemysDisabled = new List<EnemyController>();

    public static GameObject getClosed(Transform transfom)
    {
       // var _resultSet = objList.OrderBy(x => Guid.NewGuid()).Take(1);
        EnemyController enemyController = enemys.OrderBy(t => (t.gameObject.transform.position - transfom.position).sqrMagnitude).FirstOrDefault();
        var rand = new Random();
        var user = enemys[rand.Next(enemys.Count-1)];
        enemyController = user;
        return enemyController != null ? enemyController.gameObject : null;
    }
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

