using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageEnemycrayon_SpawnConvert : MonoBehaviour
{
    [SerializeField] EnemySpawnSc enemyspawnscr;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void EnemySpawn_crayon()
    {
        enemyspawnscr.SendMessage("PlayerStageInSpawn_crayon");
    }
}
