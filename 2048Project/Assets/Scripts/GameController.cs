using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Console2048;
using UnityEngine.EventSystems;
using MoveDirection = Console2048.MoveDirection;
public class GameController : MonoBehaviour,IPointerDownHandler,IDragHandler
{

    private GameCore core;
    private NumberSprite[,] spriteActionArray;

    // Start is called before the first frame update
     private void Start()
    {
        core = new GameCore();
        spriteActionArray = new NumberSprite[4,4];
        Init();
        GenerateNewNumber();
        GenerateNewNumber();
    }





    // Update is called once per frame
    
    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {
        for(int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                CreateSprite(i, j);
            }
        }
       
    }
    /// <summary>
    /// 创建一个精灵
    /// </summary>
    /// <param name="r"></param>
    /// <param name="c"></param>
    private void CreateSprite(int r,int c)
    {
        GameObject go = new GameObject(r.ToString()+c.ToString());
        //读取精灵 0 2  4 8 
        // 设置Image中
        go.AddComponent<Image>();
        NumberSprite action = go.AddComponent<NumberSprite>();
        spriteActionArray[r, c] = action;
        action.SetImage(0);
        go.transform.SetParent(this.transform,false);
    }
    private void GenerateNewNumber()
    {
        //位置？
        //数字？
        Location? loc;
        int? number;
        core.GenerateNumber(out loc ,out number);
        //根据精灵位置获取精灵行为脚本对象引用
        spriteActionArray[loc.Value.RIndex,loc.Value.CIndex].SetImage(number.Value);
        spriteActionArray[loc.Value.RIndex, loc.Value.CIndex].CreateEffect();
    }
    private void Update()
    {
        //如果地图有更新
        if (core.IsChange)
        {
            //更新界面
            UpdateMap();
            //产生新数字
            GenerateNewNumber();
            //判断游戏是否结束
            //
            core.IsChange = false;
        }
    }

    private void UpdateMap()
    {
        for (int i=0;i<4;i++)
        {
            for (int j = 0; j < 4; j++)
            {
                spriteActionArray[i, j].SetImage(core.Map[i, j]);
            }
        }
    }
    private Vector2 startPoint;
    private bool isDown = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        startPoint = eventData.position;
        isDown = true;
                    
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDown== false) return;

        Vector2 offset = eventData.position - startPoint;

        float x = Mathf.Abs(offset.x);
        float y = Mathf.Abs(offset.y);
        MoveDirection? dir=null; 
        //
        //垂直
        if (x < y&&y>=50)
        {
            dir = offset.y > 0 ? MoveDirection.Up : MoveDirection.Down;
        }
        //水平
        if (x > y&&x>=50)
        {
            dir = offset.x > 0 ? MoveDirection.Right : MoveDirection.Left;
        }
        if (dir != null)
        {
          core.Move(dir.Value);
          isDown = false;
        }
        
    }
}
 