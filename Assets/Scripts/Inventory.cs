using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   [SerializeField]
   private List<AssetItem> Items;
   [SerializeField]
   private Cell _cell;
   [SerializeField] 
   private Transform _cellCont;
   [SerializeField]
   private Transform _dragParent;

   public void OnEnable()
   {
      Render(Items);
   }

   public void Render(List<AssetItem> items)
   {
      foreach (Transform child in _cellCont)
         Destroy(child.gameObject);
      
      foreach (Item item in items)
      {
         var cell = Instantiate(_cell, _cellCont);
         cell.Init(_dragParent);
         cell.Render(item);
      }
   }
}
