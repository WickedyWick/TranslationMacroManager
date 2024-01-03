# TranslatorMacroManager

## About
This app was mainly created for personal use but with some setup others can use or modify it as well!

App idea is to help quickly communicate with people in different language by translating on the spot or using preset text via keybind!

Application runs hidden in the notification bar but menu can be shown via ALT + NumPad0.

Translation from and to any language is supported *(default original language to translate FROM is English and language to translate TO is Chinese Traditional)*

Languages that are being translated from and to can be changed via menu as well. Language changes are saved even after reopening application.

There is on spot translation feature, type in text that you want to be translated in any application text box and trigger translation with CTRL + NumPad0 and wait a second. If language that its being translated from is same as in the menu setup, translated text will replace original text.
*If there is no translation happening check if original (from) language is set correctly!*
If textbox of the application loses focus and no translated text appears you can press CTRL + V and paste translated text yourself!

Currently there are 9 presets keybinded from CTRL + NumPad1 to CTRL + NumPad9 that I have for personal use, but this can be changed (only via code atm!).

| Keybind | Description |
| --------------- | --------------- |
| CTRL + NumPad0 | Translate and replace text on the spot |
| ALT + NumPad0 | Hides/Shows menu |
| CTRL + NumPad1 | *Hi* preset in Chinese |
| CTRL + NumPad2 | *Hi/Hello* preset in Chinese |
| CTRL + NumPad3 | *Hahaha* preset in Chinese |
| CTRL + NumPad4 | *Yes* preset in Chinese |
| CTRL + NumPad5 | *OK* preset in Chinese |
| CTRL + NumPad6 | *No* preset in Chinese |
| CTRL + NumPad7 | *Thanks* preset in Chinese |
| CTRL + NumPad8 | *Understood* preset in Chinese |
| CTRL + NumPad9 | *Goodbye* preset in Chinese |


## Setup
There is only one setup prerequisite and that is to have Free Translator Azure Service *I know, it's bothersome but there is no good open source translation api*

- Create Azure Portal Account on their [website](https://azure.microsoft.com/en-us/get-started/azure-portal)
- Create Translator Resource following [guide](https://learn.microsoft.com/en-us/azure/ai-services/translator/create-translator-resource)
- Insert API key, Location and Endpoint values in the settings file
![Example](https://github.com/WickedyWick/TranslationMacroManager/blob/main/image.png?raw=true)

## Settings file
Application requires settings file
Name of the file should be **settings.txt** and it should be placed in the same folder as executable
File file format is **key=value**


| Key | Description | Populated by |
| --------------- | --------------- | --------------- |
| ApiKey | Key to the azure translation service | User |
| Location | Location of the azure service | User |
| EndPoint | Endpoint of the service | User |
| FromLangCode | Saved language code so it can be reused when app is restarted | System |
| ToLangCode | Saved language code so it can be reused when app is restarted | System |

### Example
```

ApiKey=keyvalue
Location=westeurope
Endpoint=https://endpoint.com

```