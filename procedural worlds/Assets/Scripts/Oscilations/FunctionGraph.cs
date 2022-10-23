using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionGraph : MonoBehaviour
{
    [SerializeField] private GameObject m_pointPrefab;
    [SerializeField] private int m_totalSamplePoints=10;
    [SerializeField] private float m_separation = 0.5f;
    GameObject[] m_points; 

    // Start is called before the first frame update
    void Start()
    {
        m_points = new GameObject[m_totalSamplePoints];
        for (int i = 0; i < m_totalSamplePoints; ++i)
        {
            m_points[i] = Instantiate(m_pointPrefab, transform);            
        }
    }


    private void UpdatePoints()
    {
        for (int i = 0; i < m_points.Length; ++i)
        {
            var newPoint = m_points[i];
            Vector3 curposition = newPoint.transform.position;

            //evaluate the function
            curposition.x = i * m_separation;
            curposition.y = Mathf.Sin(curposition.x + Time.time);

            newPoint.transform.position = curposition;
        }
    }

    private void Update()
    {
        UpdatePoints();
    }
}
