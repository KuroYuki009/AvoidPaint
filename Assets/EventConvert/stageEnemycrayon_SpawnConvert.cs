using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageEnemycrayon_SpawnConvert : MonoBehaviour
{
    [SerializeField] EnemySpawnSc enemyspawnscr;

    public void EnemySpawn_crayon()
    {
        enemyspawnscr.PlayerStageInSpawn_crayon();
    }
}
