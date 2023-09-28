# how-to-customize-the-swipe-view-in-.net-maui-listview

This example demonstrates how to customize the appearance of the swipe view in .Net Maui ListView

## XAML 

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
                <Label Text="&#xe71C;"
                        FontFamily='{OnPlatform Android=ListViewFontIcons.ttf#,UWP=ListViewFontIcons.ttf#ListViewFontIcons,MacCatalyst=ListViewFontIcons,iOS=ListViewFontIcons}'
                        TextColor="#FFFFFF"
                        HorizontalOptions="Center"
                        FontSize="22"
                        FontAttributes="Bold"
                        VerticalOptions="Center">
                </Label>

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
                <Label Text="&#xe716;"
                        FontFamily='{OnPlatform Android=ListViewFontIcons.ttf#,UWP=ListViewFontIcons.ttf#ListViewFontIcons,MacCatalyst=ListViewFontIcons,iOS=ListViewFontIcons}'
                        TextColor="#FFFFFF"
                        HorizontalOptions="Center"
                        FontSize="26"
                        VerticalOptions="Center">
                </Label>
            </Grid>
        </DataTemplate>
    </ListView:SfListView.EndSwipeTemplate>
    <ListView:SfListView.ItemTemplate>
        ---
    </ListView:SfListView.ItemTemplate>
</ListView:SfListView>

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
