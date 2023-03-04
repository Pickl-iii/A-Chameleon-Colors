using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDespawn : MonoBehaviour
{
    private GameObject[] respawns = null;

    // Update is called once per frame
    void Update()
    {
        respawns = GameObject.FindGameObjectsWithTag("Player");

        if (respawns.Length == 0)
        {
            transform.position = new Vector3(-9.75f, -4f, 0);
        }
        else if (respawns.Length == 1)
        {
            transform.position = new Vector3(3.5f, -4f, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
