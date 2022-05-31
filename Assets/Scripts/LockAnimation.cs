using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LockAnimation : MonoBehaviour
{
    void Start()
    {
      
        this.gameObject.transform.DOMoveY(gameObject.transform.position.y+0.5f, 1.5f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
        Vector3 rotation = new Vector3(this.gameObject.transform.rotation.x, 360, this.gameObject.transform.rotation.z);
        this.gameObject.transform.DOLocalRotate(rotation, 2, RotateMode.FastBeyond360).SetRelative(true).SetLoops(-1).SetEase(Ease.Linear);
    }


}
