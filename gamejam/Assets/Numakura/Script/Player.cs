using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    [SerializeField]
    private GameObject m_field;


    private Animator anim;
    public Vector2 speed = new Vector2(0.5f, 0.5f);


    float tempo = 0.1f;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Move(tempo);
        Action();

        if (Input.GetKey("left"))
        {
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey("right"))
        {
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey("up"))
        {
            anim.SetBool("Walk", true);
        }
        else if(Input.GetKey("down")){
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
	}

    void Move(float tempo)
    {
        Vector2 Position = transform.position;

        if (Input.GetKey("right"))
        {
            Position.x += speed.x * tempo;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (Input.GetKey("left"))
        {
            Position.x -= speed.x * tempo;
            transform.rotation = new Quaternion(0, -180, 0, 0);
        }

         if (Position.y < 4.4f)
        {
            if (Input.GetKey("up"))
            {
                Position.y += speed.x * tempo;
                m_field.transform.position -= new Vector3(0, 0.02f, 0);
                transform.rotation = transform.rotation;
            }
        }
        if (Position.y > -2.8f)
        {
            if (Input.GetKey("down"))
            {
                Position.y -= speed.x * tempo;
                m_field.transform.position += new Vector3(0, 0.02f, 0);
                transform.rotation = transform.rotation;
            }
        }
            transform.position = Position;
            transform.LookAt(transform.position);
 
    }

    

    void Action()
    {
        
    }

    void OnTriggerStay2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "Wall")
        {
            Debug.Log("wall");
        }


        if (colider.gameObject.tag == "Volcano")
        {

            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Volcano");
            }
        }

        if (colider.gameObject.tag == "Plaza")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Plaza");
            }
        }
        if (colider.gameObject.tag == "Cave")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Cave");
            }
        }


    }
}

