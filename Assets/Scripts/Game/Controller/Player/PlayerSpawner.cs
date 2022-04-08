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
        newCharacter.AddComponent<PlayerController>()
                .setStats(new Stats().setHealth(2).setDamage(2).setMoveSpeed(4).setSpeedAtack(2))
                .setTileset("wizzard_m_run_anim_f0")
                .setSprite("wizzard_m_run_anim_f0");
    }
}
