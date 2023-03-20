using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int pChar = 0;
    public static string pName = "Player";

    void Start()
    {
        DontDestroyOnLoad(this);   
    }
}
