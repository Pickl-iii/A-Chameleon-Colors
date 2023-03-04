using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> colliders;

    [SerializeField] private TextMesh UI;

    private bool collisionSystem = false;           // false -> AABB        true -> circle

    // Update is called once per frame
    void Update()
    {
        // Reset Colors
        player.GetComponent<SpriteRenderer>().color = Color.white;
        for(int i = 0; i <colliders.Count; i++)
        {
            colliders[i].GetComponent<SpriteRenderer>().color = Color.white;
        }

        //Check Collisions
        for (int i = 0; i < colliders.Count; i++)
        {
            if(collisionSystem)
            {
                if (CircleCollision(colliders[i], player))
                {
                    player.GetComponent<SpriteRenderer>().color = Color.red;
                    colliders[i].GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
            else
            {
                if (AABBCollision(colliders[i], player))
                {
                    player.GetComponent<SpriteRenderer>().color = Color.red;
                    colliders[i].GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
    }

    bool AABBCollision(GameObject boxA, GameObject boxB)
    {
        if (boxB.GetComponent<CollisionInfo>().MinX < boxA.GetComponent<CollisionInfo>().MaxX
        && boxB.GetComponent<CollisionInfo>().MaxX > boxA.GetComponent<CollisionInfo>().MinX)
        {
            if (boxB.GetComponent<CollisionInfo>().MinY < boxA.GetComponent<CollisionInfo>().MaxY
            && boxB.GetComponent<CollisionInfo>().MaxY > boxA.GetComponent<CollisionInfo>().MinY)
            {
                return true;
            }
        }

        return false;
    }

    bool CircleCollision(GameObject boxA, GameObject boxB)
    {
        float distanceBetweenCenters =
            (boxB.transform.position.y - boxA.transform.position.y) * (boxB.transform.position.y - boxA.transform.position.y)
            + (boxB.transform.position.x - boxA.transform.position.x) * (boxB.transform.position.x - boxA.transform.position.x);
        float totalRadius = (boxB.GetComponent<CollisionInfo>().CircleRadius + boxA.GetComponent<CollisionInfo>().CircleRadius)
            * (boxB.GetComponent<CollisionInfo>().CircleRadius + boxA.GetComponent<CollisionInfo>().CircleRadius);

        if (distanceBetweenCenters < totalRadius)
        {
            return true;
        }
        
        return false;
    }

    public void OnSwitch(InputAction.CallbackContext context)
    {
        if(collisionSystem)
        {
            collisionSystem = false;
            UI.text = "Current Mode: AABB";
        }
        else
        {
            collisionSystem = true;
            UI.text = "Current Mode: Circle";
        }


    }
}
