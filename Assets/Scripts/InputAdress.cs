using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputAdress : MonoBehaviour
{
     ImportNFTIPFS NFTScript;
    public GameObject inputField;
    // Start is called before the first frame update
    public void InputFunction()
    {
        NFTScript.contract = inputField.GetComponent<Text>().text;
        
    }



}
