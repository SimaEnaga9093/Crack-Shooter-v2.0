using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum HitBarDir
{
    LEFT = 0,
    RIGHT = 1
}

public class HitBar : MonoBehaviour
{
    // Custom
    protected HitBarDir eDir;
    public HitBarDir Dir { set { eDir = value; } }

    protected float fBarPower;
    protected bool bClick;

    // GameObject
    [SerializeField] protected GameObject gBar;

    // -- //

    
    // Main
    public void Init()
    {
        fBarPower = 750.0f;
        bClick = false;

        if (eDir == HitBarDir.RIGHT)
        {
            Quaternion qRot = gBar.transform.rotation;
            qRot.y = 180.0f;
            gBar.transform.rotation = qRot;
        }

        gBar.GetComponent<Bar>().Init();
    }

    protected void Update()
    {
        if (bClick)
            gBar.GetComponent<Rigidbody2D>().AddForce(Vector2.up * fBarPower);
    }

    protected void OnMouseDown()
    {
        bClick = true;
    }

    protected void OnMouseUp()
    {
        bClick = false;
    }

    //

    public void SetCharacter(GameObject[] gCharacter)
    {
        for (int i = 0; i < 2; i++)
            gBar.GetComponent<Bar>().gCharacter[i] = gCharacter[i];
    }
}