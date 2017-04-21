using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    public Item getItem;
    private Item targetItem;
    public Text gameInfo;
    //这是一个线性表，用于存储（4*4）的灯泡对象
    private List<Item> itemList;
    private int tryCount = 0;
    // Use this for initialization
    void Start () {
        itemList = new List<Item>();
        for (int row=0;row<4;row++)
        {
            for(int col = 0; col < 4; col++)
            {
                targetItem = Instantiate(getItem) as Item;
                targetItem.setController(this);
                targetItem.UpdatePos(col-2,row-2);
                itemList.Add(targetItem);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
        
	}
    public void UpdateOtherLight(int rowIndex,int colIndex)
    {
        int total = 0;
        
        tryCount++;
        Item temp = getLightItem(rowIndex + 1, colIndex);
        if (temp!=null)
        {
            
            temp.UpdateState();
        }
        temp = getLightItem(rowIndex - 1, colIndex);
        if (temp != null)
        {
            
            temp.UpdateState();
        }
        temp = getLightItem(rowIndex , colIndex +1);
        if (temp != null)
        {
            
            temp.UpdateState();
        }
        temp = getLightItem(rowIndex , colIndex -1);
        if (temp != null)
        {
            
            temp.UpdateState();
        }

        foreach(Item item in itemList)
        {
            if (item.getSate())
            {
                total += 1;
            }
        }
        if (total == itemList.Count)
        {
            gameInfo.text = "经过了" + tryCount + "次的尝试，你终于赢了！";
        }else
        {
            gameInfo.text = "你尝试了"+tryCount+"次，点亮了"+total+"盏灯";
        }
    }
    public Item getLightItem(int rowIndex,int colIndex)
    {
        foreach (Item item in itemList) {
            if (item.isMatch(rowIndex,colIndex))
            {
                return item;
            }
        }
        return null;
    }
}
