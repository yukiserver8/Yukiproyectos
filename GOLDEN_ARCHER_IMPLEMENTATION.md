# Golden Archer Implementation

Golden Archer spans server logic, client presentation, generated metadata, and launcher distribution.

## Sources of truth

- Server costs and rewards: `Source/Emulator/GameServer/GoldenArcher.cpp`
- Client button thresholds and rendering: `Source/Main/Main/GoldenArcher.cpp`
- Localized labels and lore text: `Program/MuServer97K/Tools/GetMainInfo/Data/CustomMessage.txt`

Update every language block when changing client-facing text.

## Build and distribution

`GetMainInfo` generates `ServerInfo.sse`. The launcher distributes `Main.dll` and `ServerInfo.sse` from `Launcher/Update/`; both files must be listed with the correct CRC32 and byte size in `ArchiveList.txt`.

Keep `ServerInfo.sse` at its exact fixed size. Never append bytes to it; modify existing fields and regenerate it with `GetMainInfo`.

## Root causes learned

An apparently correct server change is insufficient when the Golden Archer client is stale. Failures can come from mismatched server constants, client thresholds, language-specific labels, generated `ServerInfo.sse`, launcher manifests, or a different client installation.

The item-shop format also uses `Item.txt` section numbers. It does not use armor group numbers: for example, `02,004` is a mace section entry, not Bone Helm.

## Verification checklist

- [ ] Server constants match client thresholds.
- [ ] English, Portuguese, and Spanish message blocks are reviewed.
- [ ] `GetMainInfo` regenerated `ServerInfo.sse`.
- [ ] `ServerInfo.sse` retains the exact fixed size.
- [ ] Launcher `Main.dll` and `ServerInfo.sse` are current.
- [ ] Both launcher `ArchiveList.txt` manifests contain correct CRC32 and sizes.
- [ ] Public HTTP files match the local deployment files.
- [ ] An affected player's client hashes are verified.
