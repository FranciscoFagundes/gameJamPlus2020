using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BaseStats : MonoBehaviour
{
    
    public NpcStats npcStats;

    void Update()
    {
        if(npcStats.health <= 0) {
            Debug.Log("Game Over");
        }
    }
}
