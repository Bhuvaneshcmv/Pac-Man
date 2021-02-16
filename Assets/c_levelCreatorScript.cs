using UnityEngine;

public class c_levelCreatorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject g_backgrooundPrefab;
    public int[] g_typeArray;
    int g_noOfRows, g_noOfColumns;
    public GameObject[] g_blocks;
    void Awake()
    {
        g_typeArray = new int[]{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                                1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1,
                                1, 3, 1, 1, 2, 1, 1, 1, 2, 1, 2, 1, 1, 1, 2, 1, 1, 3, 1,
                                1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1,
                                1, 2, 1, 1, 2, 1, 2, 1, 1, 1, 1, 1, 2, 1, 2, 1, 1, 2, 1,
                                1, 2, 2, 2, 2, 1, 2, 2, 2, 1, 2, 2, 2, 1, 2, 2, 2, 2, 1,
                                1, 1, 1, 1, 2, 1, 1, 1, 0, 1, 0, 1, 1, 1, 2, 1, 1, 1, 1,
                                0, 0, 0, 1, 2, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 1, 0, 0, 0,
                                1, 1, 1, 1, 2, 1, 0, 1, 1, 1, 1, 1, 0, 1, 2, 1, 1, 1, 1,
                                0, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 2, 0, 0, 0, 0,
                                1, 1, 1, 1, 2, 1, 0, 1, 1, 1, 1, 1, 0, 1, 2, 1, 1, 1, 1,
                                0, 0, 0, 1, 2, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 1, 0, 0, 0,
                                1, 1, 1, 1, 2, 1, 0, 1, 1, 1, 1, 1, 0, 1, 2, 1, 1, 1, 1,
                                1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1,
                                1, 2, 1, 1, 2, 1, 1, 1, 2, 1, 2, 1, 1, 1, 2, 1, 1, 2, 1,
                                1, 3, 2, 1, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 1, 2, 3, 1,
                                1, 1, 2, 1, 2, 1, 2, 1, 1, 1, 1, 1, 2, 1, 2, 1, 2, 1, 1,
                                1, 2, 2, 2, 2, 1, 2, 2, 2, 1, 2, 2, 2, 1, 2, 2, 2, 2, 1,
                                1, 2, 1, 1, 1, 1, 1, 1, 2, 1, 2, 1, 1, 1, 1, 1, 1, 2, 1,
                                1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1,
                                1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
        g_noOfRows = 21;
        g_noOfColumns = 19;
        m_createLevel();

    }
    void Start()
    {
        m_findNeighbourNodeType();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void m_createLevel()
    {
        float l_initX = 0;
        float l_X = l_initX;
        float l_Y = 0;
        float l_w = 1;
        float l_h = 16 / 9;
        int l_count = 0;
        for (int j = 0; j < g_noOfRows; j++)
        {
            for (int i = 0; i < g_noOfColumns; i++)
            {
                l_X += l_w;
                g_blocks[l_count] = Instantiate(g_backgrooundPrefab, new Vector2(l_X, l_Y), Quaternion.identity);
                g_blocks[l_count].transform.SetParent(gameObject.transform);
                g_blocks[l_count].GetComponent<c_nodePrefabScript>().g_type = g_typeArray[l_count];
                g_blocks[l_count].GetComponent<c_nodePrefabScript>().g_index = l_count;
                l_count++;
                
            }
            l_Y -= l_h;
            l_X = l_initX;
        }
    }
    void m_findNeighbourNodeType()
    {

        for (int i = 0; i < g_blocks.Length; i++)
        {
            if (i % g_noOfColumns != 0)
            {
                g_blocks[i].GetComponent<c_nodePrefabScript>().g_leftIndex = i-1;
                if (g_blocks[i-1].GetComponent<c_nodePrefabScript>().g_type == 1)
                {
                    g_blocks[i].GetComponent<c_nodePrefabScript>().g_leftIndex = -1;
                }
            }
            else
            {
                g_blocks[i].GetComponent<c_nodePrefabScript>().g_leftIndex = -1;
            }
            if (i % g_noOfColumns != g_noOfColumns-1)
            {
                g_blocks[i].GetComponent<c_nodePrefabScript>().g_rightIndex = i + 1;
                if (g_blocks[i + 1].GetComponent<c_nodePrefabScript>().g_type == 1)
                {
                    g_blocks[i].GetComponent<c_nodePrefabScript>().g_rightIndex = -1;
                }
            }
            else
            {
                g_blocks[i].GetComponent<c_nodePrefabScript>().g_rightIndex = -1;
            }
            if (i >= g_noOfColumns)
            {
                g_blocks[i].GetComponent<c_nodePrefabScript>().g_topIndex =i - g_noOfColumns;
                if (g_blocks[i - g_noOfColumns].GetComponent<c_nodePrefabScript>().g_type == 1)
                {
                    g_blocks[i].GetComponent<c_nodePrefabScript>().g_topIndex = -1;
                }
            }
            else
            {
                g_blocks[i].GetComponent<c_nodePrefabScript>().g_topIndex = -1;
            }
            if (i < ((g_noOfRows - 1) * g_noOfColumns) - 1)
            {
                g_blocks[i].GetComponent<c_nodePrefabScript>().g_bottomIndex = i + g_noOfColumns;
                if (g_blocks[i + g_noOfColumns].GetComponent<c_nodePrefabScript>().g_type == 1)
                {
                    g_blocks[i].GetComponent<c_nodePrefabScript>().g_bottomIndex = -1;
                }

            }
            else
            {
                g_blocks[i].GetComponent<c_nodePrefabScript>().g_bottomIndex = -1;
            }

        }
    }
}
