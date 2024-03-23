using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using Prism.Regions;

namespace Prism.Forms.Regions.Mocks
{
    /// <summary>
    /// StackPanelRegionAdapter
    /// </summary>
    internal class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public List<string> CreatedRegions = new List<string>();
        public Region Region;

        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (object? sender, NotifyCollectionChangedEventArgs e) =>
            {
                if (sender is UIElement element)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                        regionTarget.Children.Add(element);
                    if (e.Action == NotifyCollectionChangedAction.Remove)
                        regionTarget.Children.Remove(element);
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            var region = new Region();
            this.Region = region;
            return region;
        }
    }
}
