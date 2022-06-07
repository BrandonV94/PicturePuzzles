using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPolyColliders : MonoBehaviour
{
    [SerializeField] Component[] sprites;

    void Start()
    {
        sprites = gameObject.transform.GetComponentsInChildren(typeof(SpriteRenderer));

        foreach (var sprite in sprites)
        {
            if (sprite.GetComponent<PolygonCollider2D>() == null && sprite.name != "Main Image")
            {
                sprite.gameObject.AddComponent<PolygonCollider2D>();
                //Debug.Log("Adding PolygonCollider2D to " + sprite.name);
            }
        }
    }
}
