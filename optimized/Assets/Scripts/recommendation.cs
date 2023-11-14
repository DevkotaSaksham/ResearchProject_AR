using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class recommendation : MonoBehaviour
{

    private int[] placed = { 0, 0, 0, 0, 0}; //chair, sofa, bed, shelf, table

    public GameObject panel;
    private string tip="";
    public TMP_Text tip_txt;


    void Start()
    {
        panel.SetActive(false);
        
    }

    void Update()
    {
        
    }

    public string seltip(string obj)
    {
        if (obj=="chair" && placed[1]==0 && placed[2] == 0 && placed[3] == 0 && placed[4]==0) {
            // if only chair
            tip = "Organise chairs row-wise, or column-wise for better look";
        }
        else if (obj == "chair" && placed[1] != 0 ) {
            // if chair and sofaa
            tip = "Keep chair next to sofa";
        }
        else if (obj == "chair" && placed[2] != 0) {
            //if chair and bed
            tip = "Keep chairs opposite side to the bed";
        }
        else if (obj == "chair" && placed[3] != 0) {
            //if chair and shelf
            tip = "Keep some distance between chair and shelf";
        }
        else if (obj == "chair" && placed[4] != 0)
        {
            //if chair and table
            tip = "Make chairs face towards table, to make the room more organised";
        }
        /*else  {
            tip = "Organise chairs row-wise, or column-wise for better look";
        }*/




        else if (obj == "table" && placed[1] == 0 && placed[2] == 0 && placed[3] == 0 && placed[0]==0)
        {
            //if only table
            tip = "Make sure to keep space around table";
        }
        else if (obj == "table" && placed[3] != 0)
        {
            //if table and shelf
            tip = "Keep the table next to shelf for more organised look";
        }
        /*else
        {
            tip = "Make sure to keep space around table";
        }*/




        else if (obj == "shelf" && placed[1] == 0 && placed[2] == 0 && placed[4] == 0 && placed[0] == 0)
        {
            //if only shelf
            tip = "Shelfs placement are flexible. Make sure to align them with the walls";
        }
        else if (obj == "shelf" && placed[2] != 0)
        {

            //if shelf and bed
            tip = "Keep shelfs far from bed, due to safety reason";
        }
        else
        {
            tip = "Organise chairs row-wise, or column-wise for better look";

        }





        return tip;
    }


    IEnumerator fadetip()
    {

        yield return new WaitForSeconds(4);
        panel.SetActive(false);

    }

    public void displaytip( string mytip)
    {

        panel.SetActive(true);
        tip_txt.text = mytip;

        StartCoroutine(fadetip());

    }


    public void changenum(string obj, int a)
    {
        if (obj == "chair")
        {
            placed[0]+=a;
        }
        else if (obj == "sofa")
        {
            placed[1]+=a;
        }
        else if (obj == "bed")
        {
            placed[2]+=a;
        }
        else if (obj == "shelf")
        {
            placed[3] += a;
        }
        else if (obj == "table")
        {
            placed[4] += a;
        }

        string _tip=seltip(obj);
        displaytip(_tip);

    }
}
