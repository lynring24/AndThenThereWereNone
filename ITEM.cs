using UnityEngine;
using System.Collections;
// Item DB 
public class FSlot { //Slot에 스크립트 등록 
	public int slotNum;
	public int itemNum; // 물체의 이름 & 아이콘 
	public FSlot(int _slotNum, int _itemNum){
		slotNum = _slotNum;	
		itemNum = _itemNum;	
	}
}
[System.Serializable]
public class Item{
	public string itemName; // 물체의 이름 
	public Sprite itemImage; // 물체 아이콘 
	public int itemNum; // 몇번째 slot에 들어가는 지
	public Item(string _itemName ,Sprite _itemImage,int _itemNum)
	{
		itemName =_itemName;
		itemImage=_itemImage;
		itemNum=_itemNum;
	}
	public Item(){
	}
}