using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mav : MonoBehaviour
{
    public Rigidbody rb;
    public float FnB = 500;
    public float LnR = 10;
    private bool ground = false;
    public float jampfurc = 100;
    public Rigidbody rbb;
    public Transform rbbb;
    private bool begone = false;
    public Transform nbbb;
    public Rigidbody nbb;
    public Rigidbody sb;
    public Rigidbody fb;
    private bool snapmav = false;
    public Material MavWered;
    private Material OG;
    private bool begoneMode = false;
    public Material begoneMat;
    private Material current;
    private bool coolSwitch = false;
    public Image CoolSwitchInd;
    public Text Cooooooooooooooooooords;
    public Rigidbody tb;


    public bool w, a, s, d, space, item1, item2 = false;

    // Start is called before the first frame update
    void Start()
    {
        OG = GetComponent<Renderer>().material;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Cooooooooooooooooooords.text = transform.position.ToString();
        if (Input.GetKeyUp("z"))
        {
            coolSwitch = !coolSwitch;
            if (coolSwitch){
                CoolSwitchInd.color = new Color(255,0,0,1);
            }
            else{
                CoolSwitchInd.color = new Color(0,0,0,1);
            }
        }
        if (Input.GetKeyUp("t"))
        {
            transform.Rotate(transform.up, 90.0f);
        }
        if (Input.GetKeyUp("1"))
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (!(coolSwitch && Physics.Raycast(transform.position, fwd, 1)))
            {
                Instantiate(rbb, rbbb.position + new Vector3(0.1f,0,-0.3f), rbbb.rotation);
            }
            item1 = true;
        }
        if (Input.GetKeyUp("2"))
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (!(coolSwitch && Physics.Raycast(transform.position, fwd, 1)))
            {
                Instantiate(nbb, rbbb.position + new Vector3(0.1f,0,-0.3f), rbbb.rotation);
            }
            item2 = true;
        }
        if (Input.GetKeyUp("3"))
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (!(coolSwitch && Physics.Raycast(transform.position, fwd, 1)))
            {
                Instantiate(sb, rbbb.position + new Vector3(0.1f,0,-0.3f), rbbb.rotation);
            }
            
        }
        if (Input.GetKeyUp("4"))
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (!(coolSwitch && Physics.Raycast(transform.position, fwd, 1)))
            {
                Instantiate(fb, rbbb.position + new Vector3(0.1f,0,-0.3f), rbbb.rotation);
            }
            
        
        }
        if (Input.GetKeyUp("5"))
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (!(coolSwitch && Physics.Raycast(transform.position, fwd, 1)))
            {
                Instantiate(sb, rbbb.position + new Vector3(0.1f,0,-0.3f), rbbb.rotation);
            }
            
        
        }
        if (Input.GetKeyUp("6"))
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (!(coolSwitch && Physics.Raycast(transform.position, fwd, 1)))
            {
                Instantiate(tb, rbbb.position + new Vector3(0.1f,0,-0.3f), rbbb.rotation);
            }
            
        
        }
        if (Input.GetKeyUp("e"))
        {
            
            snapmav = !snapmav;
            if (snapmav)
            {
                rb.velocity = Vector3.zero;
                this.rb.useGravity = false;
                GetComponent<Renderer>().material = MavWered;
            }
            else
            {
                this.rb.useGravity = true;
                GetComponent<Renderer>().material = OG;
            }

            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
            rb.AddForce(0, 0, 0);
        }
        if (Input.GetKeyUp("q"))
        {
            begoneMode = !begoneMode;
        }
        
    }
    void FixedUpdate() 
    {
        if (begoneMode)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1.0f))
            {
                current = GetComponent<Renderer>().material;
                GetComponent<Renderer>().material = begoneMat;
                Destroy(hit.transform.gameObject);
            }
        }
        if (snapmav)
        {
            if (Input.GetKeyUp("w"))
            {
                transform.position += transform.forward;
            }
            if (Input.GetKeyUp("a"))
            {
                 transform.position -= transform.right;
            }
            if (Input.GetKeyUp("d"))
            {
                 transform.position += transform.right;
            }
            if (Input.GetKeyUp("s"))
            {
                 transform.position -= transform.forward;
            }
            if (Input.GetKeyUp("space"))
            {
                transform.position += new Vector3(0,1,0);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                transform.position += new Vector3(0,-1,0);
            }
            
        }
        else
        {
            if (Input.GetKey("w"))
            {
                rb.AddForce(transform.forward * FnB * Time.deltaTime);
                w = true;
            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(transform.right * LnR * -1 * Time.deltaTime);
                a = true;
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(transform.right * LnR * Time.deltaTime);
                d = true;
            }
            if (Input.GetKey("s"))
            {
                rb.AddForce(transform.forward * FnB * -1 * Time.deltaTime);
                s = true;
            }
            if (ground == true)
        {
            if (Input.GetKey("space"))
            {
                if (ground == true)
                {
                    rb.AddForce(0,jampfurc,0 * Time.deltaTime);
                    ground = false;
                }
                    space = true;
            }
        }
        }
        
    }
    
    void OnCollisionEnter(UnityEngine.Collision collisioninfo)
    {
        if (collisioninfo.gameObject.tag == "jumpable" || collisioninfo.gameObject.tag == "object")
        {
            ground = true;
        }
    }
}
