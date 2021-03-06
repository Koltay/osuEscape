# osu! Escape

 **osu! Escape is an application which mainly provides osu! score submission blocking via 
 applying a blocking rule in your PC's advanced firewall with automated options.**
 
  **IMPORTANT: This application is only usable with firewall enabled!**
  
  **IMPORTANT: Please open this application with administrative privilege to avoid User Account Control issue!**

![image](https://user-images.githubusercontent.com/73950784/149756068-e750bbf8-2455-4d0c-b3f3-57b94d075e2d.png)

> osu! Escape main tab page

![image](https://user-images.githubusercontent.com/73950784/149756035-25662238-675a-4099-aefe-c3133b4b9c06.png)

> osu! Escape setting tab page

![image](https://user-images.githubusercontent.com/73950784/149756659-55559a14-4c01-4728-8f5e-1911e3f68b2b.png)

> osu! Escape uploaded scores tab page
 
 ## Video Showcase (Click here!)

[![Watch the video showcase here!](http://i3.ytimg.com/vi/N0ui0FeIaPE/hqdefault.jpg)](https://www.youtube.com/watch?v=N0ui0FeIaPE&ab_channel=Koltay)
 
 ## Inspiration from top osu! players
 
 - [1E308 (Nameless player)'s score submission video (Timestamp to score submission)](https://www.youtube.com/watch?v=D7x7OXpUmss&t=647s&ab_channel=RoriSanbyaku) 
 - [DigitalHypno's disable score submission video (host file edit method)](https://www.youtube.com/watch?v=lusAZ1fiph8&ab_channel=DigitalHypno)
 
## The Purpose of "Offline Playing"
 
 - [Spazza17's Fix Negative Mindset in osu! — Start Doing THIS](https://www.youtube.com/watch?v=cEyVSiY9ohU&ab_channel=Spazza17)
 
 It is proven by the osu! community that players could perform better without focusing on score leaderboards (global, country, and friends rankings) 
 
 While playing "offline" using osu! Escape, players would be able to upload scores with better performance
 
 Players who care about playcount could use this for submitting scores only when they feel like to
 
 ## Features
 
 Score uploading features are currently only available on osu! stable but not osu! lazer.
 
 There are mainly two parts for this project: Manual connection and Auto connection.
 
 ### Manual Connection:
 
 - **Global Hotkey for Toggling osu! Connection:** 
 > Toggle the connection using the F6 Key (Default), it also supports binding with multiple modifier keys (e.g. Ctrl, Shift, Alt)

 ### Auto Connection:
 
 - **Auto Submission:** 
 > After players hit the last note of the beatmap, score meeting the user requirement (accuracy or full combo) would be submitted 
  
 > The score would be submitted to the server while players are on the result screen
 
 - **Auto Blocking:** 
 
 > Automatically disconnect players from the server after uploading the recent score (API needed)
 
 > Auto blocking also avoid uploading other scores by the players

 > Scores that are not submitted will keep trying to submit, it is recommended to restart osu! after submitting the score you want in order to cancel the unneeded scores**
 
 > osu! client with lots of score submission attempts would cause latency, it is recommended to restart osu! per hour of osu! session**
 
 - **Refresh rate slider:** 
 
 > This slider determines the frequency on updating osu! score's statistics
 
 > As for users who use automatic connection/ disconnection, it is recommended to set the refresh rate to 100 or below
 
 > As for users who have issues on osu! latency, it is recommended to set the refresh rate to more than 250 or above

## API Usage
 
 This application uses [osu! API v1](https://github.com/ppy/osu-api/wiki) to get users' recent uploaded score and automatically disconnect after uploading.
 
 As for the users who are concerned about the API usage, please feel free to not use it :D

## Details on Advanced Firewall Rule

Win + R and type "wf.msc" in "Run" box to open Windows Defender Firewall with Advanced Security

![image](https://user-images.githubusercontent.com/73950784/145205485-2d47cb8d-14a2-44d9-b534-e79efaf6cc9b.png)

There should be "osu block" rule enabled which blocks the connection to osu! unless it is disabled (while uploading scores)

![firewall rule](https://user-images.githubusercontent.com/73950784/145205745-baa4cc17-292f-4b01-a313-8fa8abc6add0.png)


## <3
 Thank you to those who gave positive feedback or contributed to this project (Listed in ascending order by osu! IGN):
 
 Testing: 
 - Hellotomlol225
 - issacCLAKE124
 - Muji
 - Surac
 - Takanashi Ako
 
 Coding: 
 - DenierNezzar
 - Shion Maker
 
 ## Licenses
 The following projects are used in osu! Escape:
 - [ProcessMemoryDataFinder](https://github.com/Piotrekol/ProcessMemoryDataFinder), [GPL-3.0](https://github.com/Piotrekol/ProcessMemoryDataFinder/blob/master/LICENSE)
