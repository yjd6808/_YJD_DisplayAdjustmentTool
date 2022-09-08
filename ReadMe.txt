< Display Adjustment Tool >

데바데(Dead by Daylight) 게임을 할 때 NVidia Experience의 밝기 조절 기능만으로는 플레이가 원할하지 못해서 만듬
그렇다고 매번 게임을 실행할 때마다 NVidia Control Panel을 실행해서 밝기,대비,감마를 일일히 수정해주기가 너무 귀찮아서.


사용법:
  [변경]
  DisplayAdjustmentGUI.exe [디스플레이 인덱스] [밝기 0~100] [대비 0~100] [감마 0~100]
  => 디스플레이 인덱스는 모니터가 2개면 0또는 1로 전달해서 원하는 모니터의 해상도를 조절할 수 있다.

  [복구]
  => 기존 밝기, 대비, 감마 설정으로 복구하기 위해서는 DisplayAdjustmentGUI.exe [디스플레이 인덱스] 50 50 25를 실행하면 된다

  [원하는 설정 찾기]
  => 인자를 아무것도 전달하지 않고 실행하면 윈도우 애플리케이션이 실행되고 슬라이더를 움직여서 원하는 설정을 찾아내면 된다.
  
  
사용한 라이브러리:
 - windowdisplayapi v1.3.0.13 (내장)
   
   프로젝트에 포함시킨 이유
   1. 타겟 프레임워크를 net6.0으로 변경시키기 위함
   2. 라이브러리의 일부 소스코드가 살짝 수정이 필요해서.


소스코드:
  DisplayAdjustmentGUI/App.xaml.cs
  DisplayAdjustmentGUI/MainWindow.xaml
  DisplayAdjustmentGUI/MainWindow.xaml.cs
  