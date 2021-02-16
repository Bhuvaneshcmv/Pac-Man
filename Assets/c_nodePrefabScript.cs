using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_nodePrefabScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> g_background = new List<Sprite>();
    public int g_type;
    public SpriteRenderer g_spriteRenderer;
    public int g_leftIndex;
    public int g_rightIndex;
    public int g_topIndex;
    public int g_bottomIndex;
    public int g_index;
    void Start()
    {
        g_spriteRenderer = GetComponent<SpriteRenderer>();
        g_spriteRenderer.sprite = g_background[g_type];
        if(g_type==1)this.transform.localScale = new Vector3(1, 1, 1);
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
