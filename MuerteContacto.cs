using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteContacto : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMov player = collision.gameObject.GetComponent<PlayerMov>();
            player.dead = true;
            collision.gameObject.SetActive(false);
        }
    }
}
