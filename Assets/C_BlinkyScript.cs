using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BlinkyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int g_presentNodeIndex, g_targetNodeIndex;
    float g_speed;
    e_dir g_currentDir;
    e_dir g_nextDir;
    public C_GameManager g_GameManager;
    void Start()
    {
        g_presentNodeIndex = 142;
        g_speed = 4;
        g_targetNodeIndex = g_presentNodeIndex;
        g_currentDir = e_dir.left;
    }

    // Update is called once per frame
    void Update()
    {
        m_findDirection();
        m_move();
    }
    void m_findDirection()
    {
        m_findDistance(g_GameManager.g_PlayerManager.transform.position, this.transform.position);
    }
    void m_findDistance(Vector3 l_playerPos, Vector3 l_MyPos)
    {
        if(l_playerPos.x < l_MyPos.x)
        {
            g_currentDir = e_dir.left;
        }
        else if(l_playerPos.x != l_MyPos.x)
        {
            g_currentDir = e_dir.right;
        }
        if(l_playerPos.y < l_MyPos.y)
        {
            g_nextDir = e_dir.down;
        }
        else if(l_playerPos.y != l_MyPos.y)
        {
            g_nextDir = e_dir.up;
        }
       
    }
    void m_findNodeToMove()
    {

        if (g_currentDir == e_dir.left)
        {
            if (g_GameManager.g_LevelManager.g_blocks[g_presentNodeIndex].GetComponent<c_nodePrefabScript>().g_leftIndex >= 0)
            {
                g_targetNodeIndex = g_GameManager.g_LevelManager.g_blocks[g_presentNodeIndex].GetComponent<c_nodePrefabScript>().g_leftIndex;
            }
            else
            {
                g_targetNodeIndex = g_presentNodeIndex;
            }
        }
        if (g_currentDir == e_dir.right)
        {
            if (g_GameManager.g_LevelManager.g_blocks[g_presentNodeIndex].GetComponent<c_nodePrefabScript>().g_rightIndex >= 0)
            {
                g_targetNodeIndex = g_GameManager.g_LevelManager.g_blocks[g_presentNodeIndex].GetComponent<c_nodePrefabScript>().g_rightIndex;
            }
            else
            {
                g_targetNodeIndex = g_presentNodeIndex;
            }
        }
        if (g_currentDir == e_dir.up)
        {
            if (g_GameManager.g_LevelManager.g_blocks[g_presentNodeIndex].GetComponent<c_nodePrefabScript>().g_topIndex >= 0)
            {
                g_targetNodeIndex = g_GameManager.g_LevelManager.g_blocks[g_presentNodeIndex].GetComponent<c_nodePrefabScript>().g_topIndex;
            }
            else
            {
                g_targetNodeIndex = g_presentNodeIndex;
            }
        }
        if (g_currentDir == e_dir.down)
        {
            if (g_GameManager.g_LevelManager.g_blocks[g_presentNodeIndex].GetComponent<c_nodePrefabScript>().g_bottomIndex >= 0)
            {
                g_targetNodeIndex = g_GameManager.g_LevelManager.g_blocks[g_presentNodeIndex].GetComponent<c_nodePrefabScript>().g_bottomIndex;
            }
            else
            {
                g_targetNodeIndex = g_presentNodeIndex;
            }
        }
    }
    void m_move()
    {
        Vector2 l_targetDirection = g_GameManager.g_LevelManager.g_blocks[g_targetNodeIndex].transform.position - g_GameManager.g_LevelManager.g_blocks[g_presentNodeIndex].transform.position;

        this.transform.Translate(l_targetDirection * g_speed * Time.deltaTime, Space.World);
        if (g_currentDir == e_dir.left)
        {
            if (transform.position.x - g_GameManager.g_LevelManager.g_blocks[g_targetNodeIndex].transform.position.x <= 0)
            {
                this.transform.position = g_GameManager.g_LevelManager.g_blocks[g_targetNodeIndex].transform.position;
                g_presentNodeIndex = g_targetNodeIndex;
            }
        }
        else if (g_currentDir == e_dir.right)
        {
            if (transform.position.x - g_GameManager.g_LevelManager.g_blocks[g_targetNodeIndex].transform.position.x >= 0)
            {
                this.transform.position = g_GameManager.g_LevelManager.g_blocks[g_targetNodeIndex].transform.position;
                g_presentNodeIndex = g_targetNodeIndex;
            }
        }
        else if (g_currentDir == e_dir.up)
        {
            if (transform.position.y - g_GameManager.g_LevelManager.g_blocks[g_targetNodeIndex].transform.position.y >= 0)
            {
                this.transform.position = g_GameManager.g_LevelManager.g_blocks[g_targetNodeIndex].transform.position;
                g_presentNodeIndex = g_targetNodeIndex;
            }
        }
        else if (g_currentDir == e_dir.down)
        {
            if (transform.position.y - g_GameManager.g_LevelManager.g_blocks[g_targetNodeIndex].transform.position.y <= 0)
            {
                this.transform.position = g_GameManager.g_LevelManager.g_blocks[g_targetNodeIndex].transform.position;
                g_presentNodeIndex = g_targetNodeIndex;
            }
        }

        if (g_targetNodeIndex == g_presentNodeIndex)
        {
            m_checkForNextDir();
            m_findNodeToMove();
        }
    }
    void m_checkForNextDir()
    {
        if (g_nextDir == e_dir.left)
        {
            if (g_GameManager.g_LevelManager.g_blocks[g_presentNodeIndex].GetComponent<c_nodePrefabScript>().g_leftIndex >= 0)
            {
                g_currentDir = g_nextDir;
            }
        }
        else if (g_nextDir == e_dir.right)
        {
            if (g_GameManager.g_LevelManager.g_blocks[g_presentNodeIndex].GetComponent<c_nodePrefabScript>().g_rightIndex >= 0)
            {
                g_currentDir = g_nextDir;
            }
        }
        else if (g_nextDir == e_dir.up)
        {
            if (g_GameManager.g_LevelManager.g_blocks[g_presentNodeIndex].GetComponent<c_nodePrefabScript>().g_topIndex >= 0)
            {
                g_currentDir = g_nextDir;
            }
        }
        else if (g_nextDir == e_dir.down)
        {
            if (g_GameManager.g_LevelManager.g_blocks[g_presentNodeIndex].GetComponent<c_nodePrefabScript>().g_bottomIndex >= 0)
            {
                g_currentDir = g_nextDir;
            }
        }
    }
}
