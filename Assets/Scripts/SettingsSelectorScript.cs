using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSelectorScript : MonoBehaviour
{
    public string myKey;
    public string myValue;

    void OnMouseUp()
    {
        PlayerPrefs.SetString(myKey, myValue);
    }
}
