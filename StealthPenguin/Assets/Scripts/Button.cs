using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ButtonManager buttonManager;

    public void switchButton()
    {
        this.enabled = !this.enabled;
    }
}

