using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    [SerializeField]
    private GameObject m_field;

    [SerializeField]
    private DisasterManager m_disaster;
    private Animator anim;
    public Vector2 speed = new Vector2(0.5f, 0.5f);

    private string m_nowStay = "null";
    private float m_stayTime = 0.0f;
    private int Player_life =1;
    float m_deadTime = 0.0f;
    float tempo = 0.1f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        Player_life = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if (Check())
        {
            m_deadTime += Time.deltaTime;
            anim.SetBool("Walk", true);
            if (m_deadTime > 5)
            {
                Player_life = 0;
            }

            if (Player_life == 0)
            {
                DeadRoot();
                Application.LoadLevel("GameOver");
            }
            return;
        }
       

        if (m_nowStay != "null")
        {
            m_stayTime += Time.deltaTime;
            anim.SetBool("Wait", true);
            if (m_disaster.mIsPlay() || Input.GetKeyDown(KeyCode.Escape))
            {
                anim.SetBool("Wait", false);
                m_nowStay = "null";
                m_stayTime = 0.0f;
            }
            return;
        }

        Move(tempo);

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

    void OnTriggerStay2D(Collider2D colider)
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (colider.gameObject.tag == "Volcano")
            {
                m_nowStay = "Volcano";
            }

            if (colider.gameObject.tag == "Plaza")
            {
                m_nowStay = "Plaza";
            }
            if (colider.gameObject.tag == "Cave")
            {
                Debug.Log("洞窟");
                m_nowStay = "Cave";
            }
            if (colider.gameObject.tag == "Upland")
            {
                m_nowStay = "Upland";
            }
            if (colider.gameObject.tag == "LightningRod")
            {
                m_nowStay = "LightningRod";
            }

        }
    }

    bool Check()
    {
        // とりあえず判定
        var type = m_disaster.GetComponent<DisasterManager>().mGetType();
        if (m_disaster.mIsPlay())
        {
            switch (type)
            {
                case DisasterManager.DisasterType.eEarthquake:
                    if (m_nowStay != "Plaza")
                    {
                        return true;
                    }
                    break;

                case DisasterManager.DisasterType.eEruption:
                    if (m_nowStay != "Cave")
                    {
                        return true;
                    }
                    break;
                case DisasterManager.DisasterType.eFlood:
                    if (m_nowStay != "Upland")
                    {
                        return true;
                    }
                    break;
                case DisasterManager.DisasterType.eThunder:
                    if (m_nowStay != "LightningRod")
                    {
                        return true;
                    }

                    break;
                case DisasterManager.DisasterType.eTyphoon:
                    if (m_nowStay != "Cave")
                    {
                        return true;
                    }
                    break;
            }
        }

        return false;
    }

    void DeadRoot()
    {
        if (m_nowStay == "Volcano")
        {
            PlayerPrefs.SetString(m_nowStay,"噴火から逃げ遅れた");
            
        }

        if (m_nowStay == "Plaza")
        {
            PlayerPrefs.SetString(m_nowStay, "地震強かった");
            
        }
        if (m_nowStay == "Cave")
        {
            PlayerPrefs.SetString(m_nowStay, "噴火から逃げ遅れた");
            
        }
        if (m_nowStay == "Upland")
        {
            PlayerPrefs.SetString(m_nowStay, "洪水から逃げ遅れた");
            
        }
        if (m_nowStay == "LightningRod")
        {
            PlayerPrefs.SetString(m_nowStay, "雷直撃");
            
        }

    }
}

