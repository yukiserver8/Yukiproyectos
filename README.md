# Mu Online 97K+99B - Cliente EX097 KOR (SSeMU)

Cliente modificado para servidor privado Mu Online 97K basado en SSeMU.

## Servidor

- **Servidor**: YukiServer
- **IP ConnectServer**: `yukisrv.ddns.net:44405` (WAN) / `192.168.1.117:44405` (LAN)
- **IP GameServer**: `yukisrv.ddns.net:55900` (WAN) / `192.168.1.117:55900` (LAN)
- **Versión**: 0.97.11
- **Serial**: TbYehR2hFUPBKgZj
- **CustomerName**: MuOnline

## Cambios realizados

### Encriptación socket-level
- `CustomerName` cambiado de `"Nico"` a `"MuOnline"` en `ServerInfo.sse`, `MainInfo.ini` y `HackCheck.cpp`
- Claves derivadas: `EncDecKey1 = 0xE6`, `EncDecKey2 = 0xBC`
- MHP layer desactivado (`ServerEncDecKey1=0`, `ServerEncDecKey2=0`)

### Red / Conectividad
- `ServerInfo.sse`: apunta a `yukisrv.ddns.net:44405`
- `ServerInfo_LAN.sse`: apunta a `192.168.1.117:44405` (pruebas locales)
- ConnectServer recompilado con resolución DNS: convierte `yukisrv.ddns.net` a IP numérica automáticamente antes de enviar al cliente (evita límite de 16 bytes en protocolo F4:03)

### Base de datos (MuYuki)
- Columna `Bloc_Expire` agregada a `MEMB_INFO` (nullable con default `2079-06-05 23:59:00`)
- Columna `sno_numb` agregada a `MEMB_INFO` (compatibilidad kayitoEditor)
- `ctl1_code` cambiado a `NULL` con default `'0'`
- `AccountExpireDate` actualizado a `2079-06-05 23:59:00` para cuentas existentes
- Default de `AccountExpireDate` cambiado de `((0))` a `'2079-06-05 23:59:00'`
- Columna `GrandResetCount` agregada a `Character` (default `0`)

### kayitoEditor
- Compatible con consultas y altas de cuentas
- Errores corregidos: fechas NULL, columnas faltantes (`Bloc_Expire`, `sno_numb`, `GrandResetCount`)

## Archivos importantes

| Archivo | Propósito |
|---------|-----------|
| `ServerInfo.sse` | Config cliente para conectar al servidor (WAN) |
| `ServerInfo_LAN.sse` | Config cliente para conectar al servidor (LAN) |
| `Data/` | Recursos del juego (maps, monsters, items, etc.) |
| `Config.ini` | Configuración del cliente |
| `main.exe` | Ejecutable del juego |
| `mu.ini` | Configuración de video/audio del juego |

## Cómo usar

1. Descargar/clonar el repositorio
2. Ejecutar `main.exe`
3. Usar `ServerInfo_LAN.sse` para pruebas en LAN (renombrar a `ServerInfo.sse`)
