using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

    // Use this for initialization
    public bool mine;

    public Sprite[] Textures;
    public Sprite MineTexture;


    // Use this for initialization
    void Start()
    {
        mine = Random.value < 0.15;

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Gridclass.elements[x, y] = this;
    }

    public void loadTexture(int adjacentCount)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = MineTexture;
        else
        {
            GetComponent<SpriteRenderer>().sprite = Textures[adjacentCount];
        }
    }
    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }

    void OnMouseUpAsButton()
    {
        if (mine)
        {
            Gridclass.uncoverMines();
        }
        else
        {
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            loadTexture(Gridclass.adjacentMines(x, y));

            Gridclass.Uncover(x, y, new bool[Gridclass.w, Gridclass.h]);

            if (Gridclass.IsFinished())
                print("ggez");
        }
    }
}
