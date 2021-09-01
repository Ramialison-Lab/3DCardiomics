using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private Hashtable table = new Hashtable();
    private Text selectionText;
    private float value;
    private float mean = 0;

    public static string[] hp = new string[18] {
        "A_1", "A_2", "A_3", "A_4",
        "B_1", "B_2", "B_3", "B_4",
        "C_1", "C_2", "C_3", "C_4",
        "D_1", "D_2", "D_3",
        "E_1", "E_2", "E_3" };

    private void Start()
    {
        selectionText = GameObject.Find("SelectionText").GetComponent<Text>();
    }

    private void OnMouseEnter()
    {
        calculateMean(gameObject);
        //string s = gameObject.name + " " + value + " " + mean;
        float avg = value / mean;
        string s = "Selected Slice: " + gameObject.name + ": Expression value (log2PCM)= " + value.ToString("0.00") + "; \n Realtive expression vs. average of remaining sections = " + avg.ToString("0.00");
        selectionText.text = s;
    }

    private void OnMouseExit()
    {
        selectionText.text = "";
    }

    public void storeValues(string hp, float exp, float Max, float Min)
    {
        // SH only
        //float x = exp / Max;
        GameObject.Find(hp).GetComponent<Tooltip>().setValue(exp);
    }

    public void setValue(float value)
    {
        this.value = value;
    }
    private void calculateMean(GameObject obj)
    {
        float sum = 0;
        for (int i = 0; i < 18; i++)
        {
           if( GameObject.Find(hp[i]).name != obj.name)
            {
                sum = sum + GameObject.Find(hp[i]).GetComponent<Tooltip>().getValue();
                mean = sum/ 17;
            }
        }
            

    }

    public float getValue()
    {
        return value;
    }
}
