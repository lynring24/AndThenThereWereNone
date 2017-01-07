using UnityEngine;
using System.Collections.Generic;

//오브젝트가 눌리면 ->DB dptj 값을 끌어와서 이미지를 보여준다. 
//slot이 눌리면 -> 아이콘을 사용한다.
//ui 상의 슬롯 / DB  / 슬롯 리트 

public class Inventory : MonoBehaviour {
	public static Inventory inventory;
	private const int SLOTMAX = 6;
	public static int slotCount = 0;
	private SpriteRenderer spriteRenderer; 

	public List<FSlot> slotList = new List<FSlot> ();
	void Awake() {
	}
	void Start() 
	{ 
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
	} 
	// Update is called once per frame
	public void AddSlot(Sprite itemImage) { //DB 아이템이 add가 되면 V2 의 이미지가 변한다.
		if(slotCount<SLOTMAX){ // 비어있는 slot을 활용한다
				spriteRenderer = GameObject.Find("SlotV"+slotCount).GetComponent<SpriteRenderer>();
				spriteRenderer.sprite = itemImage;				
			}
		}
}