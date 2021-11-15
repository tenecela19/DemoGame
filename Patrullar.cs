using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullar : MonoBehaviour
{

    public Transform startPos, endPos;
    public float speed = 100.0f;
    public float WaitingNexposition = 1;




    Vector3 velocity = Vector3.zero;
    Vector3 MoveNextPosition;
    bool? ChangeDirection;
    Rigidbody rg;
    float diff;
    private void Awake()
    {
        //Comenzamos haciendo nulo el recorrido para que no empieze a correr
      //  ChangeDirection = null;
    }
    private void Start()
    {
        //la posicion incial la hacemos la posicion incial de la posicionn que queremos poner
        transform.position = startPos.position;
        
       StartCoroutine(LerpLoop());
    }
    private void Update()
    {
        Repeat();
    }
    IEnumerator LerpLoop()
    {
        //esperamos inicialmente
        yield return new  WaitForSeconds(WaitingNexposition);
        ChangeDirection = false;
        while (true)
        {
            //si la variable ya comenzo a caminar activamos loop

            diff = Vector2.Distance(transform.position, endPos.position);
            if (diff < 1)
            {// si llego a la posicion final esperamos unos segundos y cambiamos
                yield return new WaitForSeconds(WaitingNexposition);

                ChangeDirection = true;
            }

            diff = Vector2.Distance(transform.position, startPos.position);
            if (diff < 1)
            {
                //se repite con el anterior sin embargo de lado contrario
                yield return new WaitForSeconds(WaitingNexposition);

                ChangeDirection = false;
            }
            yield return null;
        }

    }
    public void Repeat()
        
    {
        //nu;a paraa dejarla establecida
        if(ChangeDirection != null)
        {
            //hacemos la variable tipo boleana

            if ((bool)ChangeDirection)
            {
                //si llego a la direccion queremos que vuelva
                MoveNextPosition = startPos.position;
                //con esto hacemos que mueva en la direccion que queremos
            }

            else
            {
                // de otra forma la devolvemos a la posicion final
                MoveNextPosition = endPos.position;

            }
            transform.position = Vector3.SmoothDamp(transform.position, MoveNextPosition, ref velocity, speed * Time.deltaTime);

        }


    }
    }

