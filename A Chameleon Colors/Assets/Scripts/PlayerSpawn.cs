using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private GameObject[] respawns = null;
    private SpriteRenderer sprite;

    void Start()
    {
        respawns = GameObject.FindGameObjectsWithTag("Player");
        sprite = transform.GetComponent<SpriteRenderer>();

        if (respawns.Length == 1)
        {
            transform.position = new Vector3(-5, 0, 1);
            sprite.color = Color.blue;
        }
        else
        {
            transform.position = new Vector3(5, 0, 1);
            sprite.color = Color.red;
        }
    }
}
