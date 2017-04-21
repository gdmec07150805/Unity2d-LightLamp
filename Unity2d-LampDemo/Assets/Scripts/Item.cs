using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public Sprite[] sprites;
    private SpriteRenderer SpriteRd;
    private bool isNo;
    private int row;
    private int col;

    public GameController gController;
    public void setController(GameController con)
    {
        this.gController = con;
    }


	// Use this for initialization
	void Start () {
        //获取切换帧的渲染器
        SpriteRd = GetComponent<SpriteRenderer>();
        isNo = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        UpdateState();
        gController.UpdateOtherLight(row,col);
        Debug.Log(row+","+col);
    }
    public void UpdatePos(int row,int col)
    {
        this.row = row;
        this.col = col;
        this.transform.position = new Vector2(col,row);
    }
    public void UpdateState()
    {
        isNo = !isNo;
        if (isNo)
        {
            SpriteRd.sprite = sprites[1];
        }
        else
        {
            SpriteRd.sprite = sprites[0];
        }
    }
    public bool isMatch(int rowIndex,int colIndex)
    {
        if (this.row==rowIndex&&this.col==colIndex) {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool getSate()
    {
        if (SpriteRd.sprite == sprites[1])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
