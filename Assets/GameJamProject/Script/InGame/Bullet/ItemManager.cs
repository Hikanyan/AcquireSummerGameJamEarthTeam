using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> Items;
    public List<GameObject> SelectItems;
    public Image[] Images;

    private PlyerController _plyerController;

    private void Start()
    {
        _plyerController = FindFirstObjectByType<PlyerController>();
        
        for (int i = 0; i < 3; i++)
        {
            GameObject gameObject = Items[Random.Range(0, Items.Count)];
            NextItem();
        }
    }

    public void NextItem()
    {
        GameObject gameObject = Items[Random.Range(0, Items.Count)];
        SelectItems.RemoveAt(0);
        SelectItems.Add(gameObject);

        Sprite s = gameObject.GetComponent<Bullet>().GetSprite;
        Sprite image = Images[1].sprite;
        Images[0].sprite = image;
        image = Images[2].sprite;
        Images[1].sprite = image;
        Images[2].sprite = s;
    }
}
