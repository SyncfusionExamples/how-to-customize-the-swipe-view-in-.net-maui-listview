using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ListViewMaui.ListViewSwipingViewModel;

namespace ListViewMaui
{
    public class ListViewSwipingBehavior : Behavior<ContentPage>
    {
        private Syncfusion.Maui.ListView.SfListView ListView;
        private ListViewSwipingViewModel ViewModel;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            ViewModel = new ListViewSwipingViewModel();
            bindable.BindingContext = ViewModel;
            ListView = bindable.FindByName<Syncfusion.Maui.ListView.SfListView>("listView");
            (bindable.BindingContext as ListViewSwipingViewModel).ResetSwipeView += ListViewSwipingBehavior_ResetSwipeView;
            ListView.ItemTapped += ListView_ItemTapped;
            base.OnAttachedTo(bindable);
        }

        private void ListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
        {
            (e.DataItem as ListViewInboxInfo).IsOpened = true;
        }

        private void ListViewSwipingBehavior_ResetSwipeView(object sender, ResetEventArgs e)
        {
            ListView!.ResetSwipeItem();
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            (bindable.BindingContext as ListViewSwipingViewModel).ResetSwipeView -= ListViewSwipingBehavior_ResetSwipeView;
            ListView.ItemTapped -= ListView_ItemTapped;
            ListView = null;
            ViewModel = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
