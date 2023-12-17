using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceNodeType
{
    Undefined,
    Tree,
    Ore
}

[CreateAssetMenu(menuName="Data/Tool Action/Gather Resource Node")]
public class GatherResourceNode : ToolAction
{
    [SerializeField] List<ResourceNodeType> canHitNodesOfType;
    public override bool OnApply(Vector2 worldPoint)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(worldPoint, .5f);
        foreach (var item in colliders)
        {
            ToolHit hit = item.GetComponent<ToolHit>();
            if (hit != null)
            {
                Debug.DrawLine(hit.transform.position, worldPoint, Color.red, 1.5f);
                if (hit.CanBeHit(canHitNodesOfType))
                {
                    hit.Hit();
                    return true;
                }
            }
        }
        return false;
    }
}
