using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.InventoryEngine;


namespace MoreMountains.InventoryEngine
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MyInventoryManager : MonoBehaviour, MMEventListener<MMInventoryEvent>
    {
        public Inventory MainInventory;
        public AudioSource AudioSource;
        public AudioClip PickSound;
        
        // Start is called before the first frame update
        void Start()
        {
            //get main inventory
            MainInventory = GetComponent<Inventory>();
            //get audio source
            AudioSource = GetComponent<AudioSource>();
            //add listener
            this.MMEventStartListening<MMInventoryEvent>();
        }
        
        //watching MainInventory, if there's new item added, play audio
        public virtual void OnMMEvent(MMInventoryEvent inventoryEvent)
        {
            if (inventoryEvent.InventoryEventType == MMInventoryEventType.Pick)
            {
                AudioSource.PlayOneShot(PickSound);
            }
        }
        
    }
}

