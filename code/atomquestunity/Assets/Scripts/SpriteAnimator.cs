using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public AnimationData baseAnimation;
    Coroutine previousAnimation;

    public void PlayAnimation(AnimationData data)
    {
        if (previousAnimation != null)
        {
            StopCoroutine(previousAnimation);
        }
       
        previousAnimation = StartCoroutine(PlayAnimationCoroutine(data));
        
    }

    public IEnumerator PlayAnimationCoroutine(AnimationData data)

    {
        if (data == null)
        {
            data = baseAnimation;
        }
     
        float waitTime = data.frameOfGap * AnimationData.targetFrameTime;
        int spritesAmount = data.sprites.Length;
        int i = 0;
        while(i < spritesAmount){
            mySpriteRenderer.sprite = data.sprites[i++];
            yield return new WaitForSeconds(waitTime);

            if (data.loop && i >= spritesAmount)
            {
                i = 0;
            }
        }

        yield return null;
    }
}
