using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageEnemyPaint_SpawnConvert : MonoBehaviour
{
    [SerializeField] EnemySpawnSc enemyspawnscr;

    public void EnemySpawn_paint()
    {
        enemyspawnscr.PlayerStageInSpawn_paint();
    }
}
