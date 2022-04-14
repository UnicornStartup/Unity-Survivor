using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    void Start()
    {
        spawnCharacter();
    }

    public void spawnCharacter()
    {
        GameObject prefab = Resources.Load<GameObject>($"Prefabs/Character");
        GameObject newCharacter = Instantiate(prefab, new Vector3(0, 0), Quaternion.identity);
        newCharacter.name = "Player";
        newCharacter.AddComponent<PlayerController>()
                .setStats(StatType.Health, 100)
                .setStats(StatType.Damage, 40)
                .setStats(StatType.MoveSpeed, 2)
                .setStats(StatType.AtackSpeed, 1)
                .setTileset("wizzard_m_run_anim_f0")
                .setSprite("wizzard_m_run_anim_f0");
    }
}
