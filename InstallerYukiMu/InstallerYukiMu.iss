; =============================================================================
;  YukiMu Online - Instalador Profesional
;  Descarga el cliente desde la web, lo extrae e instala.
;
;  REQUISITOS: Inno Setup 6+ (https://jrsoftware.org/isdl.php)
;
;  COMPILACION:
;    1. Abrir este archivo en Inno Setup Compiler
;    2. Build > Compile (Ctrl+F9)
;    3. El instalador se genera en Output\YukiMu-Setup-{version}.exe
;
;  PERSONALIZACION:
;    - Cambiar las lineas "#define" abajo para tu servidor
;    - Reemplazar images\banner.bmp, logo.bmp, iconomuyuki.ico
; =============================================================================

; =============================================================================
;  >>> CONFIGURACION DEL SERVIDOR <<<
;  Modifica estas lineas antes de compilar
; =============================================================================
#define MyAppName        "YukiMu Online"
#define MyAppVersion     "0.97.11"
#define MyAppPublisher   "YukiMu Team"
#define MyAppURL         "http://yukisrv.ddns.net"
#define MySupportURL     "http://yukisrv.ddns.net/soporte"
#define MyDownloadURL    "https://yukisrv.ddns.net/Cliente.zip"
#define MyLauncherName   "Launcher.exe"
#define MyInstallFolder  "YukiMu"
#define MyUserAgent      "YukiMu-Installer/1.0"
#define MyExpectedSHA256 ""              ; SHA-256 del ZIP (vacio = no verificar)
#define MyMaxRetries     3
#define MyChunkSize      65536           ; 64 KB por chunk de descarga

; =============================================================================
[Setup]
; =============================================================================
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MySupportURL}
DefaultDirName={autopf}\{#MyInstallFolder}
DefaultGroupName={#MyAppName}
DisableDirPage=no
DisableProgramGroupPage=yes
DisableReadyPage=no
DisableFinishedPage=yes
DisableWelcomePage=no
DisableStartupPrompt=yes
WizardStyle=modern
WizardResizable=no
WizardImageFile=images\banner.bmp
WizardSmallImageFile=images\logo.bmp
SetupIconFile=images\iconomuyuki.ico
ShowLanguageDialog=no
OutputDir=Output
OutputBaseFilename=YukiMu-Setup-{#MyAppVersion}
VersionInfoVersion={#MyAppVersion}
VersionInfoCompany={#MyAppPublisher}
VersionInfoDescription=Instalador de {#MyAppName}
PrivilegesRequired=admin
PrivilegesRequiredOverridesAllowed=dialog
UninstallDisplayIcon={app}\{#MyLauncherName}
UninstallDisplayName={#MyAppName}
AlwaysRestart=no

; =============================================================================
;  ARCHIVOS DEL INSTALADOR (solo imagenes, el cliente se descarga online)
; =============================================================================
[Files]
; El cliente se descarga desde la web, no se incluyen archivos en el instalador

; =============================================================================
;  ACCESOS DIRECTOS
; =============================================================================
[Icons]
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyLauncherName}"; \
  WorkingDir: "{app}"; Tasks: desktopicon
Name: "{autoprograms}\{#MyAppName}\{#MyAppName}"; \
  Filename: "{app}\{#MyLauncherName}"; WorkingDir: "{app}"
Name: "{autoprograms}\{#MyAppName}\Desinstalar {#MyAppName}"; \
  Filename: "{uninstallexe}"

; =============================================================================
;  TAREAS
; =============================================================================
[Tasks]
Name: "desktopicon"; Description: "Crear acceso directo en el &Escritorio"; \
  GroupDescription: "Accesos directos:"; Flags: checkedonce

; =============================================================================
;  CODIGO PASCAL
; =============================================================================
[Code]

var
  DownloadPage: TDownloadWizardPage;
  LauncherName: string;

function InitializeSetup: Boolean;
begin
  LauncherName := '{#MyLauncherName}';
  Result := True;
end;

procedure InitializeWizard;
begin
  DownloadPage := CreateDownloadPage(SetupMessage(msgWizardPreparing), SetupMessage(msgPreparingDesc), nil);
end;

function NextButtonClick(CurPageID: Integer): Boolean;
var
  ResCode: Integer;
  ZipPath, AppDir: string;
  Shell: Variant;
  ZipFolder: Variant;
begin
  Result := True;
  if CurPageID = wpReady then
  begin
    DownloadPage.Clear;
    DownloadPage.Add('{#MyDownloadURL}', ExtractFileName('{#MyDownloadURL}'), '');
    DownloadPage.Show;
    try
      try
        DownloadPage.Download;
      except
        if DownloadPage.AbortedByUser then
          Log('Descarga cancelada por el usuario.')
        else begin
          MsgBox('Error al descargar: ' + GetExceptionMessage, mbError, MB_OK);
        end;
        Result := False;
      end;
      if Result then
      begin
        ZipPath := ExpandConstant('{tmp}') + '\' + ExtractFileName('{#MyDownloadURL}');
        AppDir := ExpandConstant('{app}');
        ForceDirectories(AppDir);
        Shell := CreateOleObject('Shell.Application');
        ZipFolder := Shell.NameSpace(ZipPath);
        if not VarIsEmpty(ZipFolder) then
        begin
          Shell.NameSpace(AppDir).CopyHere(ZipFolder.Items, 20);
          if FileExists(AppDir + '\' + LauncherName) then
          begin
            if MsgBox('Instalacion completada.'#13#10#13#10'¿Deseas ejecutar ' + LauncherName + ' ahora?', mbConfirmation, MB_YESNO) = IDYES then
              ShellExec('open', AppDir + '\' + LauncherName, '', AppDir, SW_SHOWNORMAL, ewNoWait, ResCode);
          end
          else
            MsgBox('La instalacion se completo pero no se encontro ' + LauncherName + '.', mbError, MB_OK);
        end
        else
          MsgBox('Error al extraer el archivo ZIP.', mbError, MB_OK);
      end;
    finally
      DownloadPage.Hide;
    end;
  end;
end;
