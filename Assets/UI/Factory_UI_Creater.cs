using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factory_UI_Creater : MonoBehaviour
{
    /*
    public GameObject originObject;
    void Create_Factory_UI(string UI_Name)
    {
        GameObject cloneObject = Instantiate(originObject,new Vector2(0, 0), Quaternion.identity);
        cloneObject.transform.SetParent(transform, false);// Image_Leaderを親に指定
        cloneObject.name = UI_Name;
    }
    */
    public Image Factory_Image1;
    public Image Factory_Image2;
    public Image Factory_Image3;
    public Image Factory_Image4;
    public Image Factory_Image5;
    public Image Factory_Image6;
    public Image Factory_Image7;
    public Image Factory_Image8;
    public Image Factory_Image9;
    public Image Factory_Image10;
    public Image Factory_Image11;
    public Image Factory_Image12;
    public Image Factory_Image13;
    public Image Factory_Image14;
    public Image Factory_Image15;
    public Image Factory_Image16;
    public Image Factory_Image17;
    public Image Factory_Image18;
    public Image Factory_Image19;
    public Image Factory_Image20;
    public Image Factory_Image21;
    public Image Factory_Image22;
    public Image Factory_Image23;
    public Image Factory_Image24;
    public Image Factory_Image25;
    public Image Factory_Image26;
    public Image Factory_Image27;
    public Image Factory_Image28;
    public Image Factory_Image29;
    public Image Factory_Image30;

    void Replace_This_UI(int k, Image Image1)
    {

        if (k == 1)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("醸造場");
        }
        if (k == 2)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("衣服工場");
        }
        if (k == 3)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("家具工場");
        }
        if (k == 4)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("製紙工場");
        }
        if (k == 5)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("製材場");
        }
        if (k == 6)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("肥料工場");
        }
        if (k == 7)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("セメント工場");
        }
        if (k == 8)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("ガラス工場");
        }
        if (k == 9)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("製鉄場");
        }
        if (k == 10)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("ゴム精製施設");
        }
        if (k == 11)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("帆船造船所");
        }
        if (k == 12)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("蒸気船造船所");
        }
        if (k == 13)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("軽金属合金工場");
        }
        if (k == 14)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("魔導電信機工場");
        }
        if (k == 15)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("火砲工場");
        }
        if (k == 16)
        {
            Image1 = this.GetComponent<Image>();
            Image1.sprite = Resources.Load<Sprite>("機械部品工場");
        }
    }
    void Change_Factory_UI()
    {
        int k = 0;
        for(int i = 1; i < Factory.Number_of_Kind_of_Factory; i++)
        {
            if (Factory.Factory_in_Country[i][Province1Manager.Choosing_ProvinceNumber] != 0)
            {
                k = k + 1;
                if (k == 1) { Replace_This_UI(i, Factory_Image1); }
                if (k == 2) { Replace_This_UI(i, Factory_Image2); }
                if (k == 3) { Replace_This_UI(i, Factory_Image3); }
                if (k == 4) { Replace_This_UI(i, Factory_Image4); }
                if (k == 5) { Replace_This_UI(i, Factory_Image5); }
                if (k == 6) { Replace_This_UI(i, Factory_Image6); }
                if (k == 7) { Replace_This_UI(i, Factory_Image7); }
                if (k == 8) { Replace_This_UI(i, Factory_Image8); }
                if (k == 9) { Replace_This_UI(i, Factory_Image9); }
                if (k == 10) { Replace_This_UI(i, Factory_Image10); }
                if (k == 11) { Replace_This_UI(i, Factory_Image11); }
                if (k == 12) { Replace_This_UI(i, Factory_Image12); }
                if (k == 13) { Replace_This_UI(i, Factory_Image13); }
                if (k == 14) { Replace_This_UI(i, Factory_Image14); }
                if (k == 15) { Replace_This_UI(i, Factory_Image15); }
                if (k == 16) { Replace_This_UI(i, Factory_Image16); }
                if (k == 17) { Replace_This_UI(i, Factory_Image17); }
                if (k == 18) { Replace_This_UI(i, Factory_Image18); }
                if (k == 19) { Replace_This_UI(i, Factory_Image19); }
                if (k == 20) { Replace_This_UI(i, Factory_Image20); }
                if (k == 21) { Replace_This_UI(i, Factory_Image21); }
                if (k == 22) { Replace_This_UI(i, Factory_Image22); }
                if (k == 23) { Replace_This_UI(i, Factory_Image23); }
                if (k == 24) { Replace_This_UI(i, Factory_Image24); }
                if (k == 25) { Replace_This_UI(i, Factory_Image25); }
                if (k == 26) { Replace_This_UI(i, Factory_Image26); }
                if (k == 27) { Replace_This_UI(i, Factory_Image27); }
                if (k == 28) { Replace_This_UI(i, Factory_Image28); }
                if (k == 29) { Replace_This_UI(i, Factory_Image29); }
                if (k == 30) { Replace_This_UI(i, Factory_Image30); }

            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
