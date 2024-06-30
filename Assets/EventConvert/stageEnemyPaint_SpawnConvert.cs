using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageEnemyPaint_SpawnConvert : MonoBehaviour
{
    [SerializeField] EnemySpawnSc enemyspawnscr;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void EnemySpawn_paint()
    {
        enemyspawnscr.SendMessage("PlayerStageInSpawn_paint");
    }
}
