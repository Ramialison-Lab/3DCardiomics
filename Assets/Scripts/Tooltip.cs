using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private Hashtable table = new Hashtable();
    private Text selectionText;
    private float value;

    private void Start()
    {
        selectionText = GameObject.Find("SelectionText").GetComponent<Text>();
    }

    private void OnMouseEnter()
    {
        string s = gameObject.name + " " + value;
        selectionText.text = s;
    }

    private void OnMouseExit()
    {
        selectionText.text = "";
    }

    public void storeValues(string hp, float exp, float Max, float Min)
    {
        float x = exp / Max;
        Debug.Log(hp + " " + x);
        GameObject.Find(hp).GetComponent<Tooltip>().setValue(x);
    }



    public void setValue(float value)
    {
        this.value = value;
    }
}
