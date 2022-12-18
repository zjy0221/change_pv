using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class 段落一腳本 : MonoBehaviour
{
    public GameObject 第一段;

    [Header("文本控制")]
    //public Text 文字標籤;
    public TextMeshProUGUI 文字標籤;
    public TextAsset 文本;
    public int 文本行句;
    public float 文字速度;


    public bool 文字是否跑完;
    public bool 是否取消打字;


    List<string> 放行句陣列 = new List<string>();


    // Start is called before the first frame update
    void Awake()
    {
        把文本拆一段一段的 (文本) ;
    }

    private void OnEnable()
    {
        //文字標籤.text = 放行句陣列[文本行句];
        // 文本行句++;

        文字是否跑完 = true;
        StartCoroutine(逐字印出());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            if (文本行句 == 放行句陣列.Count)
            {
                第一段.SetActive(false);
                文本行句 = 0;
                宣傳影片.段落++;
            }

            //文字標籤.text = 放行句陣列 [文本行句] ;
            //文本行句++;
            /*if (文字是否跑完 == true) 
            {
                StartCoroutine(逐字印出());
            }*/

            else if (文字是否跑完 == true && 是否取消打字 == false)
            {
                StartCoroutine(逐字印出());
            }
            else if (文字是否跑完 == false) 
            {
                是否取消打字 = !是否取消打字;  // ( 是變否、否變是 )
            }
        }

    }

    void 把文本拆一段一段的 ( TextAsset A )
    {
        放行句陣列.Clear();
        文本行句 = 0;

        var B = A.text.Split ( '\n' );
        foreach (var 行 in B) 
        {
            放行句陣列.Add(行);
        }
    }

    IEnumerator 逐字印出() 
    {
        文字是否跑完 = false;

        文字標籤.text = "";

        //for (int i = 0; i < 放行句陣列[文本行句].Length; i++) 
        //{
        //    文字標籤.text += 放行句陣列[文本行句][i];

        //    yield return new WaitForSeconds(文字速度);
        //}


        int 字符 = 0;

        while ( 是否取消打字 == false && 字符 < 放行句陣列[文本行句].Length - 1 ) 
        {
            文字標籤.text += 放行句陣列[文本行句][字符];
            字符++;
            yield return new WaitForSeconds(文字速度);
        }
        文字標籤.text = ""; //<<不加這行，會多跑出東西QQ
        文字標籤.text += 放行句陣列[文本行句];
        是否取消打字 = false;

        文字是否跑完 = true;
        文本行句++;
    }

}
