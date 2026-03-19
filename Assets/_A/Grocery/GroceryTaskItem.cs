using UnityEngine;
using UnityEngine.UI;

public class GroceryTaskItem : MonoBehaviour
{
    public Image _groceryTaskImage;
    public GroceryItem _groceryItem;

    public void SetTaskItemFields(GroceryItem item)
    {
        _groceryItem = item;
        _groceryTaskImage.sprite = item.GroceryIcon;
    }

    public void FinishTask()
    {
        // Destroy(gameObject);
    }
}