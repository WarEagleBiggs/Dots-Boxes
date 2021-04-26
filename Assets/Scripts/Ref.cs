using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Ref : MonoBehaviour
{
    public GameObject m_Line;
    public GameObject m_LineColorChild;
    public GameObject m_FilledSquare;
    public GameObject m_Obj1;
    public GameObject m_Obj2;
    public bool m_isObj1Selected;
    public bool m_isObj2Selected;
    public bool m_isTeam1Turn;
    public bool m_isTeam2Turn;

    public float m_DistanceBetweenDots;

    public enum DotState {
        OpenState,
        PlayerOneState,
        PlayerTwoState,
    }

    public class DotType
    {
        public GameObject m_Object = null;
        public DotState m_State = DotState.OpenState;
    }

    public GameObject m_DotPrefab;
    public Transform m_DotParent;

    // dot array column, row order
    // bottom to top, left to right
    private DotType[,] m_DotMap;

    public Vector3 m_InitialDotPosition;

    public int m_NumCols = 5;
    private int m_PrevNumCols = 0;

    public int m_NumRows = 9;
    private int m_PrevNumRows = 0;

    public void Update()
    {
        InitDotMap();
        
        Debug.Log(m_Obj1 + " " + m_Obj2);

    }
    private void InitDotMap()
    {
        if (m_DotMap == null || 
            m_PrevNumCols != m_NumCols || 
            m_PrevNumRows != m_NumRows) 
        {
            Debug.Log("init");
            m_DotMap = new DotType[m_NumCols, m_NumRows];
            for (int c = 0; c < m_NumCols; c++) {
                for (int r = 0; r < m_NumRows; r++) {
                    
                    // instantiate dot game object
                    GameObject obj = GameObject.Instantiate(m_DotPrefab);

                    // position the dot
                    obj.transform.SetParent(m_DotParent, false);

                    obj.transform.localPosition = m_InitialDotPosition;




                    m_DotMap[c, r].m_Object = obj;


                }
            } 
        }
    }

    private void Start()
    {
        m_isTeam1Turn = true;
    }


    public void DrawLine()
    {


        float distance = (m_Obj2.transform.position - m_Obj1.transform.position).magnitude;
        bool isNeighborCell = (distance > (m_DistanceBetweenDots + 0.1f)) ? false : true;
        if (isNeighborCell) {

            GameObject m_LineClone = Instantiate(m_Line);
            m_LineClone.transform.position = m_Obj1.transform.position;

            // rotate line clone torward obj2
            float deltaX = m_Obj2.transform.position.x - m_Obj1.transform.position.x;
            float deltaY = m_Obj2.transform.position.y - m_Obj1.transform.position.y;
            float alphaRad = Mathf.Atan2(deltaY, deltaX);
            m_LineClone.transform.rotation =
                Quaternion.AngleAxis(alphaRad * Mathf.Rad2Deg,
                                        new Vector3(0, 0, 1));
            if (m_isTeam1Turn == true) {
                SpriteRenderer rend = m_LineColorChild.GetComponentInChildren<SpriteRenderer>();
                rend.color = Color.red;
                m_isTeam1Turn = false;
                m_isTeam2Turn = true;
            } else if (m_isTeam2Turn == true) {
                SpriteRenderer rend = m_LineColorChild.GetComponentInChildren<SpriteRenderer>();
                rend.color = Color.blue;

                m_isTeam2Turn = false;
                m_isTeam1Turn = true;
            }

        }

        Reset();
    }


    public void Reset()
    {
        m_Obj1 = null;
        m_Obj2 = null;
        m_isObj1Selected = false;
        m_isObj2Selected = false;
    }

}
