using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    public Player logicplayer;

    private void OnTriggerStay(Collider other)
    {
        logicplayer.SetStateJump(true);
    }

    private void OnTriggerExit(Collider other)
    {
        logicplayer.SetStateJump(false);
    }
}
