namespace autoinstall
{
    public static class Apps
    {
        public static string Json = @"
        {
            'Browsers': {
                'chrome': {
                    'name': 'Google Chrome',
                    'icon': 'chrome.png',
                    'downloadUrl': 'https://dl.google.com/chrome/install/latest/chrome_installer.exe',
                    'type': 'exe',
                    'params': '',
                    'afterParams': 'taskkill /f /im chrome.exe'
                },
                'brave': {
                    'name': 'Brave',
                    'icon': 'brave.png',
                    'downloadUrl': 'https://referrals.brave.com/latest/BraveBrowserSetup-BRV010.exe',
                    'type': 'exe',
                    'params': '',
                    'afterParams': 'taskkill /f /im brave.exe'
                },
                'firefox': {
                    'name': 'Firefox',
                    'icon': 'firefox.png',
                    'downloadUrl': 'https://download.mozilla.org/?product=firefox-latest&os=win&lang=en-US',
                    'type': 'exe',
                    'params': '/S',
                    'afterParams': ''
                },
            },
            'Utility': {
                'everything': {
                    'name': 'Everything',
                    'icon': 'everything.png',
                    'downloadUrl': 'https://www.voidtools.com/Everything-1.4.1.1024.x64-Setup.exe',
                    'type': 'exe',
                    'params': '/S',
                    'afterParams': ''
                },
            },
            'Media': {
                'vlc': {
                    'name': 'VLC',
                    'icon': 'vlc.png',
                    'downloadUrl': 'https://get.videolan.org/vlc/3.0.21/win64/vlc-3.0.21-win64.exe',
                    'type': 'exe',
                    'params': '/S',
                    'afterParams': ''
                },
                'audacity': {
                    'name': 'Audacity',
                    'icon': 'audacity.png',
                    'downloadUrl': 'https://github.com/audacity/audacity/releases/download/Audacity-3.6.0/audacity-win-3.6.0-64bit.exe',
                    'type': 'exe',
                    'params': '/verysilent',
                    'afterParams': ''
                },
                'obs': {
                    'name': 'OBS Studio',
                    'icon': 'obs.png',
                    'downloadUrl': 'https://cdn-fastly.obsproject.com/downloads/OBS-Studio-30.2.0-Windows-Installer.exe',
                    'type': 'exe',
                    'params': '/S',
                    'afterParams': ''
                },
            },
            'Messaging': {
                'discord': {
                    'name': 'Discord',
                    'icon': 'discord.png',
                    'downloadUrl': 'https://discord.com/api/downloads/distributions/app/installers/latest?channel=stable&platform=win&arch=x64',
                    'type': 'exe',
                    'params': '',
                    'afterParams': ''
                },
            },
			'Imaging': {
                'blender': {
                    'name': 'Blender',
                    'icon': 'blender.png',
                    'downloadUrl': 'https://ftp.nluug.nl/pub/graphics/blender/release/Blender4.2/blender-4.2.0-windows-x64.msi',
                    'type': 'msi',
                    'params': '/passive',
                    'afterParams': ''
                },
                'sharex': {
                    'name': 'ShareX',
                    'icon': 'sharex.png',
                    'downloadUrl': 'https://github.com/ShareX/ShareX/releases/download/v16.1.0/ShareX-16.1.0-setup.exe',
                    'type': 'exe',
                    'params': '/verysilent',
                    'afterParams': 'taskkill /f /im ShareX.exe'
                },
            },
            'Development': {
                'vscode': {
                    'name': 'Visual Studio Code',
                    'icon': 'vscode.png',
                    'downloadUrl': 'https://code.visualstudio.com/sha/download?build=stable&os=win32-x64-user',
                    'type': 'exe',
                    'params': '/silent',
                    'afterParams': 'taskkill /f /im Code.exe'
                },
                'notepadplusplus': {
                    'name': 'Notepad++',
                    'icon': 'notepadplusplus.png',
                    'downloadUrl': 'https://github.com/notepad-plus-plus/notepad-plus-plus/releases/download/v8.6.9/npp.8.6.9.Installer.x64.exe',
                    'type': 'exe',
                    'params': '/S',
                    'afterParams': ''
                }
            },
            'Games': {
                'steam': {
                    'name': 'Steam',
                    'icon': 'steam.png',
                    'downloadUrl': 'https://cdn.akamai.steamstatic.com/client/installer/SteamSetup.exe',
                    'type': 'exe',
                    'params': '/S',
                    'afterParams': ''
                },
                'epicgames': {
                    'name': 'Epic Games',
                    'icon': 'epicgames.png',
                    'downloadUrl': 'https://launcher-public-service-prod06.ol.epicgames.com/launcher/api/installer/download/EpicGamesLauncherInstaller.msi',
                    'type': 'msi',
                    'params': '/passive',
                    'afterParams': ''
                }
            }
        }";
    }
}
