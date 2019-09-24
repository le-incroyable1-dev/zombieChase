using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScroller : MonoBehaviour {

    private SpriteRenderer sky_renderer;
    public float bgspeed;

    // Start is called before the first frame update
    void Start()
    {
        sky_renderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        SkyOffset();
        
    }

    void SkyOffset()
    {
        sky_renderer.material.mainTextureOffset += new Vector2(bgspeed * Time.deltaTime, 0f);
    }
}
