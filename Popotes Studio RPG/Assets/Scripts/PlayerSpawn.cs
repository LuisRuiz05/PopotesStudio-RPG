using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject[] characters;
    public Transform spawnPoint;

    void Start()
    {
        Instantiate(characters[SaveScript.pChar], spawnPoint.position, spawnPoint.rotation);
    }
}
