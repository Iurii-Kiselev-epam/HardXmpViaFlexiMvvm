using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using UIKit;

namespace VacationsTracker.iOS.Infrastructure.Bindings
{
    internal static class TableViewBindableItemCellBindings
    {
        public static TargetItemBinding<UITableViewCell, UITableViewCellAccessory> AccessoryBinding(
            this IItemReference<UITableViewCell> tableViewCell)
        {
            return new TargetItemOneWayCustomBinding<UITableViewCell, UITableViewCellAccessory>(
                tableViewCell,
                (cell, accessory) => cell.Accessory = accessory,
                () => nameof(UITableViewCell.Accessory));
        }
    }
}