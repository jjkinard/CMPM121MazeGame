using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl3 : MonoBehaviour
{
    private Animator Anime;

    private void Start()
    {
        Anime = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (GameVariables.count == 1) {
            if (other.tag == "Player")
            {
                Anime.SetBool("open", true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Anime.SetBool("open", false);
        }
    }
}
