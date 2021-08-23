using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject goPlayer;
    private mav instPlayer = new mav();
    public TextMesh txtInstructions;
    public GameObject door;

    private void Awake()
    {
        instPlayer = goPlayer.GetComponent<mav>();
        txtInstructions.text = "Welcome\nUse WASD to move";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (instPlayer.w & instPlayer.a & instPlayer.s & instPlayer.d)
        {
            if (instPlayer.space)
            {
                if(instPlayer.item1 & instPlayer.item2)
                {
                    txtInstructions.text = "Awesome!\nNow I challenge you to get out of this castle with your new found knowledge,\nonce your out of here, feel free to explore!";
                    if(door != null)
                    {
                        Destroy(door);
                    }
                }
                else
                {
                    txtInstructions.text = "Great!\nNow press 1 and 2 to spawn either a cube or a sphere";
                }
            }
            else
            {
                txtInstructions.text = "Now jump\nPress Space";
            }
        }
        else
        {
            txtInstructions.text = "Welcome\nUse WASD to move";
        }
    }
}
