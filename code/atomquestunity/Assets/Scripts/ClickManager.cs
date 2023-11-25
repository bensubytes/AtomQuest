using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public bool playerWalking;
    public Transform playerTransform;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    public void GoToClick(ItemData item)
    {
        //update hint box
        gameManager.UpdateHintTag(null, false);
        //play walk animation
        playerTransform.GetComponent<SpriteAnimator>().PlayAnimation(gameManager.playerAnimations[1]); 
        playerWalking = true;
        //start moving player
        StartCoroutine(gameManager.MoveToPoint(playerTransform, item.goToPoint.position));
        //equip stuff
        GetItem(item);
      
    }

    public void GetItem(ItemData item)
    {
        bool canGetItem = item.requiredItemID == -1 || GameManager.collectedItems.Contains(item.requiredItemID);
        if (canGetItem)
        {
            GameManager.collectedItems.Add(item.itemID);
        }
        StartCoroutine(UpdateSceneAfterAction(item, canGetItem));
    }

    private IEnumerator UpdateSceneAfterAction(ItemData item, bool canGetItem )
    {
        while(playerWalking)
            yield return new WaitForSeconds(0.05f);
        
        if (canGetItem)
        {
            foreach (GameObject obj in item.itemsToRemove)
            {
                Destroy(obj);
            }
            Debug.Log("item collected");
        }
        else
            gameManager.UpdateHintTag(item, playerTransform.GetComponentInChildren<SpriteRenderer>().flipX);
        

        playerTransform.GetComponent<SpriteAnimator>().PlayAnimation(null);
        
        yield return null;
    }
}
