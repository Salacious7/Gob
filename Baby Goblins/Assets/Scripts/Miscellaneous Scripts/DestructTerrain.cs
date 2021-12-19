using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructTerrain : MonoBehaviour
{
    public Tilemap destructTilemap;
    private void Start()
    {
        destructTilemap = GetComponent<Tilemap>();
    }
      
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain Destroyer"))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach(ContactPoint2D hit in collision.contacts)
            {
                //Debug.Log("Hit?");
                hitPosition.x = hit.point.x + 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y + 0.01f * hit.normal.y;
                //Debug.Log(hitPosition.x);
                //Debug.Log(hitPosition.y);
                destructTilemap.SetTile(destructTilemap.WorldToCell(hitPosition), null);
            }
        }
    }
}
