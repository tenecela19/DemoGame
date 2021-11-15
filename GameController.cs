using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    GameObject player; 
    public float TimeToSpawnPlayer = 2f;
    bool IsPlayerDead()
    {
        if (!player.GetComponent<PlayerMov>().dead && player != null)
        {
            return false;
        }
        else return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");

        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerDead())
        {
           StartCoroutine(Respawn());
        }
    }
   public IEnumerator Respawn()
    {
        player.GetComponent<PlayerMov>().dead = false;
        player.transform.position = new Vector2(CheckPoint.spawn.x, CheckPoint.spawn.y);
        yield return new WaitForSeconds(TimeToSpawnPlayer);
        player.SetActive(true);
    }
}
