using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choose : MonoBehaviour
{
    public GameObject[] characters;
    public Text playerName;
    private int picked = 0;

    public void Next()
    {
        if(picked < characters.Length - 1)
        {
            characters[picked].SetActive(false);
            picked++;
            characters[picked].SetActive(true);
        }
    }

    public void Back()
    {
        if (picked > 0)
        {
            characters[picked].SetActive(false);
            picked--;
            characters[picked].SetActive(true);
        }
    }

    public void Accept()
    {
        SaveScript.pChar = picked;
        SaveScript.pName = playerName.text;

        SceneManager.LoadScene(1);
    }
}
