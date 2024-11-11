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
