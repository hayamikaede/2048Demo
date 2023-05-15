using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ���ӵ�ÿ�������У����ڶ��巽����Ϊ
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
        //2 ==> ���� ==> ���õ�Image��
        // ��ȡ��������ʹ��load����ȡ����ͼ��ʹ��LoadAll
        img.sprite = ResourceManager.LoadSprite(number);
        
    }
    public void CreateEffect()
    {

        iTween.ScaleFrom(gameObject, Vector2.zero,0.3f);
    }







}
