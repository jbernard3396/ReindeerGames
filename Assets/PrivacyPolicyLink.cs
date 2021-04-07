using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyPolicyLink : MonoBehaviour
{
    void OnMouseDown()
    {
        Application.OpenURL("https://unity3d.com/legal/privacy-policy");
    }
}
