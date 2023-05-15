using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// 资源管理类，负责管理加载资源
    /// </summary>
public class ResourceManager : MonoBehaviour
{
    private static Dictionary<int, Sprite> spriteDic;

    //类被加载时调用
    static ResourceManager()
    {
        spriteDic = new Dictionary<int, Sprite>();
        var  spriteArray = Resources.LoadAll<Sprite>("2048");
        foreach (var item in spriteArray)
        {
            int intSpriteName = int.Parse(item.name);
            spriteDic.Add(intSpriteName,item);
        }
    }
    // Start is called before the first frame update
    /// <summary>
    /// 读取数字精灵
    /// </summary>
    /// <param name="number">精灵表示的数字</param>
    /// <returns></returns>
   public static Sprite LoadSprite(int number)
    {

       
        return spriteDic[number];
    }



    
}
