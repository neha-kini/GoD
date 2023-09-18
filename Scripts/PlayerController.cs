using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public Rigidbody2D rb;

    public Transform bottomLeftLimit, topRightLimit;

    public Transform shotPoint;
    public GameObject shot;

    public float timeBetweenShots = .1f;
    private float shotCounter;


    public bool doubleShotActive;
    public float doubleShotOffset;


    public bool stopMovement;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopMovement)
        {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y), transform.position.z);

        if(Input.GetButtonDown("Fire1"))
        {
            if(!doubleShotActive)
            {
            Instantiate(shot, shotPoint.position, shotPoint.rotation);
            }
            else
            {
                Instantiate(shot, shotPoint.position + new Vector3(0f, doubleShotOffset, 0f), shotPoint.rotation);
                Instantiate(shot, shotPoint.position - new Vector3(0f, doubleShotOffset, 0f), shotPoint.rotation);
            }
            shotCounter = timeBetweenShots;
        }

        if(Input.GetButton("Fire1"))
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                if(!doubleShotActive)
            {
            Instantiate(shot, shotPoint.position, shotPoint.rotation);
            }
            else
            {
                Instantiate(shot, shotPoint.position + new Vector3(0f, doubleShotOffset, 0f), shotPoint.rotation);
                Instantiate(shot, shotPoint.position - new Vector3(0f, doubleShotOffset, 0f), shotPoint.rotation);
            }
                shotCounter = timeBetweenShots;
            }
        }
    }
    else
    {
        rb.velocity = Vector2.zero;
    }
    }
}
