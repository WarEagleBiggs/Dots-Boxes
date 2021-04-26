using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dots : MonoBehaviour
{
   
    public Ref m_Referee;

    public void OnMouseDown()
    {
        if (m_Referee.m_isObj1Selected == false) {
            m_Referee.m_Obj1 = gameObject;
            m_Referee.m_isObj1Selected = true;
            SpriteRenderer rend = m_Referee.m_Obj1.GetComponent<SpriteRenderer>();
            rend.color = Color.green;
        } else if (m_Referee.m_isObj2Selected == false) {
            m_Referee.m_Obj2 = gameObject;
            m_Referee.m_isObj2Selected = true;
            SpriteRenderer rend = m_Referee.m_Obj1.GetComponent<SpriteRenderer>();
            rend.color = Color.white;
            m_Referee.DrawLine();
        }
    }   

        


}
