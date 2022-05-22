using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdressManager : MonoBehaviour
{
   public static string adress;
   public GameObject inputField;

    void Update()
    {
        adress = inputField.GetComponent<Text>().text;
    }
}
