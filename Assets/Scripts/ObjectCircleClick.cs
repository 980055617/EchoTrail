using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectCircleClick : MonoBehaviour, IPointerClickHandler
{
    GameObject parent;
    GameObject scrollView;
    PutSystem putSystem;

    void Start()
    {
        parent = GameObject.Find("Canvas");
        scrollView = parent.transform.Find("ScrollView").gameObject;
        putSystem = GameObject.Find("PuySystem").GetComponent<PutSystem>();
    }

    // クリックされたときに呼び出されるメソッド
    public void OnPointerClick(PointerEventData eventData)
    {
        scrollView.SetActive(true);
        putSystem.spawnPoint = this.transform;
    }
}
