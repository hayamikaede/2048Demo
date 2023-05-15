using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// ��Դ�����࣬������������Դ
    /// </summary>
public class ResourceManager : MonoBehaviour
{
    private static Dictionary<int, Sprite> spriteDic;

    //�౻����ʱ����
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
    /// ��ȡ���־���
    /// </summary>
    /// <param name="number">�����ʾ������</param>
    /// <returns></returns>
   public static Sprite LoadSprite(int number)
    {

       
        return spriteDic[number];
    }



    
}
