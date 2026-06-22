# PPMAC WPF HMI (Param UI Full Version)

## ✅ 功能
- Start / Stop
- 參數面板 (角度 / 背隙 / 次數 / 速度)
- 即時曲線 (LiveCharts)
- SQLite 履歷

## ✅ 執行
```
dotnet restore
dotnet build
dotnet run
```

## ✅ 修改IP
MainWindow.xaml.cs
```
ppmac.Connect("192.168.0.200");
```

