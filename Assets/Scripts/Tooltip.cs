using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private Hashtable table = new Hashtable();
    private Text selectionText;
    private float absolute;
    private float lMin = 15;
    private float lMax = 0;
    private bool tooltipActive = false;

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
        if (GameObject.Find("ScriptHolder").GetComponent<Tooltip>().getIsActive())
        {
            findMin();
            findMax();
            float t = (absolute - lMin) / (lMax - lMin);
            string s = "Expression value (log2CPM)= " + absolute.ToString("0.00") + "; \n Relative expression = " + t.ToString("0.00");
            selectionText.text = s;
        }
    }

    private void OnMouseExit()
    {
        selectionText.text = "";
    }

    public void storeValues(string hp, float abs)
    {
        GameObject.Find(hp).GetComponent<Tooltip>().setValues(abs);
    }

    public void setValues(float abs)
    {
        this.absolute = abs;
    }

    private void findMin()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("slice");

        foreach(GameObject go in gameObjects)
        {
            if (lMin > go.GetComponent<Tooltip>().getExp())
            {
                lMin = go.GetComponent<Tooltip>().getExp();
            }

        }
    }

    private void findMax()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("slice");

        foreach (GameObject go in gameObjects)
        {
            if (lMax < go.GetComponent<Tooltip>().getExp())
            {
                lMax = go.GetComponent<Tooltip>().getExp();
            }

        }
    }

    public float getExp()
    {
        return absolute;
    }

    public void Reset()
    {
        lMin = 15;
        lMax = 0;
    }

    public bool getIsActive()
    {
        return tooltipActive;
    }

    public void mouseHoverIsActive(bool state)
    {
        tooltipActive = state;
    }

}
