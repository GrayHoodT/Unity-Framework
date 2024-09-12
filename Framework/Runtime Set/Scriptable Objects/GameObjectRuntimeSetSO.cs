using UnityEngine;

[CreateAssetMenu(fileName = "New Runtime Set SO", menuName = "Runtime Sets/Game Object")]
public class GameObjectRuntimeSetSO : GenericRuntimeSetSO<GameObject> 
{
    public void DestroyItems()
    {
        foreach (GameObject item in itemList)
        {
            Destroy(item);
        }
    }
}
