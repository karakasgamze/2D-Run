using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Character characterkontrol;
    public float RespawnDelay = 2f;

    void Start()
    {
       characterkontrol = FindObjectOfType<Character>();
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        characterkontrol.gameObject.SetActive(false);
        yield return new WaitForSeconds(RespawnDelay);

        characterkontrol.gameObject.SetActive(true);
        characterkontrol.transform.position = characterkontrol.respawnPoint;
    }

}
