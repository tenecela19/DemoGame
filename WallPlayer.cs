using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPlayer : MonoBehaviour
{
    public float speed = 10;
    public WallProjection bounds;
    BoxCollider box;
    public GameObject player;
    public float offsetZ;
    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        
        //player = GameObject.FindGameObjectWithTag("Player");
        box = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        Movement();

    }
    // Update is called once per frame
    void Update()
    {
        ToPlayer();
    }
    void Movement()
    {
        DetectObjectBehind();
        if (bounds != null)
        {
            float HorizontalInput = Input.GetAxis("Horizontal");
            float VerticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector2(HorizontalInput * speed, VerticalInput * speed);
            transform.Translate(movement);
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(transform.position.x, bounds.MinX + box.bounds.extents.x, bounds.MaxX - box.bounds.extents.x);
            pos.y = Mathf.Clamp(transform.position.y, bounds.MinY + box.bounds.extents.x, bounds.MaxY - box.bounds.extents.y);
            pos.z = bounds.transform.position.z + offsetZ ;
            transform.position = pos;
        }

    }
    void ToPlayer()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
            player.SetActive(true);
            gameObject.SetActive(false);
            FindObjectOfType<CinemachineSwitcher>().SwithCamera();
        }
    }
    void DetectObjectBehind()
    {
        RaycastHit hit;
        float distance = 3f;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, distance))
        {
            bounds= hit.transform.GetComponent<WallProjection>();
            Debug.Log("FIND");
        }
        else {

        }

    }
}
