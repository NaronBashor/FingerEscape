using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
        public void ButtonSound()
        {
                GameObject.Find("MenuMusic").GetComponent<MenuMusic>().ButtonSound();
        }
}
