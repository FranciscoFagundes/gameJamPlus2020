﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{

    public GameObject[] npc;
    public float startPower;
    public float power;

    public Text powerText;
    public Image powerBar;


    public GameObject[] cardDeck = new GameObject[4];

    public GameObject[] cardTable;

    public Transform[] cardPosition;

    public List<GameObject> cardTableList = new List<GameObject>();

    public Transform[] initialCardPosition;

    public DragAndDrop dragAndDrop;

    public  Vector3 newCardPosition;

    public GameObject VictoryPanel;

    public GameObject DefeatPanel;

    public NpcStats EnemyBaseStats;

     public NpcStats OwnBaseStats;


     public AudioSource MainAudio;

     public float audioVolume;

    void Start()
    {
        audioVolume = 0.1f;
        Time.timeScale = 1.0f;
        VictoryPanel.SetActive(false);
        DefeatPanel.SetActive(false);
        power = startPower;
        for(int x = 0; x < 4; x ++) {
            cardTable[x].gameObject.transform.position = cardPosition[x].position;
            initialCardPosition[x].gameObject.transform.position = cardTable[x].gameObject.transform.position;
            GameObject newCard = GameObject.Instantiate(cardTable[x],cardPosition[x].position, Quaternion.identity, GameObject.FindGameObjectWithTag("CanvasMain").transform);
            newCard.gameObject.GetComponent<DragAndDrop>().myPositionOnArray = x;
            cardTableList.Add(newCard);
        }
    }

    void Update()
    {
       
        if(power <= 10){
            power = power + Time.deltaTime / 2;
        }

         powerBar.fillAmount = power / 10;

         powerText.GetComponent<Text>().text = power.ToString("0");

        if(EnemyBaseStats.health <= 0 ) {
            VictoryGameOver();
        }

        if(OwnBaseStats.health <= 0) {
            DefeatGameOver();
        }
    }


    public void SpawnNpc(Transform spawnPlace, int npcNumber, int npcCost) {

        if(power >= npcCost) {
             Instantiate(npc[npcNumber], spawnPlace.position, Quaternion.identity);
             power = power - npcCost;
        }
       
    }

    public void AddCardToList(int myPositionOnDeck){

       
        switch (myPositionOnDeck)
        {
            case 0:
                newCardPosition = new Vector3(0.6f,-3.5f,0f);
                break;
            case 1:
                newCardPosition = new Vector3(2.4f,-3.5f,0f);
                break;
             case 2:
                newCardPosition = new Vector3(4.1f,-3.5f,0f);
                break;
             case 3:
                newCardPosition = new Vector3(5.85f,-3.5f,0f);
                break;
            default:
                break;
        }

        float randomNumber = Random.Range(0, cardDeck.Length);
        Debug.Log("numero: " + randomNumber);
        GameObject newCard = GameObject.Instantiate(cardDeck[(int)randomNumber],newCardPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("CanvasMain").transform);
        cardTableList.Add(newCard);
    }
    public void VictoryGameOver() {
        VictoryPanel.SetActive(true);
         Time.timeScale = 0f;
    }

    public void DefeatGameOver() {
        DefeatPanel.SetActive(true);
         Time.timeScale = 0f;
    }

    public void RestartGame() {
        SceneManager.LoadScene("Game");
    }

    public void QuiteGame() {
        Debug.Log("Quitando");
        Application.Quit();

    }

    public void AudioMax(){
        MainAudio.volume += audioVolume;
    }

    public void AudioMin(){
        MainAudio.volume -= audioVolume;
    }
}
