using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    public void Interact(Collider other);
    public float returnMoney();
    public void playSound();
}
