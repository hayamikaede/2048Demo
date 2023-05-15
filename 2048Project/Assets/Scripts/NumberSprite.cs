using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 附加到每个方格中，用于定义方格行为
/// 
/// </summary>
public class NumberSprite : MonoBehaviour
{
    // Start is called before the first frame update

    //
    private Image img;
    private void Awake()
    {
       img= GetComponent<Image>();
    }
    public void SetImage(int number)
    {
        //2 ==> 精灵 ==> 设置到Image中
        // 读取单个精灵使用load，读取精灵图集使用LoadAll
        img.sprite = ResourceManager.LoadSprite(number);
        
    }
    public void CreateEffect()
    {

        iTween.ScaleFrom(gameObject, Vector2.zero,0.3f);
    }







}
