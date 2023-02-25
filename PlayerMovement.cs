using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;
    [SerializeField] private Tilemap liftTilemap;
    public static Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int liftPos = liftTilemap.WorldToCell(new Vector3(rb.position.x, rb.position.y));
        if (liftTilemap.HasTile(liftPos))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKey("right"))//Player moving towards right
        {
            Vector3Int gridPos = groundTilemap.WorldToCell(new Vector3(rb.position.x + 0.3f, rb.position.y));
            if (!collisionTilemap.HasTile(gridPos)&&groundTilemap.HasTile(gridPos)) {
                rb.MovePosition(new Vector3(rb.position.x + 0.1f, rb.position.y));
            }
        }
        if (Input.GetKey("left"))//Player moving towards left
        {
            Vector3Int gridPos = groundTilemap.WorldToCell(new Vector3(rb.position.x - 0.2f, rb.position.y));
            if (!collisionTilemap.HasTile(gridPos) && groundTilemap.HasTile(gridPos))
            {
                rb.MovePosition(new Vector3(rb.position.x - 0.1f, rb.position.y));
            }
        }
        if (Input.GetKey("up"))//Player moving upwards
            {
                
            Vector3Int gridPos = groundTilemap.WorldToCell(new Vector3(rb.position.x, rb.position.y + 0.5f));
            if (!collisionTilemap.HasTile(gridPos) && groundTilemap.HasTile(gridPos))
            {
                rb.MovePosition(new Vector3(rb.position.x, rb.position.y + 0.1f));
            }
            
        }
        if (Input.GetKey("down"))//Player moving downwards
                {
                    
            Vector3Int gridPos = groundTilemap.WorldToCell(new Vector3(rb.position.x, rb.position.y - 0.1f));
            if (!collisionTilemap.HasTile(gridPos) && groundTilemap.HasTile(gridPos))
            {
                rb.MovePosition(new Vector3(rb.position.x, rb.position.y - 0.1f));
            }
        }
    }
}
