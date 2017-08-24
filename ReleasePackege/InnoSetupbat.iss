; 脚本由 Inno Setup 脚本向导 生成！
; 有关创建 Inno Setup 脚本文件的详细资料请查阅帮助文档！

#define MyAppName "PatternDesignaApp"
#define MyAppVersion "1.0"
#define MyAppPublisher "jiangyi"
#define MyAppExeName "PatternDesignaApp.exe"

[Setup]
; 注: AppId的值为单独标识该应用程序。
; 不要为其他安装程序使用相同的AppId值。
; (生成新的GUID，点击 工具|在IDE中生成GUID。)
AppId={{F43C7E7E-C27B-4A2C-80E3-B4DB3CCCEBF4}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName=C:\Program Files\{#MyAppName}
DisableProgramGroupPage=yes
OutputDir=D:\Code\GitHub\Mine\PatternDesignaApp\Release
OutputBaseFilename=PatternDesignaApp_setup
SetupIconFile=C:\Users\Administrator\Downloads\if_Edit_1891026.ico
Password=jy123
Encryption=yes
Compression=lzma
SolidCompression=yes

[Languages]
Name: "chinesesimp"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: checkablealone; OnlyBelowVersion: 0,8.1

[Files]
Source: "D:\Code\GitHub\Mine\PatternDesignaApp\PatternDesignaApp\bin\Debug\PatternDesignaApp.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Code\GitHub\Mine\PatternDesignaApp\PatternDesignaApp\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; 注意: 不要在任何共享系统文件上使用“Flags: ignoreversion”

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

