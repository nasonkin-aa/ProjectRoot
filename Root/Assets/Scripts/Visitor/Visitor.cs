using UnityEngine;

namespace Visitor
{
    public interface IVisitor
    {
        public void Visit(ItemUse itemUse)
        {
            Debug.Log(itemUse.name);
            //itemUse.UnlockItem
        }
    }
}
