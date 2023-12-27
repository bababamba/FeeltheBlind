using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Manager : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject circularMask;
    public GameObject Mask;
    public Light light;
    void Start()
    {
        mainCamera = Camera.main;

    }
    Coroutine coroutine;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);
            // 마우스 클릭한 위치를 중심으로 화면을 원형으로 보이도록 셰이더에 전달
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mainCamera.nearClipPlane));
            
            circularMask.transform.position = worldPosition;
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = StartCoroutine(mask());

        }   
        
        
    
    }

    IEnumerator mask()
    {
        light.range = 10;
        yield return new WaitForSeconds(1);
        light.range = 0;
    }
}
