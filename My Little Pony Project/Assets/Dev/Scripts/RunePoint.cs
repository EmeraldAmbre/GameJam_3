using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePoint : MonoBehaviour
{
    public int m_index;
    public RuneDrawer m_runeDrawer;

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        m_runeDrawer.UpdateDraw(m_index);
    }
}
