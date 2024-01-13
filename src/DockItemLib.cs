using System;
using System.Collections.Generic;
using Game.Interface;
using HarmonyLib;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using static Home.Services.InputService;

namespace DockItemLib
{
    public class DockItemCore {
        public static List<CustomDockItem> customDockItems = new();


    }

    [HarmonyPatch(typeof(HudDockPanel))]
    public class CustomDockItemHandler {
        [HarmonyPatch(nameof(HudDockPanel.Start))]
        [HarmonyPrefix]
        public static void AddCustomDockItems(HudDockPanel __instance) {
            DockItemCore.customDockItems.ForEach((cdi) => AddDockItem(__instance, cdi));
        }

        [HarmonyPatch(nameof(HudDockPanel.OnDestroy))]
        [HarmonyPrefix]
        public static void RemoveCustomDockItems(HudDockPanel __instance) {
            DockItemCore.customDockItems.ForEach((cdi) => cdi.dockItem = null);
        }

        private static void AddDockItem(HudDockPanel __instance, CustomDockItem customDockItem) {

            if (!customDockItem.checker() || customDockItem.dockItem != null) return;

            HudDockItem dockItem = UnityEngine.Object.Instantiate(__instance.dockItems[1]);

            dockItem.transform.SetParent(__instance.transform);
            dockItem.transform.localScale = new(1, 1, 1);
            dockItem.transform.SetSiblingIndex(9);

            dockItem.canMove = false;
            dockItem.dockItemType = HudDockItem.DockItemType.GAME_ANY;
            dockItem.label.text = customDockItem.label;
            dockItem.localizationKey = customDockItem.localizationKey;
            dockItem.name = customDockItem.name;
            dockItem.dockFunctionType = DockFunctionType.CHAT;
            
            // Setup hotkey
            HudHotkeyButton hotkeyButton = dockItem.GetComponentInChildren<HudHotkeyButton>();
            hotkeyButton.hotkeyType = customDockItem.hotKeyType;
            hotkeyButton.HandleOnHotKeyChanged(customDockItem.hotKeyType);

            hotkeyButton.eventCallback.RemoveAllListeners();
            hotkeyButton.eventCallback.AddListener(() => customDockItem.listener.Invoke());

            dockItem.hotkeyType = customDockItem.hotKeyType;
            dockItem.HandleOnHotKeyChanged(customDockItem.hotKeyType);

            dockItem.GetComponentInChildren<Image>().sprite = customDockItem.sprite;

            
            dockItem.eventTriggers.triggers.Clear();

            var eventTrigger = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerClick
            };

            eventTrigger.callback.RemoveAllListeners();
            eventTrigger.callback.AddListener((s) => customDockItem.listener.Invoke());
            

            dockItem.eventTriggers.triggers.Add(eventTrigger);

            dockItem.SetupTriggers();

            customDockItem.dockItem = dockItem;
        }
    }

    public class CustomDockItem
    {
        public string name;
        public string label;
        public string localizationKey;
        public Sprite sprite;
        public HotKey.HotKeyType hotKeyType;
        public Action listener;
        public Func<bool> checker;

        public HudDockItem dockItem;

        public CustomDockItem(string name, string label, string localizationKey, Sprite sprite, HotKey.HotKeyType hotKeyType, Action listener, Func<bool> checker) {
            this.name = name;
            this.label = label;
            this.localizationKey = localizationKey;
            this.sprite = sprite;
            this.hotKeyType = hotKeyType;
            this.listener = listener;
            this.checker = checker;

            DockItemCore.customDockItems.Add(this);
        }
    }
}
