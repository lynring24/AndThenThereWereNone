using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemDatabase : MonoBehaviour { // 어떤 아이템들을 주웠는지
	public static ItemDatabase db;
	public List<Item> items = new List<Item>();
	public List<FSlot> slots = new List<FSlot> ();

	private const int SLOTMAX = 6;
	public static int slotCount = 0;
	public static int itemCount = 0;

	private Image spriteImage; 

	// Use this for initialization
	void Awake () {
		db = this;
	}
	void Start(){
        spriteImage = gameObject.GetComponent<Image>(); 
	}
	public void Add(string itemName) //오브젝트가 눌리면 -> DB에 정보가 들어간다. 
	{
		items.Add(new Item(itemName,Resources.Load<Sprite>("ItemImages/" + itemName),itemCount)); // Resource 폴더를 만들고, 아이템이랑 이름을 같ㅔ 
		AddSlot (Resources.Load<Sprite> ("ItemImages/"+ itemName),itemCount++);
    }
	public void AddSlot(Sprite itemImage,int itemNum) { //DB 아이템이 add가 되면 V2 의 이미지가 변한다.
		if(slotCount<SLOTMAX){ // 비어있는 slot을 활용한다
            spriteImage = GameObject.Find("SlotV"+slotCount).GetComponent<Image>();
            spriteImage.sprite = itemImage;
			slots.Add (new FSlot (slotCount, itemNum));
			slotCount++;
		}
	}
}
// 사물을 클릭시 DB에 정보가 들어간다.