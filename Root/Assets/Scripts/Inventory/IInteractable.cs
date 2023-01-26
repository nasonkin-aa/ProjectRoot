using System;
using System.Collections.Generic;
using UnityEngine;
using Visitor;


public interface IInteractable
{
    void Interact(DisplayImage currentDisplay);
}