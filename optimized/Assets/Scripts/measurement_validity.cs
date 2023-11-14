using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class measurement_validity : MonoBehaviour
{

    //Standard measurements
    
    //CHAIR
    public float chair_height= 1;
    public float chair_length = 0.64f;
    public float chair_width = 0.45f;
    public float chair_area;
    public int max_chair=10;

    //Sofa
    public float sofa_length = 0.75f;
    public float sofa_width = 2.73f;
    public float sofa_height = 0.8f;
    public float sofa_area;
    public int max_sofa=5;



    //lowbed
    public float bed_length = 1.9f;
    public float bed_width = 0.9f;
    public float bed_height = 0.90f;
    public float bed_area;
    public int max_bed=3;


    //shelf
    public float shelf_length = 0.22f;
    public float shelf_width = 0.40f;
    public float shelf_height = 1.12f;
    public float shelf_area;
    public int max_shelf=5;




    float roomx, roomy, roomz;

    float roomarea;


    void Start()
    {

        
    }

    void Update()
    {
        
    }

    public void calculateMaxNum()
    {
        roomarea = roomx * roomz;

        chair_area = chair_length * chair_width;
        sofa_area = sofa_length * sofa_width;
        shelf_area = shelf_length * shelf_width;
        bed_area = bed_length * bed_width;

        //find maximum number possible

        max_chair = Mathf.FloorToInt(roomarea / chair_area);
        max_sofa = Mathf.FloorToInt(roomarea / sofa_area);
        max_shelf = Mathf.FloorToInt(roomarea / shelf_area);
        max_bed = Mathf.FloorToInt(roomarea / bed_area);

        PlayerPrefs.SetInt("chair", max_chair);
        PlayerPrefs.SetInt("sofa", max_sofa);
        PlayerPrefs.SetInt("shelf", max_shelf);
        PlayerPrefs.SetInt("bed", max_bed);

        SceneManager.LoadScene(0);


    }
}
