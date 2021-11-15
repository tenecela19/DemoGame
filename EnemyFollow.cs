using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{

    #region Singleton
    private static EnemyFollow _instance;
    public static EnemyFollow Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<EnemyFollow>();
            }

            return _instance;
        }
    }


    #endregion

    public bool IsInArea;

    public void Awake()
    {
        IsInArea = false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!other.gameObject.CompareTag("Checkpoint"))
            {
                IsInArea = true;
            }
            else IsInArea = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsInArea = false;
        }
    }
}
