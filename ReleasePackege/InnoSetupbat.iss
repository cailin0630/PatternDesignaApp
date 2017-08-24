; �ű��� Inno Setup �ű��� ���ɣ�
; �йش��� Inno Setup �ű��ļ�����ϸ��������İ����ĵ���

#define MyAppName "PatternDesignaApp"
#define MyAppVersion "1.0"
#define MyAppPublisher "jiangyi"
#define MyAppExeName "PatternDesignaApp.exe"

[Setup]
; ע: AppId��ֵΪ������ʶ��Ӧ�ó���
; ��ҪΪ������װ����ʹ����ͬ��AppIdֵ��
; (�����µ�GUID����� ����|��IDE������GUID��)
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
; ע��: ��Ҫ���κι���ϵͳ�ļ���ʹ�á�Flags: ignoreversion��

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

