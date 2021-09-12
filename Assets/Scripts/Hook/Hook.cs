using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hook : MonoBehaviour
{
    public Transform hookTransform;

    private Camera mainCamera;
    private Collider2D myCollider;

    private int length;
    private int strength;
    private int fishCount;

    private bool canMove;

    //List<Fish>

    private Tweener cameraTween;

    private void Awake()
    {
        mainCamera = Camera.main;
        myCollider = GetComponent<Collider2D>();
        //List<Fish>
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && Input.GetMouseButton(0))
        {
            Vector3 vector = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 position = transform.position;
            position.x = vector.x;
            transform.position = position;
        }
    }

    public void StartFishing()
    {
        length = -50; //IdleManager
        strength = 3; //IdleManager
        float time = (-length) * 0.1f;

        cameraTween = mainCamera.transform.DOMoveY(length, 1 + time * 0.25f, false).OnUpdate(delegate
        {
            if (mainCamera.transform.position.y <= -11)
            { transform.SetParent(mainCamera.transform); }
        }).OnComplete(delegate
        {
            myCollider.enabled = true;
            cameraTween = mainCamera.transform.DOMoveY(0, time * 5, false).OnUpdate(delegate
            {

                if (mainCamera.transform.position.y >= -25f)
                { StopFishing(); }

            });
        });

        //screen(GAME)
        myCollider.enabled = false;
        canMove = true;
        //CLEAR HOOK

    }

    public void StopFishing()
    {
        canMove = false;
        cameraTween.Kill(false);
        cameraTween = mainCamera.transform.DOMoveY(0, 2, false).OnUpdate(delegate
        {

            if (mainCamera.transform.position.y >= -11)
            {
                transform.SetParent(null);
                transform.position = new Vector2(transform.position.x, -6);
            }
        }).OnComplete(delegate
        {

            transform.position = Vector2.down * 6;
            myCollider.enabled = true;
            int num = 0;
            //clear fishes
            //IdleManager totalGain = num
            //SceneManager EndScreen
        });
    }
}
