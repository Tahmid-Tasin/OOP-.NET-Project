// NEW: Store/service/CartStore.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.service
{
    /// <summary>
    /// Global, reusable cart state shared across the whole WinForms app.
    /// Key = (CompanyId, BranchId, ProductId)  -> Quantity
    /// </summary>
    public static class CartStore
    {
        public static readonly Dictionary<Tuple<int,int,int>, int> Items = new Dictionary<Tuple<int,int,int>, int>();

        public static bool IsEmpty => Items.Count == 0;
        public static int TotalQuantity => Items.Values.Sum();

        public static event EventHandler Changed;

        public static void SetQuantity(Tuple<int,int,int> key, int qty)
        {
            if (qty <= 0) Items.Remove(key);
            else Items[key] = qty;
            Changed?.Invoke(null, EventArgs.Empty);
        }

        public static void Remove(Tuple<int,int,int> key)
        {
            if (Items.Remove(key))
                Changed?.Invoke(null, EventArgs.Empty);
        }

        public static void Clear()
        {
            if (Items.Count == 0) return;
            Items.Clear();
            Changed?.Invoke(null, EventArgs.Empty);
        }
    }
}
