# how-to-customize-the-swipe-view-in-.net-maui-listview
This example demonstrates how to customize the appearance of the swipe view in .Net Maui ListView

## Sample

```xaml
<ListView:SfListView Grid.Row="1"
                        x:Name="listView"
                        ItemsSource="{Binding InboxInfo}"
                        AllowSwiping="True"
                        SwipeThreshold="50"
                        SwipeOffset="100"
                        SelectionMode="Multiple"
                        SelectionGesture="LongPress"
                        ScrollBarVisibility="Always"
                        AutoFitMode="Height">

    <ListView:SfListView.StartSwipeTemplate>
        <DataTemplate>
            <Grid BackgroundColor="#DD0000">
                <Grid.GestureRecognizers>
                    <TapGestureRecognizer Command="{Binding Path=BindingContext.ArchiveCommand, Source={x:Reference listView}}"
                                            CommandParameter="{Binding .}" />
                </Grid.GestureRecognizers>
            </Grid>
        </DataTemplate>
    </ListView:SfListView.StartSwipeTemplate>
    <ListView:SfListView.EndSwipeTemplate>
        <DataTemplate>
            <Grid BackgroundColor="#DD0000"
                    x:Name="listViewGrid">
                <Grid.GestureRecognizers>
                    <TapGestureRecognizer  Command="{Binding Path=BindingContext.DeleteImageCommand, Source={x:Reference listView}}"
                                            CommandParameter="{Binding .}" />
                </Grid.GestureRecognizers>
            </Grid>
        </DataTemplate>
    </ListView:SfListView.EndSwipeTemplate>
    <ListView:SfListView.ItemTemplate>
        <DataTemplate>
            <code>
            . . .
            . . .
            <code>
                <Label Grid.Row="1"
                        Grid.Column="2"
                        Grid.RowSpan="2"
                        Margin="0,0,16,0"
                        Text="{Binding IsFavorite,Converter={StaticResource favoriteIconConverter}}"
                        FontFamily='{OnPlatform Android=ListViewFontIcons.ttf#,UWP=ListViewFontIcons.ttf#ListViewFontIcons,MacCatalyst=ListViewFontIcons,iOS=ListViewFontIcons}'
                        TextColor="{Binding IsFavorite,Converter={StaticResource favoriteIconColorConverter}}"
                        HorizontalOptions="End"
                        FontSize="18"
                        VerticalOptions="Center">
                    <Label.GestureRecognizers>
                        <TapGestureRecognizer Command="{Binding Path=BindingContext.FavoritesImageCommand, Source={x:Reference listView}}"
                                                CommandParameter="{Binding .}" />
                    </Label.GestureRecognizers>
                </Label>
        </DataTemplate>
    </ListView:SfListView.ItemTemplate>
</ListView:SfListView>

C#:

(bindable.BindingContext as ListViewSwipingViewModel).ResetSwipeView += ListViewSwipingBehavior_ResetSwipeView;
ListView.ItemTapped += ListView_ItemTapped;

private void ListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
{
    (e.DataItem as ListViewInboxInfo).IsOpened = true;
}

private void ListViewSwipingBehavior_ResetSwipeView(object sender, ResetEventArgs e)
{
    ListView!.ResetSwipeItem();
}

ViewModel.cs:

this.IsDeleted = false;
ListViewInboxInfoRepository inboxinfo = new ListViewInboxInfoRepository();
archivedMessages = new ObservableCollection<ListViewInboxInfo>();
inboxInfo = inboxinfo.GetInboxInfo();
deleteImageCommand = new Command(Delete);
undoCommand = new Command(UndoAction);
favoritesImageCommand = new Command(SetFavorites);
archiveCommand = new Command(Archive);

private async void Delete(object item)
{
    PopUpText = "Deleted";
    listViewItem = (ListViewInboxInfo)item;
    listViewItemIndex = inboxInfo!.IndexOf(listViewItem);
    inboxInfo!.Remove(listViewItem);
    this.IsDeleted = true;
    await Task.Delay(3000);
    this.IsDeleted = false;
}

private async void Archive(object item)
{
    PopUpText = "Archived";
    listViewItem = (ListViewInboxInfo)item;
    listViewItemIndex = inboxInfo!.IndexOf(listViewItem);
    inboxInfo!.Remove(listViewItem);
    archivedMessages!.Add(listViewItem);
    this.IsDeleted = true;
    await Task.Delay(3000);
    this.IsDeleted = false;
}

private void UndoAction()
{
    this.IsDeleted = false;
    if (listViewItem != null)
    {
        inboxInfo!.Insert(listViewItemIndex, listViewItem);
    }
    listViewItemIndex = 0;
    listViewItem = null;
}

private void SetFavorites(object item)
{
    var listViewItem = item as ListViewInboxInfo;
    if ((bool)listViewItem!.IsFavorite)
    {
        listViewItem.IsFavorite = false;
    }
    else
    {
        listViewItem.IsFavorite = true;
    }
    OnResetSwipe(new ResetEventArgs());
}
```
