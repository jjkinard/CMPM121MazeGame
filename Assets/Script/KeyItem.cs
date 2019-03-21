using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public GameObject enemy;

    private void Start()
    {
        GameVariables.health = 5;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "free_male_1")
        {
            GameVariables.keyCount += 2;
            Destroy(enemy);
            GameVariables.health -= 1;
        }
    }
}
