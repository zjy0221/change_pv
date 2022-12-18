using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 宣傳影片 : MonoBehaviour
{
    public GameObject 第一段;
    public GameObject 第二段;
    public GameObject 第三段;
    public GameObject 第四段;
    public GameObject 第四之一段;
    public GameObject 第四之二段;
    public GameObject 第五段;
    public GameObject 第五之一段;
    public GameObject 第六段;
    public GameObject 第六之一段;
    public GameObject 第七段;

    static public int 段落;

    // Start is called before the first frame update
    void Start()
    {
        第一段.SetActive(true);
        段落 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (段落) 
        {
            case 2:
                第二段.SetActive(true);
                break;
            case 3:
                第三段.SetActive(true);
                break;
            case 4:
                第四段.SetActive(true);
                break;
            case 5:
                第四之一段.SetActive(true);
                break;
            case 6:
                第四之二段.SetActive(true);
                break;
            case 7:
                第五段.SetActive(true);
                break;
            case 8:
                第五之一段.SetActive(true);
                break;
            case 9:
                第六段.SetActive(true);
                break;
            case 10:
                第六之一段.SetActive(true);
                break;
            case 11:
                第七段.SetActive(true);
                break;
        }
    }
}
