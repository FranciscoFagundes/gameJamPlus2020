using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarBehaviour : MonoBehaviour
{
   
   public Sprite[] powerBars;

   public BattleManager battleManager;

   public Image powerBarBase;
    
    void Awake()
    {
        powerBarBase = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        powerBarBase.sprite = powerBars[(int)battleManager.power];
    }
}
