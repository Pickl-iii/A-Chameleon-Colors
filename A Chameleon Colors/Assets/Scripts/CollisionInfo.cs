using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInfo : MonoBehaviour
{
    private float boxWidth;
    private float boxHeight;
    private float circleRadius;

    public float MinX { get { return transform.position.x - (GetComponent<SpriteRenderer>().bounds.size.x / 2); } }
    public float MaxX { get { return transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2); } }
    public float MinY { get { return transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y / 2); } }
    public float MaxY { get { return transform.position.y + (GetComponent<SpriteRenderer>().bounds.size.y / 2); } }

    public float CircleRadius { get { return circleRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<SpriteRenderer>().bounds.size.y >= GetComponent<SpriteRenderer>().bounds.size.x)
        { circleRadius = GetComponent<SpriteRenderer>().bounds.size.y / 2; }
        else
        { circleRadius = GetComponent<SpriteRenderer>().bounds.size.x / 2; }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireSphere (transform.position, circleRadius);
        Gizmos.DrawWireCube(transform.position, GetComponent<SpriteRenderer>().bounds.size);
    }


}
