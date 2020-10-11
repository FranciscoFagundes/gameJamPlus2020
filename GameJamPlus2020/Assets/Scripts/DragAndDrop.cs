using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;


    private RectTransform rectTransform;

    private RectTransform initialPosition;

    public BattleManager battleManager;

    public Sprite npcSprite;

    public Sprite disabledSprite;

    public Sprite enabledSprite;

    public Image imageComponent;

    public GameObject canvasObject;

    public GameObject battleManagerObject;

    public int myPositionOnArray;

    public bool active;

    public int npcNumber;

    public int npcCost;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        imageComponent = GetComponent<Image>();
        canvasObject = GameObject.FindGameObjectWithTag("CanvasMain");
        battleManagerObject = GameObject.FindGameObjectWithTag("BattleManager");
        canvas = canvasObject.GetComponent<Canvas>();
        battleManager = battleManagerObject.GetComponent<BattleManager>();
    }

    
    void Update()
    {
        if(battleManager.power < npcCost) {
            imageComponent.sprite = disabledSprite;
            active = false;
        }else {
            imageComponent.sprite = enabledSprite;
            active= true;
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (active) {
            initialPosition = rectTransform;
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor / 110;
            imageComponent.sprite = npcSprite;
            rectTransform.transform.localScale = new Vector3(0.011f,0.011f,0.011f);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(rectTransform.position.y > -1.4f && rectTransform.position.y < 1.8f  ) {
            battleManager.SpawnNpc(rectTransform, npcNumber, npcCost);
            battleManager.AddCardToList(myPositionOnArray);
            Destroy(this.gameObject);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
            Debug.Log("OnPointerDown");
    }

}