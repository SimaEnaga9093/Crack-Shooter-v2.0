using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWing : MonoBehaviour
{
    protected bool bIsProtect = true;
    public bool IsProtect { set { bIsProtect = value; } get { return bIsProtect; } }

    protected void Update()
    {
        GetComponent<Animator>().SetBool("Protect", bIsProtect);
    }
}
