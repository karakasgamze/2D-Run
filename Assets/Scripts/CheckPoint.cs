using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Sprite Scarecrow, Dummy;
    private SpriteRenderer sprrender;
    private bool checkpointCheck = false;

    void Start()
    {
        sprrender = GetComponent<SpriteRenderer>();
        sprrender.sprite = Dummy;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            checkpointCheck = true;
            sprrender.sprite = Scarecrow;
        }
    }
}
