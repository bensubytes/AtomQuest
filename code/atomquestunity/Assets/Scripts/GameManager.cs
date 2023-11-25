using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static List<int> collectedItems = new List<int>();
    private static float moveSpeed = 3.5f;
    private static float moveAccuracy = 0.15f;
    public AnimationData[] playerAnimations;
    public RectTransform nameTag;
    public RectTransform hintTag;


    public IEnumerator MoveToPoint(Transform anObject, Vector2 point)
    {
        Vector2 positionDifference = point - (Vector2)anObject.position;
        while (positionDifference.magnitude > moveAccuracy)
        {
            anObject.Translate(moveSpeed*positionDifference.normalized * Time.deltaTime);
            positionDifference = point - (Vector2)anObject.position;
            yield return null;
        }

        anObject.position = point;

        if (anObject == FindObjectOfType<ClickManager>().playerTransform)
        {
            FindObjectOfType<ClickManager>().playerWalking = false;
        }
        yield return null;
    }

    public void UpdateNameTag(ItemData item)
    {
        //change displayed name
        nameTag.GetComponentInChildren<TextMeshProUGUI>().text = item.objectName;
        nameTag.sizeDelta = item.nameTagSize;
        nameTag.localPosition = new Vector2(item.nameTagSize.x/2, -0.5f);
    }

    public void UpdateHintTag(ItemData item, bool playerFlipped)
    {
        if(item == null)
        {
            hintTag.gameObject.SetActive(false);
            return;
        }

        hintTag.gameObject.SetActive(true);

        //change displayed name
        hintTag.GetComponentInChildren<TextMeshProUGUI>().text = item.hintText;
        hintTag.sizeDelta = item.hintTagSize;
        if (playerFlipped)
        {
            hintTag.parent.localPosition = new Vector2(-1, 0);
        } else
        {
            hintTag.parent.localPosition = Vector2.zero;
        }
    }
}
