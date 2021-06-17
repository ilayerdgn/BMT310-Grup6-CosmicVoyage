using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    North, South, East, West
}

public class PlayerMovement : MonoBehaviour {

    public float speed;
    Rigidbody2D rb;
    public Direction movingDir;
    [SerializeField] bool movingHorizontally = false, canCheck = true;
    [SerializeField] LayerMask obstacleMask;
    public GameObject panel;

    private Vector2 startTouchPosition, endTouchPosition;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;



    void Start () {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
    }
	
	void Update () {
        
        if (movingHorizontally)
        {
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1, obstacleMask) || Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1, obstacleMask))
            {
                canCheck = true;
            }
            else
            {
                canCheck = false;
            }
        }
        else
        {
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 1, obstacleMask) || Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 1, obstacleMask))
            {
                canCheck = true;
            }
            else
            {
                canCheck = false;
            }
        }

        if (canCheck)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                movingHorizontally = true;

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    movingDir = Direction.East;
                }
                else
                {
                    movingDir = Direction.West;
                }
            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                movingHorizontally = false;

                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    movingDir = Direction.North;
                }
                else
                {
                    movingDir = Direction.South;
                }
            }
        }

        Swipe();

        /**
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            endTouchPosition = Input.GetTouch(0).position;

            if ((endTouchPosition.x < startTouchPosition.x))
                movingDir = Direction.West;

            if ((endTouchPosition.x > startTouchPosition.x))
                movingDir = Direction.East;

            if ((endTouchPosition.y < startTouchPosition.y))
                movingDir = Direction.South;

            if ((endTouchPosition.y > startTouchPosition.y))
                movingDir = Direction.North;
        */
        

    }

    public void Swipe()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
                Debug.Log("up swipe");
                movingDir = Direction.North;
            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
                Debug.Log("down swipe");
                movingDir = Direction.South;
            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
                Debug.Log("left swipe");
                movingDir = Direction.West;
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
                Debug.Log("right swipe");
                movingDir = Direction.East;
            }
        }
    }

    void FixedUpdate()
    {
        switch(movingDir)
        {
            case Direction.North:
                rb.velocity = new Vector2(0, speed * Time.fixedDeltaTime);
                break;
            case Direction.South:
                rb.velocity = new Vector2(0, -speed * Time.fixedDeltaTime);
                break;
            case Direction.East:
                rb.velocity = new Vector2(speed * Time.fixedDeltaTime, 0);
                break;
            case Direction.West:
                rb.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "bullet")
        {
            Debug.Log("bullet");
            panel.SetActive(true);
            Time.timeScale = 0;
            //  Destroy(gameObject);
        }

        if (collision.gameObject.tag == "gold")
        {
            score.gold += 10;
        }
    }
}
