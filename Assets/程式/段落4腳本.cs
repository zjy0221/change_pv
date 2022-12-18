using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class 段落4腳本 : MonoBehaviour
{
    public GameObject 第四段;

    [Header("文本控制")]
    public TextMeshProUGUI 文字區塊;
    public TextAsset 文本;
    public int 行句;
    public float 文字速度;

    public bool 文字是否跑完;
    public bool 是否取消打字;

    List<string> 行句陣列 = new List<string>();

    [Header("畫面")]
    public Image 畫面;
    public Sprite 神圖, 人圖, 咕圖;


    void Awake()
    {
        把文本斷行(文本);
    }

    private void OnEnable()
    {
        文字是否跑完 = true;
        StartCoroutine(逐字印出());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (行句 == 行句陣列.Count)
            {
                第四段.SetActive(false);
                行句 = 0;
                宣傳影片.段落++;
            }

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

    void 把文本斷行(TextAsset A)
    {
        行句陣列.Clear();
        行句 = 0;

        //var B = A.text.Split('%n');
        var B = A.text.Split(new[] { Environment.NewLine }, StringSplitOptions.None); 
        //var B = A.text.Split (new char[]{ '\r', '\n'} , StringSplitOptions.RemoveEmptyEntries);

        foreach (var 行 in B)
        {
            行句陣列.Add(行);
        }
    }

    IEnumerator 逐字印出()
    {
        //設置對應畫面
        switch (行句陣列[行句]) 
        {
            case "神":
                畫面.sprite = 神圖;
                行句++;
                break;

            case "人":
                畫面.sprite = 人圖;
                行句++;
                break;

            case "咕":
                畫面.sprite = 咕圖;
                行句++;
                break;
        }


        文字是否跑完 = false;

        文字區塊.text = "";

        int 字符 = 0;

        while (是否取消打字 == false && 字符 < 行句陣列[行句].Length - 1)
        {
            文字區塊.text += 行句陣列[行句][字符];
            字符++;
            yield return new WaitForSeconds(文字速度);
        }
        文字區塊.text = ""; //<<不加這行，會多跑出東西QQ
        文字區塊.text += 行句陣列[行句];
        是否取消打字 = false;

        文字是否跑完 = true;
        行句++;
    }

}



