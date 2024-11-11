# .NET MAUI Application Analysis - Tasker

## 📱 Overview
1. **Main Page**:

<img width="457" alt="Screenshot 2024-11-11 at 1 24 50 PM" src="https://github.com/user-attachments/assets/218c14d8-bddb-434f-8ccb-896f426c2867">

2. **Clicked_PendingTasks**:

<img width="457" alt="Screenshot 2024-11-11 at 1 24 59 PM" src="https://github.com/user-attachments/assets/72df9fae-6081-4adb-b5b1-4eefceedbd79">

3. **Clicked_"+"**:

<img width="457" alt="Screenshot 2024-11-11 at 1 25 07 PM" src="https://github.com/user-attachments/assets/57aec796-b1b8-4f3d-bab1-79a49bba09e1">

4. **Clicked_AddCatagory**:

<img width="457" alt="Screenshot 2024-11-11 at 1 25 25 PM" src="https://github.com/user-attachments/assets/763b90f2-20b7-4155-a03b-9f30888b1bbe">

---
## 🛠 Development Environment Setup

```markdown
Required Tools:
- Visual Studio 2022
- JetBrains Rider
- .NET 7.0 or later
- MAUI Workload
- Android/iOS SDKs (for mobile development)
```
---
## 📝 Nuget Package
```markdown
- PropertyChanged.Fody
```
---
## 📂 Core Components - Project Structure
```markdown
- Tasker/
  ├── App.xaml
  │   ├── App.xaml.cs
  ├── AppShell.xaml
  ├── FodyWeavers.xml
  ├── MainPage.xaml
  ├── MauiProgram.cs
  ├── MVVM/
  │   ├── Models/
  │   │   ├── Category.cs
  │   │   └── MyTask.cs
  │   ├── ViewModels/
  │   │   ├── MainViewModel.cs
  │   │   └── NewTaskViewModel.cs
  │   ├── Views/
  │       ├── MainView.xaml
  │       │   └── MainView.xaml.cs
  │       ├── NewTaskView.xaml
  │           └── NewTaskView.xaml.cs
  ├── Converters/
  │   └── ColorConverter.cs
  ├── Platforms/
  ├── Resources/
  │   ├── AppIcon/
  │   ├── Fonts/
  │   ├── Images/
  │   ├── Raw/
  │   ├── Splash/
  │   └── Styles/


```
---
# ⭐️ Analysis of MainView.xaml

This document analyzes the provided `MainView.xaml` file, a Xamarin.Forms or .NET MAUI-based XAML page. The file defines a UI (`ContentPage`) for an application named **Tasker**, which appears to be a task management tool. The content page is structured using various layout controls like `Grid`, `CollectionView`, and other UI elements to present categorized tasks and pending tasks. Below, we provide a detailed breakdown of each part, including the properties and their roles in the UI.

### General Structure of MainView.xaml
The XAML defines a `ContentPage`, with namespaces and resources that allow the use of converters for data binding. It utilizes a hierarchical layout for the interface using grids and collection views. Here's a detailed breakdown:

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="Tasker.MVVM.Views.MainView"
             xmlns:converters="clr-namespace:Tasker.Converters"
             Title="Tasker">
```

The above code defines a `ContentPage` that:
- **xmlns** attributes specify the XAML namespaces for .NET MAUI or Xamarin.Forms and other supporting elements.
- **x:Class** assigns the page's backing C# class.
- **Title** sets the page title to "Tasker".
- **xmlns:converters** references a converter (`ColorConverter`) that is defined in the namespace `Tasker.Converters`. Converters are used for value conversion between binding source and UI.

### Resources Definition
```xml
<ContentPage.Resources>
    <converters:ColorConverter x:Key="ColorConverter" />
</ContentPage.Resources>
```
The `ContentPage.Resources` contains a resource dictionary where:
- **ColorConverter** is registered with the key "ColorConverter" for later use in binding.

### Main Layout Using Grid
The page layout is managed using a `Grid` with margin and multiple rows:

```xml
<Grid Margin="15" RowDefinitions=".1*, .3*, .7*">
```
- **Margin**: Adds padding between the `Grid` and its parent elements.
- **RowDefinitions**: The `Grid` is split into three rows of different sizes: `.1*`, `.3*`, and `.7*`, meaning that the space is proportionally divided.

### First Row - "My Tasks" Label
```xml
<Label Text="My Tasks" StyleClass="DarkBlue, Header" />
```
- **Label** with text "My Tasks" and styles applied using `StyleClass`. Styles can be defined to provide uniformity to UI elements (e.g., font size, color, etc.).

### Second Row - Categories Section
A nested `Grid` is defined for the Categories section:

```xml
<Grid Grid.Row="1" RowDefinitions=".2*, .8*">
    <Label StyleClass="LightBlue, SubHeader" Text="CATEGORIES" />
    <CollectionView Grid.Row="1" ItemsSource="{Binding Categories}">
        <CollectionView.ItemsLayout>
            <LinearItemsLayout ItemSpacing="5" Orientation="Horizontal" />
        </CollectionView.ItemsLayout>
        <CollectionView.ItemTemplate>
            <DataTemplate>
                <Grid Padding="10">
                    <RoundRectangle />
                    <VerticalStackLayout Padding="15" Spacing="10">
                        <Label StyleClass="LightBlue" Text="{Binding PendingTasks, StringFormat='{0} Tasks'}" />
                        <Label StyleClass="DarkBlue, CardTitle" Text="{Binding CategoryName}" />
                        <ProgressBar Progress="{Binding Percentage}" ProgressColor="{Binding Color, Converter={StaticResource ColorConverter}}" />
                    </VerticalStackLayout>
                </Grid>
            </DataTemplate>
        </CollectionView.ItemTemplate>
    </CollectionView>
</Grid>
```
- **Label** for the "CATEGORIES" header styled using `StyleClass`.
- **CollectionView**: Displays a list of categories using `ItemsSource` bound to the `Categories` property in the view model.
  - **LinearItemsLayout** is used to layout items horizontally with spacing of 5 units.
  - **DataTemplate**: Represents how each item is displayed, including a `RoundRectangle`, labels for task counts and category names, and a `ProgressBar`.
  - **ProgressBar**: The progress is colored using a value converter (`ColorConverter`).

### Third Row - Pending Tasks Section
```xml
<Grid Grid.Row="2" RowDefinitions=".2*, .8*">
    <Label StyleClass="LightBlue, SubHeader" Text="PENDING TASKS" />
    <CollectionView Grid.Row="1" ItemsSource="{Binding Tasks}" ItemsUpdatingScrollMode="KeepLastItemInView">
        <CollectionView.ItemTemplate>
            <DataTemplate>
                <Frame BorderColor="Transparent">
                    <HorizontalStackLayout>
                        <CheckBox x:Name="checkBox" IsChecked="{Binding Completed}" VerticalOptions="Center" CheckedChanged="checkBox_CheckedChanged" Color="{Binding TaskColor, Converter={StaticResource ColorConverter}}" />
                        <Label Text="{Binding TaskName}" VerticalOptions="Center">
                            <Label.Triggers>
                                <DataTrigger Binding="{Binding Source={x:Reference checkBox}, Path=IsChecked}" TargetType="Label" Value="True">
                                    <Setter Property="TextDecorations" Value="Strikethrough" />
                                </DataTrigger>
                            </Label.Triggers>
                        </Label>
                    </HorizontalStackLayout>
                </Frame>
            </DataTemplate>
        </CollectionView.ItemTemplate>
    </CollectionView>
</Grid>
```
- **Label** for the "PENDING TASKS" section.
- **CollectionView** to list pending tasks bound to the `Tasks` property.
  - **CheckBox** with event `CheckedChanged` to handle updates and a value converter for `Color`.
  - **Label** bound to `TaskName` with a `DataTrigger` to add a `Strikethrough` effect if the task is completed.

### Floating Action Button
```xml
<Button Grid.Row="2" Clicked="Button_Clicked" Text="+" Style="{StaticResource CircularButton}" />
```
- **Button** at the bottom of the grid designed to add new tasks, styled as a circular button.

### Properties Breakdown Table
The following table summarizes important properties from the XAML file:

| Property                | Element               | Description |
|-------------------------|-----------------------|-------------|
| Margin                  | Grid                  | Sets spacing around the element. |
| RowDefinitions          | Grid                  | Defines the height ratios of rows within the grid. |
| ItemsSource             | CollectionView        | Binds data to the view, usually from a ViewModel. |
| ItemsLayout             | CollectionView        | Specifies the layout type for items (e.g., Horizontal). |
| ItemTemplate            | CollectionView        | Defines the appearance of items. |
| StyleClass              | Label, Button         | Applies a reusable style to the element. |
| Converter               | ProgressBar, CheckBox | Converts values from one type to another for UI display. |
| CheckedChanged          | CheckBox              | Event triggered when the `CheckBox` changes state. |
| DataTrigger             | Label                 | Triggers a change in UI when a condition is met (e.g., `IsChecked` is true). |

### References
1. [.NET MAUI Documentation - Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/maui/)
2. [XAML Overview - Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/maui/xaml/?view=net-maui-8.0)
3. [Grid Class - Xamarin.Forms](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/layouts/grid)

