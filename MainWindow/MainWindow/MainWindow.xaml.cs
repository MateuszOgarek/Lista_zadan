< Window x: Class = "TaskManagerWPF.MainWindow"
        xmlns = "http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns: x = "http://schemas.microsoft.com/winfx/2006/xaml"
        Title = "Task Manager" Height = "400" Width = "600" >
    < Grid >
        < Grid.RowDefinitions >
            < RowDefinition Height = "Auto" />
            < RowDefinition Height = "*" />
        </ Grid.RowDefinitions >

        < !--Dodawanie nowego zadania -->
        <StackPanel Orientation="Horizontal" Margin="10">
            <TextBox Name="TitleTextBox" Width="200" PlaceholderText="Tytuł"/>
            <DatePicker Name="DueDatePicker" Width="120"/>
            <Button Content="Dodaj" Click="AddTask_Click" Margin="10,0,0,0"/>
        </StackPanel>

        <!-- Lista zadań -->
        <ListBox Name="TaskList" Grid.Row="1" Margin="10">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <CheckBox IsChecked="{Binding IsCompleted}" Click="CompleteTask_Click"/>
                        <TextBlock Text="{Binding Title}" Margin="10,0,0,0"/>
                        <TextBlock Text="{Binding DueDate, StringFormat='d MMM yyyy'}" Margin="10,0,0,0"/>
                        <Button Content="Usuń" Click="DeleteTask_Click" Margin="10,0,0,0"/>
                    </StackPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
</Window>
